using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;


namespace ledger
{

    public partial class Cap_amount : Form
    {
        string user_name;
        public Cap_amount(string labelContent)
        {
            user_name= labelContent;
            InitializeComponent();
        }

        database db = new database();//创建数据库的对象

        private void button1_Click(object sender, EventArgs e)  //确定按钮
        {
            string textboxContent = textBox1.Text; // 获取 修改金额 文本框的内容
            db.dbopen();//打开数据库
            //db.insert_new("yzx");添加一个yzx名字的账号测试
            db.update_max_sum(user_name, Convert.ToInt32(textboxContent));//修改数据库里对应名字 的 上限金额
            db.dbclose();
            this.Close(); // 关闭窗口2
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//限制textbox不让输入数字
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}



