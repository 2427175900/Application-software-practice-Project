using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void PerformCustomLogic()
        {
            // 执行您想要的自定义操作
            // 可以包含任何特定的逻辑或代码
            db.dbopen();

            //所有用户名
            string[] users = db.rtn_name();
            //MessageBox.Show(users.Length.ToString());


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
            for (int i = 0; i <10; i++)
            {
                //MessageBox.Show(i.ToString());
                maxsum[i] = db.rtn_max_sum(users[i]);
            }

            //当月总消费
            for (int i = 0; i < 10; i++)
            {
                sum[i] = db.rtn_expenditure_amount_all_with_moth(users[i], dt);
            }


            //通过遍历将 当月 各个方面支出 调用出来
            for (int i = 0; i < 10; i++)
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
            listView1.Items.Clear();

            //将值依次写入 listview
            for (int i = 0; i <10; i++)
            {
                item = new ListViewItem(users[i]);     //用户名写入
                item.SubItems.Add(maxsum[i].ToString());            //用户支出上限写入
                item.SubItems.Add(sum[i].ToString());               //用户当月指出写入

                item.SubItems.Add(eat[i].ToString());               //用户吃饭写入
                item.SubItems.Add(tar[i].ToString());               //用户交通
                item.SubItems.Add(med[i].ToString());               //用户医疗
                item.SubItems.Add(life[i].ToString());              //用户生活
                item.SubItems.Add(other[i].ToString());             //用户其他
                listView1.Items.Add(item);

            }


            // 所有用户的总支出
            int usersmouthsum = 0;
            for (int i = 0; i < sum.Length; i++)
            {
                usersmouthsum += sum[i];
            }
            mouthsum.Text = usersmouthsum.ToString();

            // 所有用户的最大上限合
            int usersmouthmaxsum = 0;
            for (int i = 0; i < maxsum.Length; i++)
            {
                usersmouthmaxsum += sum[i];
            }
            usersmaxsum.Text = usersmouthmaxsum.ToString();

            db.dbclose();

        }
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
            }
            personal_ledger p = new personal_ledger(username);
            p.Show();
        }



        private void dltUser_Click(object sender, EventArgs e)
        {
           // db.dbopen();
           // if (listView1.SelectedItems.Count > 0)
           // {
                
           //     ListViewItem selectedItem = listView1.SelectedItems[0];
           //     username = selectedItem.SubItems[0].Text;
           //      //使用 name 进行进一步的操作
           //     db.del_user(username);

                
           // }
           //db.dbclose();

           // PerformCustomLogic();
        }
    }
}
