using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace configtool
{
    public class WebAccessAPI
    {
        public void Test()
        {
            //实例化COM组件
            BWDLLOBJLib.DllObj dllObj = new BWDLLOBJLib.DllObj();
            //初始化
            string initMsg = dllObj.KrlInit().ToString();
            //判断WebAccess核心程序是否已启动，0=not run,1=running
            int iIsKrlRunning = dllObj.IsKrlRunning();

            if (iIsKrlRunning == 1)
            {
                //读取webaccess中点的数量
                int tagCount = dllObj.GetTagNumber();
                //根据电名称获取点ID
                Array daqId1 = (Array)dllObj.GetId("A相电流");
                //根据点ID获取点值
                string nodeValue = dllObj.GetValue(daqId1);
                //获取所有正在发生报警的点的数量
                int alarmTagCount = dllObj.GetAlarmTagNumber();
                //获取正在发生报警的点的名称，返回字符串数组
                dynamic alarmList = dllObj.GetAlarmTagList(0, alarmTagCount);
            }

            //释放对象
            dllObj.KrlFree();
        }

        /// <summary>
        /// 获取正在发生报警的点的名称，返回字符串数组
        /// </summary>
        /// <returns></returns>
        public string[] GetAllAlarmTagList()
        {
            //string[] list = new string[] { "A相电流", "A相电压", "B相电压", "B相电流", "C相电压", "C相电流", "D相电压", "D相电流" };
            List<string> lstTag=new List<string>();
            DataTable dt = DBHelper.Query("bwdb_Access", "select * from pTag").Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstTag.Add(dr["TagName"].ToString());
                }
            }
            return lstTag.ToArray();
        }

        public string GetTagValueByTagName(string tagName)
        {
            string tagValue = "";

            BWDLLOBJLib.DllObj dllObj = new BWDLLOBJLib.DllObj();
            //初始化
            string initMsg = dllObj.KrlInit().ToString();
            if (dllObj.IsKrlRunning() == 1)
            {
                Array daqId = (Array)dllObj.GetId(tagName);
                tagValue = dllObj.GetValue(daqId);
            }
            dllObj.KrlFree();

            return tagValue;

            //string tagValue = "";
            //switch (tagName)
            //{
            //    case "tag1": tagValue = new Random(GetRandomSeed()).Next(0, 10).ToString(); break;
            //    case "tag2": tagValue = new Random(GetRandomSeed()).Next(0, 10).ToString(); break;
            //    case "tag3": tagValue = new Random(GetRandomSeed()).Next(0, 10).ToString(); break;
            //    case "tag4": tagValue = new Random(GetRandomSeed()).Next(0, 10).ToString(); break;
            //    case "tag5": tagValue = new Random(GetRandomSeed()).Next(0, 10).ToString(); break;
            //    case "tag6": tagValue = new Random(GetRandomSeed()).Next(0, 10).ToString(); break;
            //    case "tag7": tagValue = new Random(GetRandomSeed()).Next(0, 10).ToString(); break;
            //    case "tag8": tagValue = new Random(GetRandomSeed()).Next(0, 10).ToString(); break;
            //}
            //return tagValue;
        }

        private int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
