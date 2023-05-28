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
        public void MainForm_Load(object sender, EventArgs e)
        {
            db.dbopen();

            //所有用户名
            string []users = db.rtn_name();
            //MessageBox.Show(users.Length.ToString());

           
            int [] maxsum = new int[10]; //所有用户的最大支出 上限
            int[] eat = new int[10];    //吃饭类型支出
            int[] tar = new int[10];    //交通
            int[] med = new int[10];    //医疗
            int[] life = new int[10];    //生活
            int[] other = new int[10];  //其他


            DateTime date = DateTime.Now; //当前时间
            string dt=date.ToString("yyyy-MM");
            


            //通过便利调用所有用户 的最大支出上限
            for (int i = 0; i< users.Length; i++)
            {
                //MessageBox.Show(i.ToString());
                maxsum[i] = db.rtn_max_sum(users[i]); 
            }

            //当月总消费



            //通过遍历将 当月 식사 调用出来
            for(int i = 0; i < users.Length; i++)
            {
                int[] eatamout = db.rtn_expenditure_amount_type_with_date(users[i], "식사", dt);
                int eatsum = 0;
                for(int j = 0; j < eatamout.Length; j++)
                {
                    eatsum += eatamout[j];
                }
                eat[i] = eatsum;
            }


            //将值依次写入 listview
            for (int i = 0;i< users.Length; i++)
            {
                ListViewItem item = new ListViewItem(users[i]);
                item.SubItems.Add(maxsum[i].ToString());
                item.SubItems.Add(eat[i].ToString());

                listView1.Items.Add(item);

            }
        }
        internal void UpdateLabel(string text)
        {
            throw new NotImplementedException();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
        }


        //获取选中行的 第一个元素(name)
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                username = selectedItem.SubItems[0].Text;
                // 使用 name 进行进一步的操作
            }
        }
    }
}
