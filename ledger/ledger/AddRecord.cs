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
        public AddRecord()
        {
            InitializeComponent();
        }

        private void textbox_TM1_KeyPress(object sender, KeyPressEventArgs e)//禁止输入除了数字以外的其他东西
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textbox_TM2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public event Action<string, string, string, DateTime> DataAdded;//定义三个要传的东西
        private void sure1_Click(object sender, EventArgs e)
        {
            string textbox1Content = textbox_TM1.Text; // 获取金额
            string comboboxContent = yongtu.Text; // 获取用途
            string textbox2Content = beizhu.Text; // 获取备注
            DateTime dateTimeContent1 = dateTimePicker1.Value; // 获取日期选择器的时间

            DataAdded?.Invoke(textbox1Content,comboboxContent,textbox2Content,dateTimeContent1); // 触发事件，并传递文本框、组合框和日期选择器内容
            this.Close(); // 关闭窗口
        }

        public event Action<string, string, DateTime> DataAdded2;//定义两个要传的东西
        private void sure2_Click(object sender, EventArgs e)
        {
            string textbox1Content2 = textbox_TM2.Text; // 获取金额2
            string textbox2Content2 = beizhu2.Text; // 获取备注2
            DateTime dateTimeContent2 = dateTimePicker2.Value; // 获取日期选择器的时间

            DataAdded2?.Invoke(textbox1Content2,textbox2Content2, dateTimeContent2); // 触发事件，并传递文本框和组合框内容

            this.Close(); // 关闭窗口
        }
    }
}
