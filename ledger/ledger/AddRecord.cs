using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ledger
{
    public partial class AddRecord : Form
    {
        string user_name; //用户名
        public AddRecord(string labelContent)
        {
            user_name = labelContent;//获取用户名
            InitializeComponent();
        }

        database db = new database();//创建数据库的对象
        private void textbox_TM1_KeyPress(object sender, KeyPressEventArgs e)//禁止输入除了数字以外的其他东西
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textbox_TM2_KeyPress(object sender, KeyPressEventArgs e)//禁止输入除了数字以外的其他东西
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sure1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_TM1.Text)) //判断有那哪个没填
            {
                // 文本框为空
                MessageBox.Show("金额不能为空");
            }
            else
            {
                // 文本框不为空
                if (yongtu.SelectedIndex == -1)
                {
                    // 未选择项
                    MessageBox.Show("请选择用途");
                }
                else
                {
                    string textbox1Content = textbox_TM1.Text; // 获取金额
                    string comboboxContent = yongtu.Text; // 获取用途
                    string textbox2Content = beizhu.Text; // 获取备注
                    DateTime dateTimeContent1 = dateTimePicker1.Value; // 获取日期选择器的时间
                    string formattedDateTime = dateTimeContent1.ToString("yyyy-MM-dd HH:mm:ss");
                    //开始操作数据库
                    db.dbopen();//打开数据库
                    db.insert_new_expenditure(user_name, Convert.ToString(formattedDateTime), comboboxContent, Convert.ToInt32(textbox1Content), textbox2Content);
                    db.dbclose();//关闭数据库
                    this.Close(); // 关闭窗口
                }
            }
        }

        private void sure2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textbox_TM2.Text)) //判断有那哪个没填
            {
                // 文本框为空
                MessageBox.Show("金额不能为空");
            }
            else
            {
                string textbox1Content2 = textbox_TM2.Text; // 获取金额2
                string textbox2Content2 = beizhu2.Text; // 获取备注2
                DateTime dateTimeContent2 = dateTimePicker2.Value; // 获取日期选择器的时间
                string formattedDateTime2 = dateTimeContent2.ToString("yyyy-MM-dd HH:mm:ss");
                //开始操作数据库
                db.dbopen();
                db.insert_new_income(user_name, Convert.ToString(formattedDateTime2), Convert.ToInt32(textbox1Content2), textbox2Content2);//写入 用户 时间 收入
                db.dbclose();//关闭数据库
                this.Close(); // 关闭窗口
            }
        }
    }
}
