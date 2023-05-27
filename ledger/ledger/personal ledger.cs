using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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

        database db = new database();//创建一个数据库的对象
        private void personal_ledger_Load(object sender, EventArgs e)//在窗口打开的时候更新数据
        {
            db.dbopen();//等待窗口关闭后,打开数据库更新数据
            //db.insert_new("yzx");  测试的时候添加的用户
            int sum = db.rtn_max_sum("yzx");//根据名字找上限金额                      跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            shangxian.Text = Convert.ToString(sum);//修改显示的lable
            db.dbclose();
        }

        private void Amount_modification_Click(object sender, EventArgs e)//修改金额的按钮
        {
            string labelContent = user_name.Text;//获取名字
            Cap_amount form2 = new Cap_amount(labelContent);//建一个修改金额的窗口,把用户名字传过去

            // 设置新窗口的位置
            int x = (Screen.PrimaryScreen.Bounds.Width - form2.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - form2.Height) / 2;
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(x, y);

            form2.ShowDialog();//显示修改金额的窗口的,并等待关闭

            db.dbopen();//等待窗口关闭后,打开数据库更新数据
            int sum = db.rtn_max_sum(labelContent);//根据名字找上限金额
            shangxian.Text = Convert.ToString(sum);//修改显示的lable
            db.dbclose();
        }

        private void Add_Button_Click(object sender, EventArgs e)//添加条目的按钮
        {
             AddRecord Form2 = new AddRecord();// 创建一个新的窗口实例

            // 计算新窗口的位置
            int x = (Screen.PrimaryScreen.Bounds.Width - Form2.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - Form2.Height) / 2;
            // 设置新窗口的位置
            Form2.StartPosition = FormStartPosition.Manual;
            Form2.Location = new Point(x, y);

            //传到xpenditure_box1的内容
            Form2.DataAdded += (textbox1Content, textbox2Content, comboboxContent, dateTimeContent1) =>
            {
                string rowContent = $"{dateTimeContent1},{textbox1Content}, {textbox2Content}, {comboboxContent}"; // 将数据以逗号隔开拼接成一行内容
                // 在事件处理程序中将一行内容添加到 expenditure_box 中
                expenditure_box.Items.Add(rowContent);
            };

            //传到xpenditure_box2的内容
            Form2.DataAdded2 += (textbox1Content2, textbox2Content2,dateTimeContent2) =>
            {
                string rowContent = $"{dateTimeContent2},{textbox1Content2}, {textbox2Content2}"; // 将数据以逗号隔开拼接成一行内容
                // 在事件处理程序中将一行内容添加到 expenditure_box 中
                income_box.Items.Add(rowContent);
            };
            Form2.ShowDialog();// 显示新的窗口

            // 在新窗口中查找名为 "tabControl1" 的 TabControl 控件
            TabControl tabControl = Form2.Controls.Find("tabControl1", true).FirstOrDefault() as TabControl;
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

        private void 上限金额_Click(object sender, EventArgs e)
        {

        }


    }
}
