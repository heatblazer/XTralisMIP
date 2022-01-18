namespace XTralisIntegration.Admin
{
    partial class XTralisInegrationUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCOMPort = new System.Windows.Forms.Label();
            this.numericUpDownCOMPort = new System.Windows.Forms.NumericUpDown();
            this.checkBoxEnableSystem = new System.Windows.Forms.CheckBox();
            this.licenseInfoLabel = new System.Windows.Forms.Label();
            this.licenseInfoTextBox = new System.Windows.Forms.TextBox();
            this.configurationGroupBox = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelIPPort = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.comboBoxComInterface = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxProtocol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCOMPort)).BeginInit();
            this.configurationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(70, 26);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(301, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // labelCOMPort
            // 
            this.labelCOMPort.AutoSize = true;
            this.labelCOMPort.Location = new System.Drawing.Point(224, 83);
            this.labelCOMPort.Name = "labelCOMPort";
            this.labelCOMPort.Size = new System.Drawing.Size(56, 13);
            this.labelCOMPort.TabIndex = 4;
            this.labelCOMPort.Text = "COM Port:";
            // 
            // numericUpDownCOMPort
            // 
            this.numericUpDownCOMPort.Location = new System.Drawing.Point(286, 81);
            this.numericUpDownCOMPort.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownCOMPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCOMPort.Name = "numericUpDownCOMPort";
            this.numericUpDownCOMPort.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownCOMPort.TabIndex = 3;
            this.numericUpDownCOMPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxEnableSystem
            // 
            this.checkBoxEnableSystem.AutoSize = true;
            this.checkBoxEnableSystem.Location = new System.Drawing.Point(141, 30);
            this.checkBoxEnableSystem.Name = "checkBoxEnableSystem";
            this.checkBoxEnableSystem.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEnableSystem.TabIndex = 0;
            this.checkBoxEnableSystem.UseVisualStyleBackColor = true;
            // 
            // licenseInfoLabel
            // 
            this.licenseInfoLabel.AutoSize = true;
            this.licenseInfoLabel.Location = new System.Drawing.Point(26, 302);
            this.licenseInfoLabel.Name = "licenseInfoLabel";
            this.licenseInfoLabel.Size = new System.Drawing.Size(101, 13);
            this.licenseInfoLabel.TabIndex = 7;
            this.licenseInfoLabel.Text = "License information:";
            // 
            // licenseInfoTextBox
            // 
            this.licenseInfoTextBox.Location = new System.Drawing.Point(29, 318);
            this.licenseInfoTextBox.Multiline = true;
            this.licenseInfoTextBox.Name = "licenseInfoTextBox";
            this.licenseInfoTextBox.ReadOnly = true;
            this.licenseInfoTextBox.Size = new System.Drawing.Size(400, 122);
            this.licenseInfoTextBox.TabIndex = 8;
            // 
            // configurationGroupBox
            // 
            this.configurationGroupBox.Controls.Add(this.textBoxPassword);
            this.configurationGroupBox.Controls.Add(this.textBoxUsername);
            this.configurationGroupBox.Controls.Add(this.textBoxPort);
            this.configurationGroupBox.Controls.Add(this.textBoxIPAddress);
            this.configurationGroupBox.Controls.Add(this.labelPassword);
            this.configurationGroupBox.Controls.Add(this.labelUsername);
            this.configurationGroupBox.Controls.Add(this.labelIPPort);
            this.configurationGroupBox.Controls.Add(this.labelIPAddress);
            this.configurationGroupBox.Controls.Add(this.comboBoxComInterface);
            this.configurationGroupBox.Controls.Add(this.label5);
            this.configurationGroupBox.Controls.Add(this.comboBoxProtocol);
            this.configurationGroupBox.Controls.Add(this.label4);
            this.configurationGroupBox.Controls.Add(this.label3);
            this.configurationGroupBox.Controls.Add(this.checkBoxEnableSystem);
            this.configurationGroupBox.Controls.Add(this.labelCOMPort);
            this.configurationGroupBox.Controls.Add(this.numericUpDownCOMPort);
            this.configurationGroupBox.Location = new System.Drawing.Point(29, 67);
            this.configurationGroupBox.Name = "configurationGroupBox";
            this.configurationGroupBox.Size = new System.Drawing.Size(400, 223);
            this.configurationGroupBox.TabIndex = 9;
            this.configurationGroupBox.TabStop = false;
            this.configurationGroupBox.Text = "Configuration";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(141, 185);
            this.textBoxPassword.MaxLength = 16;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(201, 20);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(141, 159);
            this.textBoxUsername.MaxLength = 32;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(201, 20);
            this.textBoxUsername.TabIndex = 6;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(141, 133);
            this.textBoxPort.MaxLength = 5;
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(77, 20);
            this.textBoxPort.TabIndex = 5;
            this.textBoxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPort_KeyPress);
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(141, 107);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(201, 20);
            this.textBoxIPAddress.TabIndex = 4;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 188);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 15;
            this.labelPassword.Text = "Password:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(7, 162);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(61, 13);
            this.labelUsername.TabIndex = 14;
            this.labelUsername.Text = "User name:";
            // 
            // labelIPPort
            // 
            this.labelIPPort.AutoSize = true;
            this.labelIPPort.Location = new System.Drawing.Point(7, 136);
            this.labelIPPort.Name = "labelIPPort";
            this.labelIPPort.Size = new System.Drawing.Size(29, 13);
            this.labelIPPort.TabIndex = 13;
            this.labelIPPort.Text = "Port:";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(6, 110);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(60, 13);
            this.labelIPAddress.TabIndex = 12;
            this.labelIPAddress.Text = "IP address:";
            // 
            // comboBoxComInterface
            // 
            this.comboBoxComInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComInterface.FormattingEnabled = true;
            this.comboBoxComInterface.Items.AddRange(new object[] {
            "Serial",
            "TCP/IP"});
            this.comboBoxComInterface.Location = new System.Drawing.Point(141, 80);
            this.comboBoxComInterface.Name = "comboBoxComInterface";
            this.comboBoxComInterface.Size = new System.Drawing.Size(77, 21);
            this.comboBoxComInterface.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Communication interface:";
            // 
            // comboBoxProtocol
            // 
            this.comboBoxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProtocol.FormattingEnabled = true;
            this.comboBoxProtocol.Items.AddRange(new object[] {
            "Polling Protocol II (IPP)",
            "Remote Polling Module II (RPM)"});
            this.comboBoxProtocol.Location = new System.Drawing.Point(141, 53);
            this.comboBoxProtocol.Name = "comboBoxProtocol";
            this.comboBoxProtocol.Size = new System.Drawing.Size(201, 21);
            this.comboBoxProtocol.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Protocol:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enable system:";
            // 
            // SMI_IntrepidSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configurationGroupBox);
            this.Controls.Add(this.licenseInfoTextBox);
            this.Controls.Add(this.licenseInfoLabel);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Name = "SMI_IntrepidSystem";
            this.Size = new System.Drawing.Size(700, 500);
            this.Load += new System.EventHandler(this.SMI_IntrepidSystemControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCOMPort)).EndInit();
            this.configurationGroupBox.ResumeLayout(false);
            this.configurationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCOMPort;
        private System.Windows.Forms.NumericUpDown numericUpDownCOMPort;
        private System.Windows.Forms.CheckBox checkBoxEnableSystem;
        private System.Windows.Forms.Label licenseInfoLabel;
        private System.Windows.Forms.TextBox licenseInfoTextBox;
        private System.Windows.Forms.GroupBox configurationGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxComInterface;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxProtocol;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelIPPort;
        private System.Windows.Forms.Label labelIPAddress;


    }
}
