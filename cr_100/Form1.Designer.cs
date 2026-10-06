namespace cr_100
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            btnStop = new Button();
            lblStatus = new Label();
            btnRefreshPorts = new Button();
            cmbBaudRates = new ComboBox();
            cmbPortMode = new ComboBox();
            txtSlaveId = new TextBox();
            label1 = new Label();
            cmbComPorts = new ComboBox();
            cmb_DO_1_Mode = new ComboBox();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label11 = new Label();
            label13 = new Label();
            textBox4 = new TextBox();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            textBox5 = new TextBox();
            label17 = new Label();
            textBox6 = new TextBox();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1 = new Panel();
            label5 = new Label();
            textBox3 = new TextBox();
            panel4 = new Panel();
            textBox7 = new TextBox();
            label12 = new Label();
            label18 = new Label();
            label19 = new Label();
            textBox8 = new TextBox();
            label20 = new Label();
            textBox9 = new TextBox();
            panel5 = new Panel();
            label21 = new Label();
            label22 = new Label();
            textBox10 = new TextBox();
            label23 = new Label();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label25 = new Label();
            comboBox1 = new ComboBox();
            label27 = new Label();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            label28 = new Label();
            panel9 = new Panel();
            textBox15 = new TextBox();
            label29 = new Label();
            comboBox2 = new ComboBox();
            label30 = new Label();
            comboBox3 = new ComboBox();
            label31 = new Label();
            panel10 = new Panel();
            label32 = new Label();
            textBox17 = new TextBox();
            label2 = new Label();
            label34 = new Label();
            label33 = new Label();
            label4 = new Label();
            textBox16 = new TextBox();
            btnCalibrate_0 = new Button();
            calibrate_1_val = new TextBox();
            btnCalibrate_1 = new Button();
            panel11 = new Panel();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(44, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 33);
            btnStart.TabIndex = 0;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(163, 12);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(112, 33);
            btnStop.TabIndex = 1;
            btnStop.Text = "Стоп";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(44, 56);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(181, 25);
            lblStatus.TabIndex = 7;
            lblStatus.Text = " Ожидание запуска...";
            // 
            // btnRefreshPorts
            // 
            btnRefreshPorts.Location = new Point(289, 12);
            btnRefreshPorts.Name = "btnRefreshPorts";
            btnRefreshPorts.Size = new Size(35, 33);
            btnRefreshPorts.TabIndex = 12;
            btnRefreshPorts.Text = "🔄";
            btnRefreshPorts.UseVisualStyleBackColor = true;
            // 
            // cmbBaudRates
            // 
            cmbBaudRates.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBaudRates.FormattingEnabled = true;
            cmbBaudRates.Items.AddRange(new object[] { "9600", "19200", "57600", "115200" });
            cmbBaudRates.Location = new Point(445, 12);
            cmbBaudRates.Name = "cmbBaudRates";
            cmbBaudRates.Size = new Size(114, 33);
            cmbBaudRates.TabIndex = 13;
            // 
            // cmbPortMode
            // 
            cmbPortMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPortMode.FormattingEnabled = true;
            cmbPortMode.Items.AddRange(new object[] { "8-N-1", "8-N-2", "8-Even-1", "8-Odd-1" });
            cmbPortMode.Location = new Point(566, 12);
            cmbPortMode.Name = "cmbPortMode";
            cmbPortMode.Size = new Size(114, 33);
            cmbPortMode.TabIndex = 14;
            // 
            // txtSlaveId
            // 
            txtSlaveId.Location = new Point(800, 13);
            txtSlaveId.Name = "txtSlaveId";
            txtSlaveId.Size = new Size(114, 31);
            txtSlaveId.TabIndex = 15;
            txtSlaveId.Text = "1";
            txtSlaveId.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(698, 16);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 16;
            label1.Text = "Modbus ID:";
            // 
            // cmbComPorts
            // 
            cmbComPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbComPorts.FormattingEnabled = true;
            cmbComPorts.Location = new Point(324, 12);
            cmbComPorts.Name = "cmbComPorts";
            cmbComPorts.Size = new Size(114, 33);
            cmbComPorts.TabIndex = 18;
            // 
            // cmb_DO_1_Mode
            // 
            cmb_DO_1_Mode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_DO_1_Mode.FormattingEnabled = true;
            cmb_DO_1_Mode.Location = new Point(430, 171);
            cmb_DO_1_Mode.Name = "cmb_DO_1_Mode";
            cmb_DO_1_Mode.Size = new Size(322, 33);
            cmb_DO_1_Mode.TabIndex = 19;
            cmb_DO_1_Mode.Tag = "DO_1_Mode";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(53, 123);
            label6.Name = "label6";
            label6.Size = new Size(174, 25);
            label6.TabIndex = 20;
            label6.Text = "Вымераны ток RMS";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Click += label6_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(490, 99);
            label8.Name = "label8";
            label8.Size = new Size(207, 25);
            label8.TabIndex = 18;
            label8.Text = "Дыскрэтны выхад DO-1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(436, 218);
            label9.Name = "label9";
            label9.Size = new Size(175, 50);
            label9.TabIndex = 22;
            label9.Text = "Кіраванне\r\n(у Modbus рэжыме)";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            label9.Click += label9_Click;
            // 
            // button1
            // 
            button1.Location = new Point(607, 243);
            button1.Name = "button1";
            button1.Size = new Size(133, 34);
            button1.TabIndex = 21;
            button1.Tag = "Set ON DO_1";
            button1.Text = "Уключыць";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(609, 210);
            button2.Name = "button2";
            button2.Size = new Size(131, 34);
            button2.TabIndex = 23;
            button2.Tag = "Set OFF DO_1";
            button2.Text = "Адключыць";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(430, 137);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(322, 31);
            textBox1.TabIndex = 25;
            textBox1.Tag = "Status: DO - 1 (Bit 0)";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.Location = new Point(607, 379);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(133, 31);
            textBox2.TabIndex = 21;
            textBox2.Tag = "Устаўка ўключэння DO-1";
            textBox2.Text = "---";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(551, 382);
            label11.Name = "label11";
            label11.Size = new Size(41, 25);
            label11.TabIndex = 26;
            label11.Text = "Ток";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(502, 415);
            label13.Name = "label13";
            label13.Size = new Size(93, 25);
            label13.TabIndex = 30;
            label13.Text = "Затрымка";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Window;
            textBox4.Location = new Point(607, 413);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(133, 31);
            textBox4.TabIndex = 29;
            textBox4.Tag = "Затрымка ўключэння DO-1";
            textBox4.Text = "---";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(542, 350);
            label14.Name = "label14";
            label14.Size = new Size(102, 25);
            label14.TabIndex = 32;
            label14.Text = "Уключэнне";
            label14.Click += label14_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(536, 458);
            label15.Name = "label15";
            label15.Size = new Size(114, 25);
            label15.TabIndex = 38;
            label15.Text = "Адключэнне";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(502, 523);
            label16.Name = "label16";
            label16.Size = new Size(93, 25);
            label16.TabIndex = 36;
            label16.Text = "Затрымка";
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.Location = new Point(607, 521);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(133, 31);
            textBox5.TabIndex = 35;
            textBox5.Tag = "Затрымка адключэння DO-1";
            textBox5.Text = "---";
            textBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(551, 490);
            label17.Name = "label17";
            label17.Size = new Size(41, 25);
            label17.TabIndex = 34;
            label17.Text = "Ток";
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.Location = new Point(607, 487);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(133, 31);
            textBox6.TabIndex = 33;
            textBox6.Tag = "Устаўка адключэння DO-1";
            textBox6.Text = "---";
            textBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(418, 470);
            panel2.Name = "panel2";
            panel2.Size = new Size(344, 98);
            panel2.TabIndex = 37;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(418, 295);
            panel3.Name = "panel3";
            panel3.Size = new Size(344, 273);
            panel3.TabIndex = 32;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(418, 362);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 206);
            panel1.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(545, 282);
            label5.Name = "label5";
            label5.Size = new Size(97, 25);
            label5.TabIndex = 39;
            label5.Text = "Засцярога";
            label5.Click += label5_Click;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(445, 314);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(295, 31);
            textBox3.TabIndex = 40;
            textBox3.Tag = "Аварыя устаўка-1 (bit 0)";
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Location = new Point(418, 113);
            panel4.Name = "panel4";
            panel4.Size = new Size(344, 455);
            panel4.TabIndex = 33;
            // 
            // textBox7
            // 
            textBox7.BorderStyle = BorderStyle.FixedSingle;
            textBox7.Location = new Point(818, 314);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(295, 31);
            textBox7.TabIndex = 64;
            textBox7.Tag = "Аварыя устаўка-2 (bit 1)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(918, 282);
            label12.Name = "label12";
            label12.Size = new Size(97, 25);
            label12.TabIndex = 63;
            label12.Text = "Засцярога";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(909, 458);
            label18.Name = "label18";
            label18.Size = new Size(114, 25);
            label18.TabIndex = 62;
            label18.Text = "Адключэнне";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(875, 523);
            label19.Name = "label19";
            label19.Size = new Size(93, 25);
            label19.TabIndex = 60;
            label19.Text = "Затрымка";
            // 
            // textBox8
            // 
            textBox8.BackColor = SystemColors.Window;
            textBox8.Location = new Point(980, 521);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(133, 31);
            textBox8.TabIndex = 59;
            textBox8.Tag = "Затрымка адключэння DO-2";
            textBox8.Text = "---";
            textBox8.TextAlign = HorizontalAlignment.Center;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(924, 490);
            label20.Name = "label20";
            label20.Size = new Size(41, 25);
            label20.TabIndex = 58;
            label20.Text = "Ток";
            // 
            // textBox9
            // 
            textBox9.BackColor = SystemColors.Window;
            textBox9.Location = new Point(980, 487);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(133, 31);
            textBox9.TabIndex = 57;
            textBox9.Tag = "Устаўка адключэння DO-2";
            textBox9.Text = "---";
            textBox9.TextAlign = HorizontalAlignment.Center;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Location = new Point(792, 470);
            panel5.Name = "panel5";
            panel5.Size = new Size(343, 98);
            panel5.TabIndex = 61;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(915, 350);
            label21.Name = "label21";
            label21.Size = new Size(102, 25);
            label21.TabIndex = 54;
            label21.Text = "Уключэнне";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(875, 415);
            label22.Name = "label22";
            label22.Size = new Size(93, 25);
            label22.TabIndex = 52;
            label22.Text = "Затрымка";
            // 
            // textBox10
            // 
            textBox10.BackColor = SystemColors.Window;
            textBox10.Location = new Point(980, 413);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(133, 31);
            textBox10.TabIndex = 51;
            textBox10.Tag = "Затрымка ўключэння DO-2";
            textBox10.Text = "---";
            textBox10.TextAlign = HorizontalAlignment.Center;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(924, 382);
            label23.Name = "label23";
            label23.Size = new Size(41, 25);
            label23.TabIndex = 50;
            label23.Text = "Ток";
            // 
            // textBox11
            // 
            textBox11.BackColor = SystemColors.Window;
            textBox11.Location = new Point(980, 379);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(133, 31);
            textBox11.TabIndex = 45;
            textBox11.Tag = "Устаўка ўключэння DO-2";
            textBox11.Text = "---";
            textBox11.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            textBox12.BorderStyle = BorderStyle.FixedSingle;
            textBox12.Location = new Point(9, 23);
            textBox12.Name = "textBox12";
            textBox12.ReadOnly = true;
            textBox12.Size = new Size(322, 31);
            textBox12.TabIndex = 49;
            textBox12.Tag = "Status: DO - 2 (Bit 1)";
            // 
            // button3
            // 
            button3.Location = new Point(982, 210);
            button3.Name = "button3";
            button3.Size = new Size(131, 34);
            button3.TabIndex = 47;
            button3.Tag = "Set OFF DO_2";
            button3.Text = "Адключыць";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(980, 243);
            button4.Name = "button4";
            button4.Size = new Size(133, 34);
            button4.TabIndex = 44;
            button4.Tag = "Set ON DO_2";
            button4.Text = "Уключыць";
            button4.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(809, 218);
            label25.Name = "label25";
            label25.Size = new Size(175, 50);
            label25.TabIndex = 46;
            label25.Text = "Кіраванне\r\n(у Modbus рэжыме)";
            label25.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(802, 171);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(322, 33);
            comboBox1.TabIndex = 42;
            comboBox1.Tag = "DO_2_Mode";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(863, 99);
            label27.Name = "label27";
            label27.Size = new Size(207, 25);
            label27.TabIndex = 41;
            label27.Text = "Дыскрэтны выхад DO-2";
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Location = new Point(792, 362);
            panel6.Name = "panel6";
            panel6.Size = new Size(343, 206);
            panel6.TabIndex = 53;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Location = new Point(792, 295);
            panel7.Name = "panel7";
            panel7.Size = new Size(343, 273);
            panel7.TabIndex = 55;
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(textBox12);
            panel8.Location = new Point(792, 113);
            panel8.Name = "panel8";
            panel8.Size = new Size(343, 455);
            panel8.TabIndex = 56;
            // 
            // textBox13
            // 
            textBox13.BackColor = SystemColors.Window;
            textBox13.Location = new Point(184, 6);
            textBox13.Name = "textBox13";
            textBox13.ReadOnly = true;
            textBox13.Size = new Size(133, 31);
            textBox13.TabIndex = 65;
            textBox13.Tag = "Ток RMS";
            textBox13.Text = "---";
            textBox13.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox14
            // 
            textBox14.BackColor = SystemColors.Window;
            textBox14.Location = new Point(184, 43);
            textBox14.Name = "textBox14";
            textBox14.ReadOnly = true;
            textBox14.Size = new Size(133, 31);
            textBox14.TabIndex = 67;
            textBox14.Tag = "Ток сярэдні";
            textBox14.Text = "---";
            textBox14.TextAlign = HorizontalAlignment.Center;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(63, 158);
            label28.Name = "label28";
            label28.Size = new Size(161, 25);
            label28.TabIndex = 66;
            label28.Text = "Вымераны ток DC";
            label28.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(textBox14);
            panel9.Controls.Add(textBox13);
            panel9.Location = new Point(43, 113);
            panel9.Name = "panel9";
            panel9.Size = new Size(338, 82);
            panel9.TabIndex = 34;
            // 
            // textBox15
            // 
            textBox15.BackColor = SystemColors.Window;
            textBox15.Location = new Point(226, 239);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(131, 31);
            textBox15.TabIndex = 67;
            textBox15.Tag = "Addr";
            textBox15.Text = "---";
            textBox15.TextAlign = HorizontalAlignment.Center;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(86, 241);
            label29.Name = "label29";
            label29.Size = new Size(134, 25);
            label29.TabIndex = 68;
            label29.Text = "Адрас modbus";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(182, 48);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(131, 33);
            comboBox2.TabIndex = 69;
            comboBox2.Tag = "Baud";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(100, 51);
            label30.Name = "label30";
            label30.Size = new Size(74, 25);
            label30.TabIndex = 69;
            label30.Text = "Фармат";
            label30.Click += label30_Click;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(182, 85);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(131, 33);
            comboBox3.TabIndex = 70;
            comboBox3.Tag = "Parity";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(84, 88);
            label31.Name = "label31";
            label31.Size = new Size(90, 25);
            label31.TabIndex = 71;
            label31.Text = "Цотнасць";
            label31.Click += label31_Click;
            // 
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(label31);
            panel10.Controls.Add(comboBox3);
            panel10.Controls.Add(label30);
            panel10.Controls.Add(comboBox2);
            panel10.Location = new Point(43, 226);
            panel10.Name = "panel10";
            panel10.Size = new Size(338, 125);
            panel10.TabIndex = 57;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(143, 209);
            label32.Name = "label32";
            label32.Size = new Size(138, 25);
            label32.TabIndex = 69;
            label32.Text = "Налады RS-485";
            // 
            // textBox17
            // 
            textBox17.BackColor = SystemColors.Window;
            textBox17.Location = new Point(164, 391);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(200, 31);
            textBox17.TabIndex = 82;
            textBox17.Tag = "ADC_K";
            textBox17.Text = "---";
            textBox17.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 363);
            label2.Name = "label2";
            label2.Size = new Size(103, 25);
            label2.TabIndex = 77;
            label2.Text = "Каліброўка";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(56, 395);
            label34.Name = "label34";
            label34.Size = new Size(88, 25);
            label34.TabIndex = 83;
            label34.Text = "К фільтра";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(45, 428);
            label33.Name = "label33";
            label33.Size = new Size(120, 25);
            label33.TabIndex = 81;
            label33.Text = "ADC (0-4096)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 120);
            label4.Name = "label4";
            label4.Size = new Size(273, 25);
            label4.TabIndex = 79;
            label4.Text = "Намінальны (калібровачны) ток";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox16
            // 
            textBox16.BackColor = SystemColors.Window;
            textBox16.Location = new Point(164, 427);
            textBox16.Name = "textBox16";
            textBox16.ReadOnly = true;
            textBox16.Size = new Size(200, 31);
            textBox16.TabIndex = 80;
            textBox16.Tag = "ADC_FILTERED";
            textBox16.Text = "---";
            textBox16.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCalibrate_0
            // 
            btnCalibrate_0.Location = new Point(56, 461);
            btnCalibrate_0.Name = "btnCalibrate_0";
            btnCalibrate_0.Size = new Size(308, 31);
            btnCalibrate_0.TabIndex = 74;
            btnCalibrate_0.Tag = "start calibration 0";
            btnCalibrate_0.Text = "каліброўка нуля";
            btnCalibrate_0.UseVisualStyleBackColor = true;
            // 
            // calibrate_1_val
            // 
            calibrate_1_val.BackColor = SystemColors.Window;
            calibrate_1_val.Location = new Point(21, 150);
            calibrate_1_val.Name = "calibrate_1_val";
            calibrate_1_val.Size = new Size(142, 31);
            calibrate_1_val.TabIndex = 76;
            calibrate_1_val.Tag = "calibration 1 value";
            calibrate_1_val.Text = "---";
            calibrate_1_val.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCalibrate_1
            // 
            btnCalibrate_1.Location = new Point(178, 148);
            btnCalibrate_1.Name = "btnCalibrate_1";
            btnCalibrate_1.Size = new Size(142, 34);
            btnCalibrate_1.TabIndex = 75;
            btnCalibrate_1.Tag = "start calibration 1";
            btnCalibrate_1.Text = "каліброўка In";
            btnCalibrate_1.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(btnCalibrate_1);
            panel11.Controls.Add(calibrate_1_val);
            panel11.Controls.Add(label4);
            panel11.Location = new Point(43, 379);
            panel11.Name = "panel11";
            panel11.Size = new Size(338, 189);
            panel11.TabIndex = 33;
            panel11.Paint += panel11_Paint;
            // 
            // button5
            // 
            button5.Location = new Point(952, 585);
            button5.Name = "button5";
            button5.Size = new Size(183, 34);
            button5.TabIndex = 80;
            button5.Tag = "default";
            button5.Text = "завадскія налады";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(753, 585);
            button6.Name = "button6";
            button6.Size = new Size(183, 34);
            button6.TabIndex = 84;
            button6.Tag = "restart";
            button6.Text = "перазагрузка";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(41, 585);
            button7.Name = "button7";
            button7.Size = new Size(183, 34);
            button7.TabIndex = 85;
            button7.Tag = "Alarm notify reset";
            button7.Text = "сброс апавяшчэння";
            button7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 644);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(textBox17);
            Controls.Add(label2);
            Controls.Add(label34);
            Controls.Add(label33);
            Controls.Add(textBox16);
            Controls.Add(btnCalibrate_0);
            Controls.Add(label32);
            Controls.Add(label29);
            Controls.Add(textBox15);
            Controls.Add(label28);
            Controls.Add(textBox7);
            Controls.Add(label12);
            Controls.Add(label18);
            Controls.Add(label19);
            Controls.Add(textBox8);
            Controls.Add(label20);
            Controls.Add(textBox9);
            Controls.Add(panel5);
            Controls.Add(label21);
            Controls.Add(label22);
            Controls.Add(textBox10);
            Controls.Add(label23);
            Controls.Add(textBox11);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(label25);
            Controls.Add(comboBox1);
            Controls.Add(label27);
            Controls.Add(panel6);
            Controls.Add(panel7);
            Controls.Add(panel8);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(textBox5);
            Controls.Add(label17);
            Controls.Add(textBox6);
            Controls.Add(panel2);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(textBox4);
            Controls.Add(label11);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(cmb_DO_1_Mode);
            Controls.Add(label8);
            Controls.Add(cmbComPorts);
            Controls.Add(label1);
            Controls.Add(txtSlaveId);
            Controls.Add(cmbPortMode);
            Controls.Add(cmbBaudRates);
            Controls.Add(btnRefreshPorts);
            Controls.Add(lblStatus);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel9);
            Controls.Add(panel10);
            Controls.Add(panel11);
            Name = "Form1";
            Text = "cr_100";
            Load += Form1_Load_1;
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Label lblStatus;
        private ComboBox cmbComPorts;
        private Button btnRefreshPorts;
        private ComboBox cmbBaudRates;
        private ComboBox cmbPortMode;
        private TextBox txtSlaveId;
        private Label label1;
        private ComboBox cmb_DO_1_Mode;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button button1;
        private Button button2;
        private Label label10;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label11;
        private Label label13;
        private TextBox textBox4;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox textBox5;
        private Label label17;
        private TextBox textBox6;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private Label label5;
        private TextBox textBox3;
        private Panel panel4;
        private TextBox textBox7;
        private Label label12;
        private Label label18;
        private Label label19;
        private TextBox textBox8;
        private Label label20;
        private TextBox textBox9;
        private Panel panel5;
        private Label label21;
        private Label label22;
        private TextBox textBox10;
        private Label label23;
        private TextBox textBox11;
        private TextBox textBox12;
        private Label label24;
        private Button button3;
        private Button button4;
        private Label label25;
        private Label label26;
        private ComboBox comboBox1;
        private Label label27;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private TextBox textBox13;
        private TextBox textBox14;
        private Label label28;
        private Panel panel9;
        private TextBox textBox15;
        private Label label29;
        private ComboBox comboBox2;
        private Label label30;
        private ComboBox comboBox3;
        private Label label31;
        private Panel panel10;
        private Label label32;
        private TextBox textBox17;
        private Label label2;
        private Label label34;
        private Label label33;
        private Label label4;
        private TextBox textBox16;
        private Label label3;
        private Button btnCalibrate_0;
        private TextBox calibrate_1_val;
        private Button btnCalibrate_1;
        private Panel panel11;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
