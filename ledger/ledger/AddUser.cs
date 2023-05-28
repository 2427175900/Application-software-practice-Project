using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ledger
{
    public partial class AddUser : Form
    {
        private SQLiteConnection connection;

        public AddUser()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        database db = new database();

        //窗口开始时连接数据库
        private void AddUser_Load(object sender, EventArgs e)
        {
           db.dbopen();
        }

        //窗口关闭时关闭数据库
        private void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
           db.dbclose();
        }

        //点击按钮的时候 把 name  插入到数据库
        private void button1_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            MessageBox.Show(name);
            try
            { 
                db.insert_new(name);
            }catch (ConstraintException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }

        // 获取数据库中的行数
       
    }
}
