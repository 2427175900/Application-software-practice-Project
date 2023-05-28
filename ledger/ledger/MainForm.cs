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
        public string username;  //用户名 --  选中行的第一个项目(name)
        public void MainForm_Load(object sender, EventArgs e)
        {

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
