using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace configtool
{
    public partial class FrmDB : Office2007Form
    {
        private readonly string ConfigPath = AppDomain.CurrentDomain.BaseDirectory;
        private string dbName = "";
        public FrmDB(string _name)
        {
            InitializeComponent();

            this.dbName = _name;

            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmDB_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dbName))
            {
                DataTable dt = new DataTable();
                string dbPath = ConfigPath + "Databases.xml";
                dt.ReadXml(dbPath);
                DataRow[] drArray = dt.Select(string.Format("Name='{0}'", dbName));
                if (drArray.Length > 0)
                {
                    DataRow dr = drArray[0];
                    txtName.Text = dbName;
                    txtServer.Text = dr["Server"].ToString();
                    txtDB.Text = dr["Database"].ToString();
                    txtUsername.Text = dr["Username"].ToString();
                    txtPwd.Text = dr["Password"].ToString();
                    int selectedIndex = -1;
                    for (int i = 0; i < combType.Items.Count; i++)
                    {
                        if (combType.Items[i].ToString() == dr["Type"].ToString())
                        {
                            selectedIndex = i;
                        }
                    }
                    combType.SelectedIndex = selectedIndex;

                    txtName.Enabled = false;
                }
            }
            else
            {
                combType.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string type = combType.SelectedItem.ToString();
            string server = txtServer.Text.Trim();
            string db = txtDB.Text.Trim();
            string username = txtUsername.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please input the name.");
                return;
            }
            if (combType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the type.");
                return;
            }
            if (string.IsNullOrWhiteSpace(server))
            {
                MessageBox.Show("Please input the server.");
                return;
            }
            if (string.IsNullOrWhiteSpace(db))
            {
                MessageBox.Show("Please input the database.");
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please input the user name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(pwd))
            {
                MessageBox.Show("Please input the password.");
                return;
            }

            string errMsg = "";
            bool ret = false;
            if (type.ToLower() == "oracle")
            {
                string connectString = DBHelper.GetOracleConnetString(server, db, username, pwd);
                ret = DBHelper.OracleTestConnect(connectString, out errMsg);
            }
            else if (type.ToLower() == "sqlserver")
            {
                string connectString = DBHelper.GetSqlConnetString(server, db, username, pwd);
                ret = DBHelper.SqlTestConnect(connectString, out errMsg);
            }
            if (!ret)
            {
                MessageBox.Show(string.Format("Connect failed:\n{0}.", errMsg));
                return;
            }

            DataTable dt = new DataTable();
            string dbPath = ConfigPath + "Databases.xml";
            dt.ReadXml(dbPath);
            if (!string.IsNullOrWhiteSpace(dbName))
            {//修改
                DataRow[] drArray = dt.Select(string.Format("Name='{0}'", dbName));
                if (drArray.Length > 0)
                {
                    DataRow dr = drArray[0];
                    dr["Type"] = type;
                    dr["Server"] = server;
                    dr["Database"] = db;
                    dr["Username"] = username;
                    dr["Password"] = pwd;
                    string configPath = ConfigPath + "Databases.xml";
                    dt.WriteXml(configPath, XmlWriteMode.WriteSchema);

                    MessageBox.Show("Save succeed.");
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                DataRow[] drArray = dt.Select(string.Format("Name='{0}'", name));
                if (drArray.Length > 0)
                {
                    MessageBox.Show("The name already exists.");
                    return;
                }
                DataRow dr = dt.NewRow();
                dr["Name"] = name;
                dr["Type"] = type;
                dr["Server"] = server;
                dr["Database"] = db;
                dr["Username"] = username;
                dr["Password"] = pwd;
                dt.Rows.Add(dr);
                string configPath = ConfigPath + "Databases.xml";
                dt.WriteXml(configPath, XmlWriteMode.WriteSchema);

                MessageBox.Show("Save succeed.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
