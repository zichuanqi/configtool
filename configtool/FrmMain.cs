using DevComponents.DotNetBar;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace configtool
{
    public partial class FrmMain : Office2007Form
    {
        private static log4net.ILog LogInfo = log4net.LogManager.GetLogger("logInfo");
        private static readonly string ConfigPath = AppDomain.CurrentDomain.BaseDirectory;
        WebAccessAPI WsAPI = new WebAccessAPI();
        private static DataTable SelectedTagTable = new DataTable();
        private static object CheckMainLockObject = new Object();
        private static int CheckMainCheckUpDateLock = 0;
        private static string DbConnectString = "";
        private static string DbConnectType = "";

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Common Funtions

        private void DatabaseBind()
        {
            DataTable dt = new DataTable();
            string dbPath = ConfigPath + "Databases.xml";
            if (!File.Exists(dbPath))
            {
                dt.TableName = "Databases";
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("Server", typeof(string));
                dt.Columns.Add("Database", typeof(string));
                dt.Columns.Add("Username", typeof(string));
                dt.Columns.Add("Password", typeof(string));
                dt.WriteXmlSchema(dbPath);
            }
            dt.ReadXml(dbPath);
            combDB.DataSource = dt;
            combDB.DisplayMember = "Name";
            combDB.ValueMember = "Name";

            if (SelectedTagTable.Rows.Count > 0)
            {
                combDB.SelectedValue = SelectedTagTable.Rows[0]["DSN"].ToString();
                DBHelper.GetConnetString(dt, combDB.SelectedValue.ToString(), out DbConnectType, out DbConnectString);
            }
            else
            {
                combDB.SelectedIndex = -1;
            }
        }

        private void TagListBind()
        {
            WebAccessAPI api = new WebAccessAPI();
            string[] list = api.GetAllAlarmTagList();

            DataTable dt = new DataTable();
            dt.Columns.Add("operate", typeof(bool));
            dt.Columns.Add("name", typeof(string));
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                bool isChecked = false;
                if (SelectedTagTable.Select(string.Format("TagName='{0}'", item)).Length > 0)
                {
                    isChecked = true;
                }
                dr[0] = isChecked;
                dr[1] = item;
                dt.Rows.Add(dr);
            }
            dataGridViewTagList.DataSource = dt;
        }

        private void SelectedTagTableBind()
        {
            dataGridViewSelectedTag.DataSource = SelectedTagTable;
        }

        private void InintSelectedTagTable()
        {
            string configPath = ConfigPath + "SelectedTagConfig.xml";
            if (!File.Exists(configPath))
            {
                SelectedTagTable.TableName = "SelectedTag";
                SelectedTagTable.Columns.Add("DSN", typeof(string));
                SelectedTagTable.Columns.Add("TagName", typeof(string));
                SelectedTagTable.Columns.Add("TagValue", typeof(string));
                SelectedTagTable.Columns.Add("Condition", typeof(string));
                SelectedTagTable.Columns.Add("SQL", typeof(string));
                SelectedTagTable.WriteXmlSchema(configPath);
            }
            SelectedTagTable.ReadXml(configPath);
        }

        private bool FormValidate()
        {
            if (combDB.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the connect name.");
                return false;
            }
            DataTable dt = new DataTable();
            string dbPath = ConfigPath + "Databases.xml";
            dt.ReadXml(dbPath);
            DBHelper.GetConnetString(dt, combDB.SelectedValue.ToString(), out DbConnectType, out DbConnectString);
            string errMsg = "";
            bool flag = false;
            if (DbConnectType.ToLower() == "oracle")
            {
                flag = DBHelper.OracleTestConnect(DbConnectString, out errMsg);
            }
            else if (DbConnectType.ToLower() == "sqlserver")
            {
                flag = DBHelper.SqlTestConnect(DbConnectString, out errMsg);
            }
            if (!flag)
            {
                MessageBox.Show(string.Format("Connect failed:\n{0}.", errMsg));
                return false;
            }
            if (SelectedTagTable.Rows.Count <= 0)
            {
                MessageBox.Show("Please select one tag at least.");
                return false;
            }
            foreach (DataRow dr in SelectedTagTable.Rows)
            {
                if (dr["Condition"].ToString() == "" || dr["SQL"].ToString() == "")
                {
                    MessageBox.Show(string.Format("Please input {0}'s condition and sql.", dr["TagName"].ToString()));
                    return false;
                }
            }
            return true;
        }

        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmValidate form = new FrmValidate();
            if (form.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(0);
            }

            InintSelectedTagTable(); //必须放在第一个，因为后面需要用到其值
            DatabaseBind();
            TagListBind();
            SelectedTagTableBind();
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            FrmDB form = new FrmDB("");
            if (form.ShowDialog() == DialogResult.OK)
            {
                DatabaseBind();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (combDB.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a connect name.");
                return;
            }

            FrmDB form = new FrmDB(combDB.SelectedValue.ToString());
            if (form.ShowDialog() == DialogResult.OK)
            {
                DatabaseBind();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (combDB.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a connect name.");
                return;
            }

            DataTable dt = new DataTable();
            string dbPath = ConfigPath + "Databases.xml";
            dt.ReadXml(dbPath);

            string connectType = "";
            string connectString = "";
            DBHelper.GetConnetString(dt, combDB.SelectedValue.ToString(), out connectType, out connectString);
            string errMsg = "";
            bool flag = false;
            if (connectType.ToLower() == "oracle")
            {
                flag = DBHelper.OracleTestConnect(connectString, out errMsg);
            }
            else if (connectType.ToLower() == "sqlserver")
            {
                flag = DBHelper.SqlTestConnect(connectString, out errMsg);
            }
            if (flag)
            {
                MessageBox.Show("Connect succeed.");
            }
            else
            {
                MessageBox.Show("Connect failed.");
            }
        }

        private void dataGridViewTagList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*判断点击行标题与列标题*/
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                /*传员工工号过去*/
                DataGridViewCheckBoxCell cell1 = (DataGridViewCheckBoxCell)dataGridViewTagList.CurrentRow.Cells[0];
                DataGridViewTextBoxCell cell2 = (DataGridViewTextBoxCell)dataGridViewTagList.CurrentRow.Cells[1];
                cell1.Value = !Convert.ToBoolean(cell1.Value);
                bool isChecked = Convert.ToBoolean(cell1.Value);
                string tagName = cell2.Value.ToString();
                if (isChecked)
                {
                    if (SelectedTagTable.Select(string.Format("TagName='{0}'", tagName)).Length <= 0)
                    {
                        DataRow dr = SelectedTagTable.NewRow();
                        dr["DSN"] = "";
                        dr["TagName"] = tagName;
                        dr["TagValue"] = "-1";
                        SelectedTagTable.Rows.Add(dr);
                        SelectedTagTable.AcceptChanges();
                    }
                }
                else
                {
                    DataRow[] drArray = SelectedTagTable.Select(string.Format("TagName='{0}'", tagName));
                    if (drArray.Length > 0)
                    {
                        foreach (DataRow dr in drArray)
                        {
                            SelectedTagTable.Rows.Remove(dr);
                            SelectedTagTable.AcceptChanges();
                        }
                    }
                }
                SelectedTagTableBind();
            }
        }

        private void dataGridViewSelectedTag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*判断点击行标题与列标题*/
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                string action = dataGridViewSelectedTag.Columns[e.ColumnIndex].Name;//操作类型
                if (action == "Edit")
                {
                    DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)dataGridViewSelectedTag.CurrentRow.Cells[2];
                    FrmEdit form = new FrmEdit(cell.Value.ToString(), SelectedTagTable, combDB.SelectedValue.ToString());
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        SelectedTagTableBind();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidate())
            {
                return;
            }

            foreach (DataRow dr in SelectedTagTable.Rows)
            {
                dr["DSN"] = combDB.SelectedValue.ToString();
            }
            string configPath = ConfigPath + "SelectedTagConfig.xml";
            SelectedTagTable.WriteXml(configPath, XmlWriteMode.WriteSchema);

            MessageBox.Show("Save Succeed!");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                if (!FormValidate())
                {
                    return;
                }

                timer1.Enabled = true;
                timer1.Start();
                btnStart.Text = "Stop";
                btnStart.ForeColor = Color.Red;
            }
            else if (btnStart.Text == "Stop")
            {
                timer1.Stop();
                timer1.Enabled = false;
                btnStart.Text = "Start";
                btnStart.ForeColor = Color.Green;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 加锁检查更新锁
            lock (CheckMainLockObject)
            {
                if (CheckMainCheckUpDateLock == 0) CheckMainCheckUpDateLock = 1;
                else return;
            }

            try
            {
                string configPath = ConfigPath + "SelectedTagConfig.xml";
                DataTable table = new DataTable();
                table.ReadXml(configPath);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        bool flag = false;
                        double oldValue = Convert.ToDouble(dr["TagValue"]);
                        double currentValue = -1;
                        double.TryParse(WsAPI.GetTagValueByTagName(dr["TagName"].ToString()), out currentValue);//current status
                        if (dr["Condition"].ToString().Trim() == "Greater than or equal to 1")
                        {//值改变且>=1时就执行sql语句
                            if (currentValue >= 1 && oldValue != currentValue)
                            {
                                flag = true;
                                oldValue = currentValue;
                            }
                        }
                        else if (dr["Condition"].ToString().Trim() == "Changed")
                        {//值改变就执行sql语句
                            if (currentValue != oldValue)
                            {
                                flag = true;
                                oldValue = currentValue;
                            }
                        }
                        dr["TagValue"] = currentValue.ToString();
                        if (flag)
                        {
                            string sql = DBHelper.GetSQL(dr["SQL"].ToString(), dr["TagName"].ToString(), currentValue.ToString(), table);
                            if (DbConnectType.ToLower() == "oracle")
                            {
                                DBHelper.OracleExecuteTranSQL(DbConnectString, sql);
                            }
                            else if (DbConnectType.ToLower() == "sqlserver")
                            {
                                DBHelper.SqlExecuteTranSQL(DbConnectString, sql);
                            }
                        }
                    }
                    table.WriteXml(configPath, XmlWriteMode.WriteSchema);
                }
            }
            catch (Exception ex)
            {
                LogInfo.Info(ex.Message, ex);
            }

            // 解锁更新检查锁
            lock (CheckMainLockObject)
            {
                CheckMainCheckUpDateLock = 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                //this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                //this.ShowInTaskbar = false;
                this.Visible = false;
                return;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible == false)
            {
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
