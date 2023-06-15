using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace ledger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        database db = new database();
        public string username;  //用户名 --  选中行的第一个项目(name)

       
        //数据库内容同步函数
        private void PerformCustomLogic()
        {
            
            db.dbopen();//连接数据库

            //所有用户名
            string[] users = new string[10];
            users = db.rtn_name();
            int usersmouthsum = 0;      //用户当前支出
            int usersmouthmaxsum = 0;   //用户最大支出上限


            int[] maxsum = new int[10]; //所有用户的最大支出 上限
            int[] sum = new int[10];    //总消费
            int[] eat = new int[10];    //吃饭类型支出
            int[] tar = new int[10];    //交通
            int[] med = new int[10];    //医疗
            int[] life = new int[10];    //生活
            int[] other = new int[10];  //其他
            

            DateTime date = DateTime.Now; //当前时间
            string dt = date.ToString("yyyy-MM");



            //通过便利调用所有用户 的最大支出上限
            for (int i = 0; i <users.Length; i++)
            {
                //MessageBox.Show(i.ToString());
                maxsum[i] = db.rtn_max_sum(users[i]);
            }

            //当月总消费
            for (int i = 0; i < users.Length; i++)
            {
                sum[i] = db.rtn_expenditure_amount_all_with_moth(users[i], dt);

            }


            //通过遍历将 当月 各个方面支出 调用出来
            for (int i = 0; i < users.Length; i++)
            {
                int[] eatamout = db.rtn_expenditure_amount_type_with_date(users[i], "식사", dt);
                int[] taramout = db.rtn_expenditure_amount_type_with_date(users[i], "교통", dt);
                int[] medamout = db.rtn_expenditure_amount_type_with_date(users[i], "의료", dt);
                int[] lifeamout = db.rtn_expenditure_amount_type_with_date(users[i], "생활", dt);
                int[] otheramout = db.rtn_expenditure_amount_type_with_date(users[i], "기타", dt);
                int eatsum = 0;
                int tarsum = 0;
                int medsum = 0;
                int lifesum = 0;
                int othersum = 0;

                for (int j = 0; j < eatamout.Length; j++) eatsum += eatamout[j];

                for (int j = 0; j < taramout.Length; j++) tarsum += taramout[j];

                for (int j = 0; j < medamout.Length; j++) medsum += medamout[j];

                for (int j = 0; j < lifeamout.Length; j++) lifesum += lifeamout[j];

                for (int j = 0; j < otheramout.Length; j++) othersum += otheramout[j];

                eat[i] = eatsum;
                tar[i] = tarsum;
                med[i] = medsum;
                life[i] = lifesum;
                other[i] = othersum;
            }
            ListViewItem item;
            listView1.Items.Clear();//调用该函数时刷新数据

            //将值依次写入 listview
            for (int i = 0; i <users.Length; i++)
            {
                item = new ListViewItem(users[i]);     //用户名写入
                item.SubItems.Add(maxsum[i].ToString("N0", System.Globalization.CultureInfo.CurrentCulture));            //用户支出上限写入
                item.SubItems.Add(sum[i].ToString("N0", System.Globalization.CultureInfo.CurrentCulture));               //用户当月指出写入

                item.SubItems.Add(eat[i].ToString("N0", System.Globalization.CultureInfo.CurrentCulture));               //用户吃饭写入
                item.SubItems.Add(tar[i].ToString("N0", System.Globalization.CultureInfo.CurrentCulture));               //用户交通
                item.SubItems.Add(med[i].ToString("N0", System.Globalization.CultureInfo.CurrentCulture));               //用户医疗
                item.SubItems.Add(life[i].ToString("N0", System.Globalization.CultureInfo.CurrentCulture));              //用户生活
                item.SubItems.Add(other[i].ToString("N0", System.Globalization.CultureInfo.CurrentCulture));             //用户其他
                listView1.Items.Add(item);

            }


            // 所有用户的总支出
            
            for (int i = 0; i < sum.Length; i++)
            {
                usersmouthsum += sum[i];
            }
            mouthsum.Text = usersmouthsum.ToString("N0", System.Globalization.CultureInfo.CurrentCulture);

            // 所有用户的最大上限合
            
            for (int i = 0; i < maxsum.Length; i++)
            {
                usersmouthmaxsum += maxsum[i];
            }
            usersmaxsum.Text = usersmouthmaxsum.ToString("N0", System.Globalization.CultureInfo.CurrentCulture);

            if(usersmouthsum< usersmouthmaxsum * 0.5||usersmouthsum==0)//usermouthmansum = 当月最大指出，， usermouthsum = 当前用户指出
            {
                mouthsum.ForeColor = Color.Green;
                usersmaxsum.ForeColor = Color.Green;
            }
            else if(usersmouthsum >= usersmouthmaxsum  * 0.7)
            {
                mouthsum.ForeColor = Color.Red;
                usersmaxsum.ForeColor = Color.Red;
            }
            else if (usersmouthsum >= usersmouthmaxsum * 0.5 && usersmouthsum <= usersmouthmaxsum * 0.7)
            {
                mouthsum.ForeColor = Color.Orange;
                usersmaxsum.ForeColor = Color.Orange;
            }
           

            db.dbclose();

        }

        //窗口显示时调用
        public void MainForm_Shown(object sender, EventArgs e)
        {
            PerformCustomLogic();
        }

        
        
        internal void UpdateLabel(string text)
        {
            throw new NotImplementedException();
        }


        private AddUser addUserForm;


        //点击添加用户按钮时
        private void btnAddUser_Click(object sender, EventArgs e)
        {


            addUserForm = new AddUser();
            addUserForm.FormClosed += AddUserForm_FormClosed; // 订阅 AddUser 窗口的关闭事件
            addUserForm.ShowDialog();
            if (IsAddUserWindowClosed())
            {
                PerformCustomLogic();
            }


        }
        private void AddUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            addUserForm = null; // 清除 AddUser 窗口的实例
        }

        private bool IsAddUserWindowClosed()
        {
            return addUserForm == null || addUserForm.IsDisposed;
        }
        public void TemporarilyClose()
        {
            this.Hide(); // 隐藏第一个窗口
        }
        public void Reopen()
        {
            this.Show(); // 显示第一个窗口
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            //获取选中行的 第一个元素(name)
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                username = selectedItem.SubItems[0].Text;
                // 使用 name 进行进一步的操作
                personal_ledger p = new personal_ledger(username);
                TemporarilyClose();
                p.ShowDialog();

                Reopen();
                PerformCustomLogic();
            }
            else{

            }
           
        }

        private bool name_is_checked()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                button1.Enabled = true;
                dltUser.Enabled = true;
                return true;
            }
            else
            {
                dltUser.Enabled=false;
                button1.Enabled = false;
                return false;
            }

        }


        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    ListViewItem selectedItem = listView1.SelectedItems[0];
            //    // 在这里处理选中项的点击事件，可以访问 selectedItem.SubItems 属性获取子项的值

            //}
            name_is_checked();
        }


        private void dltUser_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                db.dbopen();

                ListViewItem selectedItem = listView1.SelectedItems[0];
                username = selectedItem.SubItems[0].Text;
                //使用 name 进行进一步的操作
                db.del_user(username);

                db.dbclose();

                PerformCustomLogic();
            }
            else
            {
               
            }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private string ListViewToTable(ListView listView)
        {
            string table = "";

            // 添加表头
            foreach (ColumnHeader column in listView.Columns)
            {
                table += column.Text + ",";
            }
            table += Environment.NewLine;

            // 添加每行数据
            foreach (ListViewItem item in listView.Items)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    table += subItem.Text + ",";
                }
                table += Environment.NewLine;
            }

            return table;
        }

        private void daochu_Click(object sender, EventArgs e)
        {
            //导出 dao = new 导出();
            ////dao.CopyListViewItems(listView1);
            ////dao.LoadListViewItems(new ListView.ListViewItemCollection(listView1));
            //dao.LoadListViewItems(listView1.Items);
            //dao.Show();
            string table = ListViewToTable(listView1);

            // 指定保存文件的路径
            string filePath = "path_to_file.csv";

            // 将表格内容写入文件
            File.WriteAllText(filePath, table);

            // 打开保存的文件
            Process.Start(filePath);


        }

        private void daochu_excel_Click(object sender, EventArgs e)
        {


            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // 写入表头
                string[] headers = new string[] { "이름", "제한 금액", "당월 소비", "식사", "교통", "의료", "생활", "기타" };
                for (int col = 1; col <= headers.Length; col++)
                {
                    worksheet.Cells[1, col].Value = headers[col - 1];
                }

                // 写入每行数据
                int row = 2;
                foreach (ListViewItem item in listView1.Items)
                {
                    int col = 1;
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        worksheet.Cells[row, col].Value = subItem.Text;
                        col++;
                    }
                    row++;
                }

                // 设置单元格样式等
                // ...

                // 保存Excel文件
                FileInfo file = new FileInfo("path_to_file.xlsx");
                package.SaveAs(file);

                // 打开文件
                Process.Start(file.FullName);
            }
        }
    }
}
