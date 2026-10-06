using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading.Tasks;
using cr_100.ModbusCore;
using cr_100.Devices;

namespace cr_100;

public partial class Form1 : Form
{
    private readonly ModbusEngine _engine = new();
    private ModbusDevice? _currentDevice;
    private bool _isPollingBacking = false;
    private bool _isPolling
    {
        get => _isPollingBacking;
        set
        {
            _isPollingBacking = value;
            // If polling is explicitly turned off, instantly prevent any background label updates
            if (!value)
            {
                _engine.Disconnect();
            }
        }
    }

    public Form1()
    {
        InitializeComponent();
        this.Load += Form1_Load;
        btnStart.Click += btnStart_Click;
        btnStop.Click += btnStop_Click;
        btnRefreshPorts.Click += (s, e) => { if (!_isPolling) ScanPorts(); };

    if (System.IO.File.Exists("mal.ico"))
        {
            this.Icon = new System.Drawing.Icon("mal.ico");
        }


        cmbComPorts.DrawItem += ComDraw; cmbBaudRates.DrawItem += ComDraw; cmbPortMode.DrawItem += ComDraw;

        BindUiControls(this);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            _currentDevice = JsonModbusDevice.LoadFromFile("cr_100.json");
            lblStatus.Text = $"Канфігурыцыя '{_currentDevice.DeviceName}' загружана.";
            ScanPorts();
            if (cmbBaudRates.Items.Count > 1) cmbBaudRates.SelectedIndex = 1; // 19200 по умолчанию
            if (cmbPortMode.Items.Count > 0) cmbPortMode.SelectedIndex = 0;

            // При старте (пока опрос не запущен) блокируем все кнопки команд
            ToggleDynamicActionControls(this, false);
        }
        catch (Exception ex) { MessageBox.Show($"Памылка JSON: {ex.Message}"); }
    }

    private void ScanPorts()
    {
        cmbComPorts.Items.Clear();
        string[] p = SerialPort.GetPortNames();
        if (p.Length > 0) { Array.Sort(p); cmbComPorts.Items.AddRange(p); cmbComPorts.SelectedIndex = 0; lblStatus.Text = "Парты абноўлены."; }
        else lblStatus.Text = "COM-парты не знойдзены!";
    }
    private async void btnStart_Click(object sender, EventArgs e)
    {
        if (_isPolling || _currentDevice == null) return;
        try
        {
            if (cmbComPorts.SelectedIndex == -1) { MessageBox.Show("Абярыце COM-порт!"); return; }

            string selectedPort = cmbComPorts.SelectedItem.ToString()!;
            int selectedBaud = Convert.ToInt32(cmbBaudRates.SelectedItem);

            Parity pr = Parity.None; StopBits sb = StopBits.One;
            switch (cmbPortMode.SelectedIndex) { case 1: sb = StopBits.Two; break; case 2: pr = Parity.Even; break; case 3: pr = Parity.Odd; break; }

            _engine.ConnectRtu(selectedPort, selectedBaud, pr, sb, 1000);

            if (byte.TryParse(txtSlaveId.Text, out byte sid) && sid > 0)
            {
                var prop = _currentDevice.GetType().GetProperty("SlaveId");
                if (prop != null) prop.SetValue(_currentDevice, sid);
            }

            // Set state to TRUE before interlocking the interface
            _isPolling = true;
            ToggleInterfaceState(false);

            while (_isPolling)
            {
                try
                {
                    // Instant thread-interlock check
                    if (!_isPolling) break;

                    if (lblStatus.Text.StartsWith("Памылка сувязі"))
                    {
                        lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
                        lblStatus.Text = "Перападключэнне да прылады...";
                        _engine.ConnectRtu(selectedPort, selectedBaud, pr, sb, 1000);
                    }

                    await _engine.PollDeviceAsync(_currentDevice);

                    // Safety Interlock check directly after network await operation wakes up
                    if (!_isPolling) break;

                    foreach (var param in _currentDevice.Parameters)
                    {
                        TextBox? targetTxt = FindBox(this, param.Name);
                        ComboBox? targetCmb = FindComboBoxByTag(this, param.Name);
                        string unitSuffix = !string.IsNullOrEmpty(param.Unit) ? param.Unit : "";
                        string displayValue = param.Value.ToString()!;

                        if (param.DataType != ModbusDataType.Bit && param.Value != null)
                        {
                            if (double.TryParse(param.Value.ToString(), out double rawNum))
                            {
                                int rawKey = (int)rawNum;
                                if (param.EnumValues != null && param.EnumValues.Count > 0)
                                {
                                    var enumMatch = param.EnumValues.Find(x => x.Key == rawKey);
                                    displayValue = enumMatch != null ? enumMatch.Value : $"{rawKey} (Unknown)";

                                    if (targetCmb != null)
                                    {
                                        if (targetCmb.Items.Count == 0)
                                        {
                                            foreach (var item in param.EnumValues) targetCmb.Items.Add(item.Value);
                                        }
                                        int targetIdx = param.EnumValues.FindIndex(x => x.Key == rawKey);
                                        if (targetIdx != -1 && targetCmb.DroppedDown == false) targetCmb.SelectedIndex = targetIdx;
                                    }
                                }
                                else
                                {
                                    double scaledNum = rawNum * param.Scale;
                                    if (Math.Abs(param.Scale - 1.0) < 0.0001) displayValue = ((int)scaledNum).ToString();
                                    else
                                    {
                                        string scaleStr = param.Scale.ToString(System.Globalization.CultureInfo.InvariantCulture);
                                        int decimalPlaces = scaleStr.Contains(".") ? scaleStr.Split('.').Length - 1 : 0;
                                        displayValue = scaledNum.ToString("0." + new string('0', decimalPlaces), System.Globalization.CultureInfo.InvariantCulture);
                                    }
                                }
                            }
                        }
                        else if (param.DataType == ModbusDataType.Bit)
                        {
                            bool isBitOn = (bool)param.Value;
                            displayValue = isBitOn ? "1" : "0";

                            if (targetTxt != null)
                            {
                                string lampText = isBitOn ? "1" : "0";
                                System.Drawing.Color actualBgColor = isBitOn ? System.Drawing.Color.FromName("LightGreen") : System.Drawing.SystemColors.Control;
                                System.Drawing.Color textColor = isBitOn ? System.Drawing.Color.DarkGreen : System.Drawing.SystemColors.WindowText;

                                if (param.BitLabels != null)
                                {
                                    lampText = isBitOn ? param.BitLabels.OnText : param.BitLabels.OffText;
                                    actualBgColor = System.Drawing.Color.FromName(isBitOn ? param.BitLabels.OnColor : param.BitLabels.OffColor);
                                    string customColorStr = isBitOn ? param.BitLabels.OnColor : param.BitLabels.OffColor;
                                    textColor = customColorStr.Equals("Red", StringComparison.OrdinalIgnoreCase) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                                }

                                targetTxt.BackColor = actualBgColor;
                                targetTxt.ForeColor = textColor;
                                targetTxt.Text = lampText;
                                targetTxt = null;
                            }
                        }

                        if (targetTxt != null) targetTxt.Text = displayValue + unitSuffix;
                    }

                    // CRITICAL INTERLOCK: Verify polling state one final time before painting "Связь: OK"
                    if (!_isPolling) break;

                    lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
                    lblStatus.Text = "Сувязь: OK";
                }
                catch (Exception ex)
                {
                    // If the user hit STOP while we were waiting for a Modbus response, exit cleanly without showing an error
                    if (!_isPolling) break;

                    lblStatus.ForeColor = System.Drawing.Color.DarkRed;
                    lblStatus.Text = $"Памылка сувязі: {ex.Message}";
                    _engine.Disconnect();
                }

                if (!_isPolling) break;
                await Task.Delay(1000);
            }
        }
        catch (Exception ex) { MessageBox.Show($"Памылка старта: {ex.Message}"); StopPolling(); }
    }









    private async void UniversalButton_Click(object sender, EventArgs e)
    {
        if (_currentDevice == null || sender is not Button clickedButton || clickedButton.Tag == null) return;
        string commandName = clickedButton.Tag.ToString()!;

        ModbusCommand? cmd = _currentDevice.Commands.Find(x => x.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));
        if (cmd == null) { MessageBox.Show($"Каманда '{commandName}' адсутнічае ў JSON!"); return; }

        // ГЕНЕРАЦЫЯ ТЭКСТУ: Калі ў JSON ёсць кастомны ConfirmText — бяром яго, інакш ствараем стандартны шаблон
        string msg = !string.IsNullOrEmpty(cmd.ConfirmText)
            ? cmd.ConfirmText
            : (cmd.BitPosition.HasValue
                ? $"Выканаць пабітовую каманду '{cmd.Name}'?\n(Будзе зменены біт №{cmd.BitPosition.Value} у рэг. {cmd.Address})"
                : $"Запісаць канстанту {cmd.Value} у рэгістр {cmd.Address}?");

        // Усплываючае вакно з кастомным тэкстам
        if (MessageBox.Show(msg, "Пацвярджэнне запісу", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

        try
        {
            lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            lblStatus.Text = $"Выкананне: {cmd.Name}...";

            if (cmd.BitPosition.HasValue && cmd.BitValue.HasValue)
            {
                await _engine.WriteBitInRegisterAsync(
                    _currentDevice.SlaveId,
                    cmd.Address,
                    cmd.BitPosition.Value,
                    cmd.BitValue.Value
                );
            }
            else
            {
                await _engine.WriteConstantOrVariableAsync(_currentDevice.SlaveId, cmd.Address, cmd.Value);
            }

            lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
            lblStatus.Text = $"Паспяхова выканана: {cmd.Name}";
        }
        catch (Exception ex)
        {
            lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            lblStatus.Text = $"Памылка: {ex.Message}";
            _engine.Disconnect();
        }
    }




    private async void TextBox_Click(object sender, EventArgs e)
    {
        if (_currentDevice == null || sender is not TextBox box || box.Tag == null) return;
        ModbusParameter? p = _currentDevice.Parameters.Find(x => x.Name.Equals(box.Tag.ToString(), StringComparison.OrdinalIgnoreCase));
        if (p == null) return;

        // Translated dialog inputs to Belarusian ("Увядзіце значэнне", "Змяненне")
        string val = Microsoft.VisualBasic.Interaction.InputBox($"Увядзіце значэнне (Рэг: {p.StartAddress}):", $"Змяненне: {p.Name}", box.Text);
        if (string.IsNullOrWhiteSpace(val) || !short.TryParse(val, out short n)) return;

        // Translated confirmation prompt to Belarusian ("Запісаць... у рэгістр?", "Запіс")
        if (MessageBox.Show($"Запісаць {n} у рэгістр {p.StartAddress}?", "Запіс", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;
        try
        {
            lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            lblStatus.Text = "Запіс даных...";

            await _engine.WriteConstantOrVariableAsync(_currentDevice.SlaveId, p.StartAddress, (ushort)n);

            lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
            lblStatus.Text = $"Запісана: {n} у рэг. {p.StartAddress}";
        }
        catch (Exception ex)
        {
            lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            lblStatus.Text = $"Памылка запісу: {ex.Message}";
            _engine.Disconnect();
        }
    }

    private void BindUiControls(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Tag != null && !string.IsNullOrWhiteSpace(c.Tag.ToString()))
            {
                // 1. ОБРАБОТКА ТЕКСТОВЫХ ПОЛЕЙ (TextBox)
                if (c is TextBox tb)
                {
                    tb.TextAlign = HorizontalAlignment.Center;

                    // РАЗДЕЛЕНИЕ: Если вы в дизайнере оставили ReadOnly = False, 
                    // значит это изменяемая уставка/коэффициент!
                    if (tb.ReadOnly == false)
                    {
                        tb.ReadOnly = true;        // Защищаем от прямого ввода букв с клавиатуры
                        tb.Cursor = Cursors.Hand;  // Ставим указатель "руку"
                        tb.Click += TextBox_Click; // Разрешаем открывать окно изменения значения
                    }
                    else
                    {
                        // Если в дизайнере жестко задано ReadOnly = True,
                        // значит это поле ТОЛЬКО ДЛЯ ЧТЕНИЯ (Ток, Частота, Лампы битов и т.д.)
                        tb.Cursor = Cursors.Default; // Обычный курсор-стрелка, клик НЕ привязывается!
                    }
                }
                // 2. ОБРАБОТКА ВЫПАДАЮЩИХ СПИСКОВ (ComboBox)
                else if (c is ComboBox cb && cb != cmbComPorts && cb != cmbBaudRates && cb != cmbPortMode)
                {
                    cb.Cursor = Cursors.Hand;
                    cb.SelectionChangeCommitted += UniversalComboBox_SelectionChangeCommitted;
                }
                // 3. ОБРАБОТКА КНОПОК КОМАНД (Button)
                else if (c is Button btn && btn != btnStart && btn != btnStop && btn != btnRefreshPorts)
                {
                    btn.Click += UniversalButton_Click;
                }
            }

            if (c.HasChildren) BindUiControls(c);
        }
    }



    private void ToggleInterfaceState(bool enable)
    {
        _isPolling = !enable; btnStart.Enabled = enable; btnStop.Enabled = !enable;
        cmbComPorts.Enabled = cmbBaudRates.Enabled = cmbPortMode.Enabled = btnRefreshPorts.Enabled = txtSlaveId.Enabled = enable;

        // ИСПРАВЛЕНО: Кнопки команд (Tag) инвертируем (!enable). 
        // Когда настройки связи заблокированы (enable = false), кнопки команд становятся АКТИВНЫМИ (true)
        ToggleDynamicActionControls(this, !enable);
    }

    private void ToggleDynamicActionControls(Control parent, bool enable)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Tag != null && (c is Button || c is TextBox || c is ComboBox))
            {
                c.Enabled = enable;

                // Clear visual state background properties back to neutral system themes when going Offline
                if (c is TextBox tb && !enable && _currentDevice != null)
                {
                    // Check if this text box tracks a binary bit flag parameter
                    var matchedParam = _currentDevice.Parameters.Find(p => p.Name.Equals(tb.Tag.ToString(), StringComparison.OrdinalIgnoreCase));
                    if (matchedParam != null && matchedParam.DataType == ModbusDataType.Bit)
                    {
                        tb.Text = "Няма сувязі";
                        tb.BackColor = System.Drawing.SystemColors.Control; // System Grey
                        tb.ForeColor = System.Drawing.SystemColors.GrayText;
                    }
                }
            }
            if (c.HasChildren) ToggleDynamicActionControls(c, enable);
        }
    }
    private void ComDraw(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0 || sender is not ComboBox cb) return; e.DrawBackground();
        using StringFormat sf = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        using Brush b = new System.Drawing.SolidBrush((e.State & DrawItemState.Selected) == DrawItemState.Selected ? System.Drawing.Color.White : cb.ForeColor);
        e.Graphics.DrawString(cb.Items[e.Index].ToString()!, e.Font ?? cb.Font, b, e.Bounds, sf); e.DrawFocusRectangle();
    }

    private TextBox? FindBox(Control parent, string tag)
    {
        foreach (Control c in parent.Controls)
        {
            if (c is TextBox tb && tb.Tag != null && tb.Tag.ToString()!.Equals(tag, StringComparison.OrdinalIgnoreCase)) return tb;
            if (c.HasChildren) { var res = FindBox(c, tag); if (res != null) return res; }
        }
        return null;
    }

    private void btnStop_Click(object sender, EventArgs e) => StopPolling();
    private void StopPolling()
    {
        _isPolling = false; // Property trigger instantly neutralizes the loop execution thread

        btnStart.Enabled = true;
        btnStop.Enabled = false;
        cmbComPorts.Enabled = cmbBaudRates.Enabled = cmbPortMode.Enabled = btnRefreshPorts.Enabled = txtSlaveId.Enabled = true;

        // Explicitly set the label color and text on the main UI thread
        lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
        lblStatus.Text = "Опрос остановлен.";
    }
    protected override void OnFormClosing(FormClosingEventArgs e) { StopPolling(); base.OnFormClosing(e); }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }
    private async void UniversalComboBox_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (_currentDevice == null || sender is not ComboBox clickedCmb || clickedCmb.Tag == null) return;

        // --- NEW ONLINE SAFETY ENFORCEMENT INTERLOCK ---
        // If the background scanner loop is completely stopped, block the action instantly
        if (!_isPolling)
        {
            MessageBox.Show(
                "Змяненне параметраў немагчыма ў аўтаномным рэжыме!\nКалі ласка, запусціце апытанне (націсніце кнопку СТАРТ), каб перавесці прыбор у Анлайн.",
                "Элемент кіравання заблакіраваны",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            // Wipe selection back to unselected index since no valid device state is active
            clickedCmb.SelectedIndex = -1;
            return;
        }

        string paramName = clickedCmb.Tag.ToString()!;
        ModbusParameter? param = _currentDevice.Parameters.Find(p => p.Name.Equals(paramName, StringComparison.OrdinalIgnoreCase));
        if (param == null || clickedCmb.SelectedIndex == -1) return;

        var selectedEnumItem = param.EnumValues[clickedCmb.SelectedIndex];
        ushort targetRawValue = (ushort)selectedEnumItem.Key;

        // Safety Prompt Window Confirmation Intercept
        DialogResult confirm = MessageBox.Show(
            $"Пацвердзіце змяненне канфігурацыі:\n\n👉 Усталяваць '{param.Name}' у '{selectedEnumItem.Value}'?\n(Запіс сырога значэння {targetRawValue} у рэгістр {param.StartAddress})",
            "Пацвярджэнне запісу параметра",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning
        );

        if (confirm == DialogResult.Cancel)
        {
            // Operator rolled back option -> rollback active index presentation back to the known device state cache
            if (double.TryParse(param.Value.ToString(), out double rawNum))
            {
                clickedCmb.SelectedIndex = param.EnumValues.FindIndex(x => x.Key == (int)rawNum);
            }
            lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            lblStatus.Text = "Змяненне параметра адхілена.";
            return;
        }

        try
        {
            lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            lblStatus.Text = $"Перадача новай канфігурацыі для '{param.Name}'...";

            await _engine.WriteConstantOrVariableAsync(_currentDevice.SlaveId, param.StartAddress, targetRawValue);

            lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
            lblStatus.Text = $"Паспяхова абноўлена '{param.Name}' у рэгістры {param.StartAddress}.";
        }
        catch (Exception ex)
        {
            lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            lblStatus.Text = $"Збой транзакцыі Modbus: {ex.Message}";
            _engine.Disconnect();
        }
    }



    // 5. Add this little missing helper function too, which is used to scan ComboBox tag mappings
    private ComboBox? FindComboBoxByTag(Control parent, string tag)
    {
        foreach (Control c in parent.Controls)
        {
            if (c is ComboBox cb && cb.Tag != null && cb.Tag.ToString()!.Equals(tag, StringComparison.OrdinalIgnoreCase)) return cb;
            if (c.HasChildren) { var res = FindComboBoxByTag(c, tag); if (res != null) return res; }
        }
        return null;
    }

    private void label9_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void label12_Click(object sender, EventArgs e)
    {

    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void label14_Click(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void label30_Click(object sender, EventArgs e)
    {

    }

    private void label31_Click(object sender, EventArgs e)
    {

    }

    private void panel11_Paint(object sender, PaintEventArgs e)
    {

    }

    private void Form1_Load_1(object sender, EventArgs e)
    {

    }
}
