using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VideoOS.Platform;

namespace XTralisIntegration.Admin
{
    public partial class XTralisInegrationUserControl : UserControl
    {
        internal event EventHandler ConfigurationChangedByUser;

        public XTralisInegrationUserControl()
        {
            InitializeComponent();
        }

        private void SMI_IntrepidSystemControl_Load(object sender, EventArgs e)
        {
            // Assign OnUserChange event handler in order to signal that changes have occured
            textBoxName.TextChanged += new EventHandler(OnUserChange);
            checkBoxEnableSystem.CheckedChanged += new EventHandler(OnUserChange);
            comboBoxProtocol.SelectedIndexChanged += new EventHandler(OnUserChange);
            comboBoxComInterface.SelectedIndexChanged += new EventHandler(OnUserChange);
            numericUpDownCOMPort.ValueChanged += new EventHandler(OnUserChange);
            textBoxIPAddress.TextChanged += new EventHandler(OnUserChange);
            textBoxPort.TextChanged += new EventHandler(OnUserChange);
            textBoxUsername.TextChanged += new EventHandler(OnUserChange);
            textBoxPassword.TextChanged += new EventHandler(OnUserChange);
        }

        internal String DisplayName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        internal bool SystemEnabled
        {
            get { return checkBoxEnableSystem.Checked; }
        }

        internal int CurrentProtocolType
        {
            get { return comboBoxProtocol.SelectedIndex; }
        }

        internal int CurrentCommunicationType
        {
            get { return comboBoxComInterface.SelectedIndex; }
        }

        internal String CurrentIPAddress
        {
            get { return textBoxIPAddress.Text; }
        }

        internal String CurrentIPPort
        {
            get { return textBoxPort.Text; }
        }

        internal String CurrentCOMPortNumber
        {
            get { return (numericUpDownCOMPort.Value).ToString(); }
        }


        internal void UpdateLicense(Item item)
        {
        }

        /// <summary>
        /// Ensure that all user entries will call this method to enable the Save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void OnUserChange(object sender, EventArgs e)
        {
            if (ConfigurationChangedByUser != null)
                ConfigurationChangedByUser(this, new EventArgs());
        }

        internal void FillContent(Item item)
        {
            textBoxName.Text = item.Name;
            string strValue;

            // Reset the enable state
            checkBoxEnableSystem.Enabled = true;

            // Refresh the controls to resolve visible dependencies...
            comboBoxComInterface.SelectedIndexChanged += refreshControlAvailability;
            comboBoxProtocol.SelectedIndexChanged += refreshControlAvailability;
            refreshControlAvailability(null, EventArgs.Empty);

            UpdateLicense(item);
        }

        private void FillComboBoxSelection(Item item, ComboBox comboBox, string propertyName)
        {
            string strValue;
            if (item.Properties.TryGetValue(propertyName, out strValue))
            {
                int numValue;
                if (Int32.TryParse(strValue, out numValue) && numValue < comboBox.Items.Count)
                    comboBox.SelectedIndex = numValue;
            }
            else
            {
                comboBox.SelectedIndex = -1;
            }

        }

        internal void UpdateItem(Item item)
        {
            item.Name = DisplayName;

            // Fill in any properties that should be saved:
        }

        internal void ClearContent()
        {
            comboBoxComInterface.SelectedIndexChanged -= refreshControlAvailability;
            comboBoxProtocol.SelectedIndexChanged -= refreshControlAvailability;

            textBoxName.Name = "";
            checkBoxEnableSystem.Checked = true;
            comboBoxProtocol.SelectedIndex = -1;
            comboBoxComInterface.SelectedIndex = -1;
            numericUpDownCOMPort.Value = numericUpDownCOMPort.Minimum;
            textBoxIPAddress.Text = string.Empty;
            textBoxPort.Text = string.Empty;
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
        }

        private void refreshControlAvailability(object sender, EventArgs e)
        {
            // RPM only works with TCP/IP
            bool bRPMEnabled = false;
            if (comboBoxProtocol.SelectedIndex == 1)
            {
                if (comboBoxComInterface.SelectedIndex != 1)
                {
                    comboBoxComInterface.SelectedIndex = 1;
                    comboBoxComInterface.Enabled = false;
                }
                bRPMEnabled = true;
            }
            comboBoxComInterface.Enabled = !bRPMEnabled;

            // RPM uses credetials
            labelUsername.Visible = bRPMEnabled;
            labelPassword.Visible = bRPMEnabled;
            textBoxUsername.Visible = bRPMEnabled;
            textBoxPassword.Visible = bRPMEnabled;

            // Index: 0 -> serial, 1 -> TCP/IP
            bool bSerialEnable = comboBoxComInterface.SelectedIndex == 0;
            bool bTCPEnable = comboBoxComInterface.SelectedIndex == 1;

            // Serial
            labelCOMPort.Visible = bSerialEnable;
            numericUpDownCOMPort.Visible = bSerialEnable;

            // TCP/IP
            labelIPAddress.Visible = bTCPEnable;
            labelIPPort.Visible = bTCPEnable;
            textBoxIPAddress.Visible = bTCPEnable;
            textBoxPort.Visible = bTCPEnable;
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



    }
}
