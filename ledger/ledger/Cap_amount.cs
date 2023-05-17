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
