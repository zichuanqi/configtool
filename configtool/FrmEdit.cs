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
    public partial class FrmEdit : Office2007Form
    {
        private readonly string ConfigPath = AppDomain.CurrentDomain.BaseDirectory;
        private string tagName;
        private DataTable dt;
        private string dbName;
        public FrmEdit(string _tagName, DataTable _dt, string _dbName)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;

            this.tagName = _tagName;
            this.dt = _dt;
            this.dbName = _dbName;

            this.Text = tagName + " - Edit";
        }

        private void FrmEdit_Load(object sender, EventArgs e)
        {
            DataRow[] drArray = dt.Select(string.Format("TagName='{0}'", tagName));
            if (drArray.Length > 0)
            {
                DataRow dr = drArray[0];
                int selectedIndex = -1;
                for (int i = 0; i < combCondition.Items.Count; i++)
                {
                    if (combCondition.Items[i].ToString() == dr["Condition"].ToString())
                    {
                        selectedIndex = i;
                    }
                }
                combCondition.SelectedIndex = selectedIndex;
                txtSQL.Text = dr["SQL"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (combCondition.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the condition.");
                return;
            }
            if (txtSQL.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please input the sql.");
                return;
            }

            DataRow[] drArray = dt.Select(string.Format("TagName='{0}'", tagName));
            if (drArray.Length > 0)
            {
                DataRow dr = drArray[0];

                WebAccessAPI api = new WebAccessAPI();
                string tagValue = api.GetTagValueByTagName(tagName);

                string sql = DBHelper.GetSQL(txtSQL.Text.Trim(), tagName, tagValue, dt);

                DataTable dbTable = new DataTable();
                string dbPath = ConfigPath + "Databases.xml";
                dbTable.ReadXml(dbPath);

                string connectString = "";
                string connectType = "";
                DBHelper.GetConnetString(dbTable, dbName, out connectType, out connectString);

                string errMsg = "";
                bool flag = false;
                if (connectType == "oracle")
                {
                    flag = DBHelper.OracleTestExtcuteSQL(connectString, sql, out errMsg);
                }
                else if (connectType == "sqlserver")
                {
                    flag = DBHelper.SqlTestExtcuteSQL(connectString, sql, out errMsg);
                }
                if (!flag)
                {
                    MessageBox.Show("Sql validate failed:\n" + errMsg);
                    return;
                }

                dr["Condition"] = combCondition.SelectedItem.ToString();
                dr["SQL"] = txtSQL.Text.Trim();
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
