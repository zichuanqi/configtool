using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace configtool
{
    public partial class FrmValidate : Office2007Form
    {
        public static bool isTrial = true;
        private readonly string ConfigPath = AppDomain.CurrentDomain.BaseDirectory;

        public FrmValidate()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmValidate_Load(object sender, EventArgs e)
        {
            string macAddress = "";
            //获取网卡硬件地址
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    macAddress = mo["MacAddress"].ToString();
                    mo.Dispose();
                    break;
                }
            }
            txtCardInfo.Text = macAddress;

            string license = "";
            string configPath = ConfigPath + "license.xml";
            DataTable dt = new DataTable();
            if (!File.Exists(configPath))
            {
                dt.TableName = "LicenseTable";
                dt.Columns.Add("License", typeof(string));
                dt.WriteXmlSchema(configPath);
            }
            dt.ReadXml(configPath);
            if (dt.Rows.Count > 0)
            {
                license = dt.Rows[0][0].ToString();
            }
            txtLicense.Text = license;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtLicense.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please input the license.");
                return;
            }
            License lic = new License();
            string macAddress = lic.DecryptDES(txtLicense.Text.Trim());
            if (string.Equals(macAddress, txtCardInfo.Text.Trim()))
            {
                isTrial = false;
                string configPath = ConfigPath + "license.xml";
                DataTable dt = new DataTable();
                dt.ReadXml(configPath);
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0][0] = txtLicense.Text.Trim();
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = txtLicense.Text.Trim();
                    dt.Rows.Add(dr);
                }
                dt.WriteXml(configPath, XmlWriteMode.WriteSchema);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please input the correct license.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
