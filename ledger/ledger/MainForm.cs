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
            //所有用户的最大支出 上限
            int [] maxsum = new int[10];


            //通过便利调用所有用户 的最大支出上限
            for(int i = 0; i< users.Length; i++)
            {
                //MessageBox.Show(i.ToString());
                maxsum[i] = db.rtn_max_sum(users[i]); 
            }

            //将值依次写入 listview
            for(int i = 0;i< users.Length; i++)
            {
                ListViewItem item = new ListViewItem(users[i]);
                item.SubItems.Add(maxsum[i].ToString());

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
