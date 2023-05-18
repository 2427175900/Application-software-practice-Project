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
    public partial class personal_ledger : Form
    {
        public personal_ledger()
        {
            InitializeComponent();
        }

        private void Amount_modification_Click(object sender, EventArgs e)//修改金额的按钮
        {
            Form Cap_amount = new Cap_amount();// 创建一个新的窗口实例

            // 计算新窗口的位置
            int x = (Screen.PrimaryScreen.Bounds.Width - Cap_amount.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - Cap_amount.Height) / 2;
            // 设置新窗口的位置
            Cap_amount.StartPosition = FormStartPosition.Manual;
            Cap_amount.Location = new Point(x, y);

            Cap_amount.Show();// 显示新的窗口
        }

        private void Add_Button_Click(object sender, EventArgs e)//添加条目的按钮
        {
            Form AddRecord = new AddRecord();// 创建一个新的窗口实例

            // 计算新窗口的位置
            int x = (Screen.PrimaryScreen.Bounds.Width - AddRecord.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - AddRecord.Height) / 2;
            // 设置新窗口的位置
            AddRecord.StartPosition = FormStartPosition.Manual;
            AddRecord.Location = new Point(x, y);

            AddRecord.Show();// 显示新的窗口

            // 在新窗口中查找名为 "tabControl1" 的 TabControl 控件
            TabControl tabControl = AddRecord.Controls.Find("tabControl1", true).FirstOrDefault() as TabControl;
            // 如果找到了 TabControl 控件，则选择名为 "tabPage1" 的选项卡
            if (tabControl != null)
            {
                foreach (TabPage tabPage in tabControl.TabPages)
                {
                    if (tabPage.Name == "tabPage1")
                    {
                        tabControl.SelectedTab = tabPage;
                        break;
                    }
                }
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)//删除条目的按钮
        {
            for (int i = expenditure_box.Items.Count - 1; i >= 0; i--)//做一个循环 循环遍历 expenditure_box里头已经被打勾的选项 然后把他删了,暂时没有联动数据库
            {
                if (expenditure_box.GetItemChecked(i))
                {
                    expenditure_box.Items.RemoveAt(i);
                }
            }
            for (int i = income_box.Items.Count - 1; i >= 0; i--)
            {
                if (income_box.GetItemChecked(i))
                {
                    income_box.Items.RemoveAt(i);
                }
            }
        }
    }
}
