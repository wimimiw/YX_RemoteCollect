using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Microsoft.Win32;

namespace RemoteCollect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct HardParam
        {
            public int id;
            public string YID;
            public string Phone;
            public string CarID;
            public string Community;
            public DateTime StarTime;
            public DateTime EndTime;
        }

        public string __strConnection = string.Empty;
        private string __dbName = "Equipment";
        private string __tb1Name = "Hardware";              //设备注册
        private string __tb2Name = "Hardware_Log";     //递交日志
        private string __iniName = @"\info.ini";

        private int myProt;
        private IPAddress ip = null;
        private TcpListener serverSocket = null;
        private Thread myThread = null;
        /*
          * 前提条件，你需要先安装Microsoft Access Database Engine 2010 Redistributable 下载地址：
          * http://www.microsoft.com/downloads/zh-cn/details.aspx?familyid=c06b8369-60dd-4b64-a44b-84b371ede16d&displaylang=zh-cn
          * 需要注意的是：下载的版本跟你的程序编译的.NET版本一致，而不是跟操作系统的版本一致。
          *
          * 需要添加引用 Microsoft ADO Ext. 2.8 for DDL and Security 文件位置：C:\Program Files (x86)\Common Files\System\ado\msadox28.tlb
          * 或者 Microsoft ADO Ext. 6.0 for DDL and Security 文件位置：C:\Program Files (x86)\Common Files\System\ado\msadox.dll
        */
        //private void AccessLink()
        //{
        //    string accdb = Application.StartupPath + @"\" + __dbName + ".accdb";

        //    if (File.Exists(accdb)) File.Delete(accdb);

        //    ADOX.Catalog cat = new ADOX.Catalog();
        //    cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + accdb);

        //    ADOX.Table tbl = new ADOX.Table();
        //    tbl.ParentCatalog = cat;
        //    tbl.Name = "Table1";

        //    //增加一个自动增长的字段
        //    ADOX.Column col = new ADOX.Column();
        //    col.ParentCatalog = cat;
        //    col.Type = ADOX.DataTypeEnum.adInteger; // 必须先设置字段类型
        //    col.Name = "id";
        //    col.Properties["Jet OLEDB:Allow Zero Length"].Value = false;
        //    col.Properties["AutoIncrement"].Value = true;
        //    tbl.Columns.Append(col, ADOX.DataTypeEnum.adInteger, 0);

        //    //增加一个文本字段
        //    ADOX.Column col2 = new ADOX.Column();
        //    col2.ParentCatalog = cat;
        //    col2.Name = "Description";
        //    col2.Properties["Jet OLEDB:Allow Zero Length"].Value = false;
        //    tbl.Columns.Append(col2, ADOX.DataTypeEnum.adVarChar, 25);

        //    //增加数字字段
        //    ADOX.Column col3 = new ADOX.Column();
        //    col3.ParentCatalog = cat;
        //    col3.Name = "数字";
        //    col3.Type = ADOX.DataTypeEnum.adDouble;
        //    col3.Properties["Jet OLEDB:Allow Zero Length"].Value = false;
        //    tbl.Columns.Append(col3, ADOX.DataTypeEnum.adDouble, 666);

        //    //增加Ole字段
        //    ADOX.Column col4 = new ADOX.Column();
        //    col4.ParentCatalog = cat;
        //    col4.Name = "Ole类型";
        //    col4.Type = ADOX.DataTypeEnum.adLongVarBinary;
        //    col4.Properties["Jet OLEDB:Allow Zero Length"].Value = false;
        //    tbl.Columns.Append(col4, ADOX.DataTypeEnum.adLongVarBinary, 0);
        //    //设置主键
        //    tbl.Keys.Append("PrimaryKey", ADOX.KeyTypeEnum.adKeyPrimary, "id", "", "");
        //    cat.Tables.Append(tbl);

        //    Marshal.ReleaseComObject(tbl); tbl = null;
        //    Marshal.ReleaseComObject(cat); cat = null;

        //    GC.WaitForPendingFinalizers();
        //    GC.Collect();

        //    MessageBox.Show("创建完成！");
        //}
        ///// <summary>
        ///// 增加记录
        ///// </summary>
        ///// <param name="hp"></param>
        //public void InsertItem(HardParam hp)
        //{
        //    try
        //    {
        //        using (OleDbConnection objConnection = new OleDbConnection(strConnection))
        //        {

        //            OleDbDataAdapter adapter = new OleDbDataAdapter();
        //            string str = "insert into " + __tb1Name + " order by ID";
        //            adapter.InsertCommand = new OleDbCommand(str, objConnection);
        //            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
        //            builder.QuotePrefix="[";builder.QuoteSuffix="]";
        //            objConnection.Open();

        //            DataSet users = new DataSet();
        //            adapter.Fill(users, __tb1Name);
        //            DataTable dt = new DataTable();
        //            dt = users.Tables[__tb1Name];
        //            DataRow r = dt.NewRow();
        //            r["YID"] = hp.YID;
        //            r["Phone"] = hp.Phone;
        //            r["CarID"] = hp.CarID;
        //            r["Community"] = hp.Community;
        //            r["StarTime"] = hp.StarTime;
        //            r["EndTime"] = hp.EndTime;
        //            dt.Rows.Add(r);
        //            adapter.Update(users, __tb1Name);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("删除记录出错" + e.Message);
        //    }
        //}

        public bool SetAutoRun(string fileName, bool isAutoRun)
        {
            RegistryKey reg = null;

            try
            {
                if (!File.Exists(fileName))
                    throw new Exception("该文件不存在!");
                string name = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

                if (reg == null)
                    reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

                if (isAutoRun)
                    reg.SetValue(name, fileName);
                else
                    reg.SetValue(name, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                if (reg != null)
                    reg.Close();
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt.Text == "停止")
            {
                bt.Text = "开始";
                this.button2.Enabled = true;
                this.tbIP.Enabled = true;
                this.tbPort.Enabled = true;
                this.cbRoot.Enabled = true;

                myThread.Abort();
                serverSocket.Stop();
                serverSocket = null;
            }
            else
            {
                bt.Text = "停止";
                this.button2.Enabled = false;
                this.tbIP.Enabled = false;
                this.tbPort.Enabled = false;
                this.cbRoot.Enabled = false;

                myThread = new Thread(TcpListenCall);
                myThread.Start();   
            }

            this.toolStripStatusLabel1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IniFile.SetFileName(Application.StartupPath + __iniName);

                IniFile.SetString("main", "IP", this.tbIP.Text);
                IniFile.SetString("main", "PORT",this.tbPort.Text);
                IniFile.SetString("main", "ROOT",this.cbRoot.Checked.ToString());

                this.ip = IPAddress.Parse(this.tbIP.Text);
                this.myProt = int.Parse(this.tbPort.Text);
                SetAutoRun(Application.ExecutablePath,this.cbRoot.Checked);

                this.toolStripStatusLabel1.Text = "提交成功!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void TcpListenCall()
        {
            this.serverSocket = new TcpListener(this.ip, this.myProt);
            serverSocket.Start(10); //设定最多10个排队连接请求

            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();

                try
                {
                    byte[] result = new byte[256];
                    //通过clientSocket接收数据
                    NetworkStream stream = clientSocket.GetStream();
                    stream.Read(result, 0, result.Length);

                    string[] strInfo = Encoding.UTF8.GetString(result).Split(',');
                    if (strInfo.Length >= 5)
                    {
                        HardParam hp = new HardParam();

                        hp.YID = strInfo[0];
                        hp.Phone = strInfo[1];
                        hp.CarID = strInfo[2];
                        hp.Community = strInfo[3];
                        hp.StarTime = DateTime.Parse(strInfo[4]);
                        hp.EndTime = DateTime.Now;

                        UpdateItem(hp);
                    }

                    stream.Close();
                    clientSocket.Close();
                }
                catch (Exception ex)
                {
                    clientSocket.Close();
                    serverSocket.Stop();
                }
            }  
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Empty;

            __strConnection = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = " + Application.StartupPath + @"\" + __dbName + ".accdb";//指定数据库在硬盘的物理位置;

            IniFile.SetFileName(Application.StartupPath + __iniName);

            string ipt = IniFile.GetString("main", "IP", string.Empty);
            string portt = IniFile.GetString("main", "PORT", string.Empty);
            string root = IniFile.GetString("main", "ROOT", string.Empty);

            if (ipt == string.Empty)
            {
                this.myProt = 8885;   //端口
                this.ip = IPAddress.Parse("127.0.0.1");
                this.cbRoot.Checked = false;
            }
            else
            {
                this.myProt =int.Parse(portt);   //端口
                this.ip = IPAddress.Parse(ipt);
                this.cbRoot.Checked = bool.Parse(root);
            }

            myThread = new Thread(TcpListenCall);
            myThread.Start();    
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="hp"></param>
        public void UpdateItem(HardParam hp)
        {
            try
            {
                bool itemExist = false;//指示信息是否已经在数据库

                using (OleDbConnection objConnection = new OleDbConnection(__strConnection))
                {
                    objConnection.Open();
                    string strSel = string.Format("SELECT * FROM  {0} WHERE YID='{1}'", __tb1Name, hp.YID);
                    OleDbCommand sqlcmd = new OleDbCommand(strSel, objConnection); //sql语句                        
                    using (OleDbDataReader reader = sqlcmd.ExecuteReader())  //执行查询，用using替代reader.Close()  
                    {
                        if (reader.Read())     //这个read调用很重要！不写的话运行时将提示找不到数据  
                        {
                            itemExist = true;
                        }
                    }

                    if (itemExist)
                    {
                        strSel = string.Format("UPDATE {0} SET Phone='{1}',CarID='{2}',Community = '{3}',EndTime='{4}' WHERE YID = '{5}'",
                            __tb1Name,
                            hp.Phone,
                            hp.CarID,
                            hp.Community,
                            hp.EndTime,
                            hp.YID);
                    }
                    else
                    {
                        strSel = string.Format("INSERT INTO [{0}]([{1}],[{2}], [{3}],[{4}],[{5}],[{6}])", __tb1Name, "YID", "Phone", "CarID", "Community", "StarTime", "EndTime");
                        strSel += string.Format("VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                            hp.YID,
                            hp.Phone,
                            hp.CarID,
                            hp.Community,
                            hp.StarTime,
                            hp.EndTime);
                    }

                    OleDbCommand myCommand = new OleDbCommand(strSel, objConnection);
                    myCommand.ExecuteNonQuery();

                    strSel = string.Format("INSERT INTO [{0}]([{1}],[{2}], [{3}],[{4}],[{5}],[{6}])", __tb2Name, "YID", "Phone", "CarID", "Community", "StarTime", "EndTime");
                    strSel += string.Format("VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                        hp.YID,
                        hp.Phone,
                        hp.CarID,
                        hp.Community,
                        hp.StarTime,
                        hp.EndTime);

                    myCommand = new OleDbCommand(strSel, objConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception("操作数据库出错" + e.Message);
            }
        }

        /// <summary>
        /// 查询对应条目
        /// </summary>
        protected void AccessConnectionDB()
        {
            try
            {
                using (OleDbConnection objConnection = new OleDbConnection(__strConnection)) //用using替代objConnection.Close()  
                {
                    objConnection.Open();  //打开连接   
                    OleDbCommand sqlcmd = new OleDbCommand(@"SELECT * FROM " + __tb1Name + " where YID='lishi'", objConnection); //sql语句     
                    using (OleDbDataReader reader = sqlcmd.ExecuteReader())  //执行查询，用using替代reader.Close()  
                    {
                        if (reader.Read())     //这个read调用很重要！不写的话运行时将提示找不到数据  
                        {
                            //    tempUser.ID = (int)reader["UserID"];
                            //    tempUser.Name = reader["UserName"].ToString();
                            //    tempUser.Salary = (float)reader["UserSalary"];
                            //    tempUser.Password = reader["UserPassword"].ToString();
                            //    tempUser.Memo = reader["UserMemo"].ToString();
                            //    tempUser.Birthday = (DateTime)reader["UserBirthday"];
                            //    tempUser.Address = reader["UserAddress"].ToString();
                        }
                        else
                        {
                            //    throw new Exception("没有记录");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("打开数据库出错" + e.Message);
            }
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="hp"></param>
        public void InsertParamsOther(HardParam hp)
        {
            try
            {
                using (OleDbConnection objConnection = new OleDbConnection(__strConnection)) //用using替代objConnection.Close()  
                {
                    objConnection.Open();  //打开连接   
                    string strSel = string.Format("INSERT INTO [{0}]([{1}],[{2}], [{3}],[{4}],[{5}],[{6}])", __tb1Name, "YID", "Phone", "CarID", "Community", "StarTime", "EndTime"); //插入语句
                    strSel += string.Format("VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",hp.YID,hp.Phone,hp.CarID,hp.Community,hp.StarTime,hp.EndTime);
                    OleDbCommand sqlcmd = new OleDbCommand(strSel, objConnection); //sql语句
                    int num =  sqlcmd.ExecuteNonQuery();
                }           
            }
            catch (Exception e)
            {
                throw new Exception("打开数据库出错" + e.Message);
            }
        }
       
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="m_id"></param>
        public void DeleteItem( string yid)
        {
            try
            {
                using (OleDbConnection objConnection = new OleDbConnection(__strConnection)) //用using替代objConnection.Close()  
                {
                    objConnection.Open(); 
                    string strSel = "DELETE FROM " + __tb1Name + " WHERE YID ='" + yid + "'";
                    OleDbCommand myCommand = new OleDbCommand(strSel, objConnection);
                    myCommand.ExecuteNonQuery();
                }      
            }
            catch (Exception e)
            {
                throw new Exception("删除记录出错" + e.Message);
            }
        }
    }
}
