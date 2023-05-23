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
    public partial class Cap_amount : Form
    {
        public Cap_amount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //确定按钮
        {

<<<<<<< Updated upstream
=======
            //创建一个连接字符串，指定数据库文件路径
            string connectionString = "Data Source=user_info.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)//测试
                {
                    Console.WriteLine("数据库已成功打开！");
                }
                else
                {
                    Console.WriteLine("xxx");
                }
                connection.Close();
            }
>>>>>>> Stashed changes
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
