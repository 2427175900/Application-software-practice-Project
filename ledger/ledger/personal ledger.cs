using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ledger
{
    public partial class personal_ledger : Form
    {
        string us_name;
        public personal_ledger(string username)
        {
            us_name = username;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
        int usersum;
        int usermax;
        database db = new database();//创建一个数据库的对象
        private void personal_ledger_Load(object sender, EventArgs e)//在窗口打开的时候更新数据
        {
            db.dbopen();//等待窗口关闭后,打开数据库更新数据
            
            //db.insert_new("yzx");  //测试的时候添加的用户

            int sum = db.rtn_max_sum(us_name);//根据名字找上限金额                      跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            shangxian.Text = Convert.ToString(sum);//修改显示上限金额的lable


            


            user_name.Text = us_name;

            string[] tiaomu1=db.rtn_expenditure_id_all(us_name);   //修改条目的checklistbox   跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            string[] tiaomu2 = db.rtn_income_id_all(us_name);                                //跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            expenditure_box.Items.Clear();//先清除expenditure_box.Items,再重新重数据库中遍历
            income_box.Items.Clear();//先清除income_box.Items,再重新重数据库中遍历
            foreach (string item in tiaomu1)//遍历写进items
            {
                expenditure_box.Items.Add(item); // 将数组中的每个元素添加为选项
            }
            foreach (string item in tiaomu2)//遍历写进items
            {
                income_box.Items.Add(item); // 将数组中的每个元素添加为选项
            }

            //总支出
            int[] zhichu = db.rtn_expenditure_amount_all(us_name);//跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            int zongzhichujine = 0; //总支出计算
            for (int i = 0; i < zhichu.Length; i++)//循环遍历
            {
                zongzhichujine += zhichu[i];
            }
            labelzongzhichu.Text = zongzhichujine.ToString();//更改label
            //总收入
            int[] shouru = db.rtn_income_amount_all(us_name);//跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            int zongshourujine = 0; //总支出计算
            for (int i = 0; i < shouru.Length; i++)//循环遍历
            {
                zongshourujine += shouru[i];
            }
            labelzongshouru.Text = zongshourujine.ToString();//更改label
            //结余计算
            jieyu.Text = Convert.ToString(Convert.ToInt32(zongshourujine) - Convert.ToInt32(zongzhichujine));

            //饮食总支出
            int[] food = db.rtn_expenditure_amount_type(us_name, "식사");
            int foodzong = 0; //总支出计算
            for (int i = 0; i < food.Length; i++)//循环遍历
            {
                foodzong += food[i];
            }
            labelfood.Text = foodzong.ToString();

            //交通总支出
            int[] jiaotong = db.rtn_expenditure_amount_type(us_name, "교통");
            int jiaotongzong = 0; //总支出计算
            for (int i = 0; i < jiaotong.Length; i++)//循环遍历
            {
                jiaotongzong += jiaotong[i];
            }
            labeljiaotong.Text = jiaotongzong.ToString();

            //医疗总支出
            int[] medc = db.rtn_expenditure_amount_type(us_name, "의료");
            int medczong = 0; //总支出计算
            for (int i = 0; i < medc.Length; i++)//循环遍历
            {
                medczong += medc[i];
            }
            labelmedc.Text = medczong.ToString();

            //生活总支出
            int[] shuidian = db.rtn_expenditure_amount_type(us_name, "생활");
            int shuidianzong = 0; //总支出计算
            for (int i = 0; i < shuidian.Length; i++)//循环遍历
            {
                shuidianzong += shuidian[i];
            }
            labelshuidian.Text = shuidianzong.ToString();

            //其他总支出
            int[] qita = db.rtn_expenditure_amount_type(us_name, "기타");
            int qitazong = 0; //总支出计算
            for (int i = 0; i < qita.Length; i++)//循环遍历
            {
                qitazong += qita[i];
            }
            labelqita.Text = qitazong.ToString();
            
           
            usersum = Convert.ToInt32(labelzongzhichu.Text);
            usermax = Convert.ToInt32(shangxian.Text);
            if (usersum < usermax * 0.5)
            {
                shangxian.ForeColor = Color.Green;
                labelzongzhichu.ForeColor = Color.Green;
            }
            else if (usersum >= usermax * 0.5 && usersum < usermax * 0.7)
            {
                shangxian.ForeColor = Color.Orange;
                labelzongzhichu.ForeColor = Color.Orange;
            }
            else if (usersum >= usermax * 0.7)
            {
                shangxian.ForeColor = Color.Red;
                labelzongzhichu.ForeColor = Color.Red;
            }

            db.dbclose();//关闭数据库
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
            usersum = Convert.ToInt32(labelzongzhichu.Text);
            usermax = Convert.ToInt32(shangxian.Text);
            if (usersum < usermax * 0.5)
            {
                shangxian.ForeColor = Color.Green;
                labelzongzhichu.ForeColor = Color.Green;
            }
            else if (usersum >= usermax * 0.5 && usersum < usermax * 0.7)
            {
                shangxian.ForeColor = Color.Orange;
                labelzongzhichu.ForeColor = Color.Orange;
            }
            else if (usersum >= usermax * 0.7)
            {
                shangxian.ForeColor = Color.Red;
                labelzongzhichu.ForeColor = Color.Red;
            }
            db.dbclose();
        }

        private void Add_Button_Click(object sender, EventArgs e)//添加条目的按钮
        {
            string labelContent = user_name.Text;//获取名字
            AddRecord Form2 = new AddRecord(labelContent);// 创建一个新的窗口实例

            // 计算新窗口的位置
            int x = (Screen.PrimaryScreen.Bounds.Width - Form2.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - Form2.Height) / 2;
            // 设置新窗口的位置
            Form2.StartPosition = FormStartPosition.Manual;
            Form2.Location = new Point(x, y);

            Form2.ShowDialog();// 显示新的窗口

            db.dbopen();//等待窗口关闭后,打开数据库更新数据
            string[] tiaomu1 = db.rtn_expenditure_id_all(us_name);//更新条目1
            string[] tiaomu2 = db.rtn_income_id_all(us_name);//更新条目2
            expenditure_box.Items.Clear();//先清除条目1
            income_box.Items.Clear();//先清除条目2
            foreach (string item in tiaomu1)
            {
                expenditure_box.Items.Add(item); // 将数组中的每个元素添加为选项
            }
            foreach (string item in tiaomu2)
            {
                income_box.Items.Add(item); // 将数组中的每个元素添加为选项
            }

            //总支出
            int[] zhichu = db.rtn_expenditure_amount_all(us_name);//跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            int zongzhichujine = 0; //总支出计算
            for (int i = 0; i < zhichu.Length; i++)//循环遍历
            {
                zongzhichujine += zhichu[i];
            }
            labelzongzhichu.Text = zongzhichujine.ToString();//更改label
            //总收入
            int[] shouru = db.rtn_income_amount_all(us_name);//跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            int zongshourujine = 0; //总支出计算
            for (int i = 0; i < shouru.Length; i++)//循环遍历
            {
                zongshourujine += shouru[i];
            }
            labelzongshouru.Text = zongshourujine.ToString();//更改label
            //结余计算
            jieyu.Text = Convert.ToString(Convert.ToInt32(zongshourujine) - Convert.ToInt32(zongzhichujine));

            //饮食总支出
            int[] food = db.rtn_expenditure_amount_type(us_name, "식사");
            int foodzong = 0; //总支出计算
            for (int i = 0; i < food.Length; i++)//循环遍历
            {
                foodzong += food[i];
            }
            labelfood.Text = foodzong.ToString();

            //交通总支出
            int[] jiaotong = db.rtn_expenditure_amount_type(us_name, "교통");
            int jiaotongzong = 0; //总支出计算
            for (int i = 0; i < jiaotong.Length; i++)//循环遍历
            {
                jiaotongzong += jiaotong[i];
            }
            labeljiaotong.Text = jiaotongzong.ToString();

            //医疗总支出
            int[] medc = db.rtn_expenditure_amount_type(us_name, "의료");
            int medczong = 0; //总支出计算
            for (int i = 0; i < medc.Length; i++)//循环遍历
            {
                medczong += medc[i];
            }
            labelmedc.Text = medczong.ToString();

            //生活总支出
            int[] shuidian = db.rtn_expenditure_amount_type(us_name, "생활");
            int shuidianzong = 0; //总支出计算
            for (int i = 0; i < shuidian.Length; i++)//循环遍历
            {
                shuidianzong += shuidian[i];
            }
            labelshuidian.Text = shuidianzong.ToString();

            //其他总支出
            int[] qita = db.rtn_expenditure_amount_type(us_name, "기타");
            int qitazong = 0; //总支出计算
            for (int i = 0; i < qita.Length; i++)//循环遍历
            {
                qitazong += qita[i];
            }
            labelqita.Text = qitazong.ToString();
            usersum = Convert.ToInt32(labelzongzhichu.Text);
            usermax = Convert.ToInt32(shangxian.Text);
            if (usersum < usermax * 0.5)
            {
                shangxian.ForeColor = Color.Green;
                labelzongzhichu.ForeColor = Color.Green;
            }
            else if (usersum >= usermax * 0.5 && usersum < usermax * 0.7)
            {
                shangxian.ForeColor = Color.Orange;
                labelzongzhichu.ForeColor = Color.Orange;
            }
            else if (usersum >= usermax * 0.7)
            {
                shangxian.ForeColor = Color.Red;
                labelzongzhichu.ForeColor = Color.Red;
            }


            db.dbclose();
        }

        private void Delete_Button_Click(object sender, EventArgs e)//删除条目的按钮
        {
            for (int i = expenditure_box.Items.Count - 1; i >= 0; i--)//做一个循环 循环遍历 expenditure_box里头已经被打勾的选项 然后把他删了,暂时没有联动数据库
            {
                if (expenditure_box.GetItemChecked(i))
                {
                    string selectedItem = expenditure_box.Items[i].ToString();//把选中的东西存成变量
                    db.dbopen();
                    db.del_expenditure_id(selectedItem);//删除!!
                    //更新expenditure_box
                    string[] tiaomu1 = db.rtn_expenditure_id_all(us_name);   //修改条目的checklistbox   跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!! 
                    expenditure_box.Items.Clear();//先清除expenditure_box.Items,再重新重数据库中遍历
                    foreach (string item in tiaomu1)//遍历写进items
                    {
                        expenditure_box.Items.Add(item); // 将数组中的每个元素添加为选项
                    }
                    db.dbclose();
                }
            }
            for (int i = income_box.Items.Count - 1; i >= 0; i--)
            {
                if (income_box.GetItemChecked(i))
                {
                    string selectedItem2 = income_box.Items[i].ToString();
                    db.dbopen();
                    db.del_income_id(selectedItem2);//删除!!
                    //更新income_box
                    string[] tiaomu2 = db.rtn_income_id_all(us_name);        //修改条目的checklistbox  跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
                    income_box.Items.Clear();//先清除income_box.Items,再重新重数据库中遍历
                    foreach (string item in tiaomu2)//遍历写进items
                    {
                        income_box.Items.Add(item); // 将数组中的每个元素添加为选项
                    }

                    usersum = Convert.ToInt32(labelzongzhichu.Text);
                    usermax = Convert.ToInt32(shangxian.Text);
                    if (usersum < usermax * 0.5)
                    {
                        shangxian.ForeColor = Color.Green;
                        labelzongzhichu.ForeColor = Color.Green;
                    }
                    else if (usersum >= usermax * 0.5 && usersum < usermax * 0.7)
                    {
                        shangxian.ForeColor = Color.Orange;
                        labelzongzhichu.ForeColor = Color.Orange;
                    }
                    else if (usersum >= usermax * 0.7)
                    {
                        shangxian.ForeColor = Color.Red;
                        labelzongzhichu.ForeColor = Color.Red;
                    }

                    db.dbclose();
                }
            }

            db.dbopen();

            //更新总支出
            int[] zhichu = db.rtn_expenditure_amount_all(us_name);//跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            int zongzhichujine = 0; //总支出计算
            for (int i = 0; i < zhichu.Length; i++)//循环遍历
            {
                zongzhichujine += zhichu[i];
            }
            labelzongzhichu.Text = zongzhichujine.ToString();//更改label
            //更新总收入
            int[] shouru = db.rtn_income_amount_all(us_name);//跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            int zongshourujine = 0; //总支出计算
            for (int i = 0; i < shouru.Length; i++)//循环遍历
            {
                zongshourujine += shouru[i];
            }
            labelzongshouru.Text = zongshourujine.ToString();//更改label
            //结余计算
            jieyu.Text = Convert.ToString(Convert.ToInt32(zongshourujine) - Convert.ToInt32(zongzhichujine));

            //饮食总支出
            int[] food = db.rtn_expenditure_amount_type(us_name, "식사");
            int foodzong = 0; //总支出计算
            for (int i = 0; i < food.Length; i++)//循环遍历
            {
                foodzong += food[i];
            }
            labelfood.Text = foodzong.ToString();

            //交通总支出
            int[] jiaotong = db.rtn_expenditure_amount_type(us_name, "교통");
            int jiaotongzong = 0; //总支出计算
            for (int i = 0; i < jiaotong.Length; i++)//循环遍历
            {
                jiaotongzong += jiaotong[i];
            }
            labeljiaotong.Text = jiaotongzong.ToString();

            //医疗总支出
            int[] medc = db.rtn_expenditure_amount_type(us_name, "의료");
            int medczong = 0; //总支出计算
            for (int i = 0; i < medc.Length; i++)//循环遍历
            {
                medczong += medc[i];
            }
            labelmedc.Text = medczong.ToString();

            //生活总支出
            int[] shuidian = db.rtn_expenditure_amount_type(us_name, "생활");
            int shuidianzong = 0; //总支出计算
            for (int i = 0; i < shuidian.Length; i++)//循环遍历
            {
                shuidianzong += shuidian[i];
            }
            labelshuidian.Text = shuidianzong.ToString();

            //其他总支出
            int[] qita = db.rtn_expenditure_amount_type(us_name, "기타");
            int qitazong = 0; //总支出计算
            for (int i = 0; i < qita.Length; i++)//循环遍历
            {
                qitazong += qita[i];
            }
            labelqita.Text = qitazong.ToString();

            usersum = Convert.ToInt32(labelzongzhichu.Text);
            usermax = Convert.ToInt32(shangxian.Text);
            if (usersum < usermax * 0.5)
            {
                shangxian.ForeColor = Color.Green;
                labelzongzhichu.ForeColor = Color.Green;
            }
            else if (usersum >= usermax * 0.5 && usersum < usermax * 0.7)
            {
                shangxian.ForeColor = Color.Orange;
                labelzongzhichu.ForeColor = Color.Orange;
            }
            else if (usersum >= usermax * 0.7)
            {
                shangxian.ForeColor = Color.Red;
                labelzongzhichu.ForeColor = Color.Red;
            }
            db.dbclose();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)//根据日期筛选条目
        {
            DateTime selectedDateTime = dateTimePicker1.Value;
            string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd");

            db.dbopen();
            string[] riqitiaomu = db.rtn_expenditure_id_two_inp(us_name, Convert.ToString(formattedDateTime));   //修改条目的checklistbox   跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!! 

            expenditure_box.Items.Clear();//先清除expenditure_box.Items,再重新重数据库中遍历

            foreach (string item in riqitiaomu)//遍历写进items
            {
                expenditure_box.Items.Add(item); // 将数组中的每个元素添加为选项
            }

            string[] riqitiaomu2 = db.rtn_income_id_two_inp(us_name, Convert.ToString(formattedDateTime));   //修改条目的checklistbox   跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!! 
            income_box.Items.Clear();//先清除expenditure_box.Items,再重新重数据库中遍历
            foreach (string item in riqitiaomu2)//遍历写进items
            {
                income_box.Items.Add(item); // 将数组中的每个元素添加为选项
            }
            usersum = Convert.ToInt32(labelzongzhichu.Text);
            usermax = Convert.ToInt32(shangxian.Text);
            if (usersum < usermax * 0.5)
            {
                shangxian.ForeColor = Color.Green;
                labelzongzhichu.ForeColor = Color.Green;
            }
            else if (usersum >= usermax * 0.5 && usersum < usermax * 0.7)
            {
                shangxian.ForeColor = Color.Orange;
                labelzongzhichu.ForeColor = Color.Orange;
            }
            else if (usersum >= usermax * 0.7)
            {
                shangxian.ForeColor = Color.Red;
                labelzongzhichu.ForeColor = Color.Red;
            }
            db.dbclose();
        }

        private void chushihuariqi_Click(object sender, EventArgs e)  //显示全部日期条目按钮
        {
            db.dbopen();

            string[] tiaomu1 = db.rtn_expenditure_id_all(us_name);   //修改条目的checklistbox   跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!! 
            expenditure_box.Items.Clear();//先清除expenditure_box.Items,再重新重数据库中遍历
            foreach (string item in tiaomu1)//遍历写进items
            {
                expenditure_box.Items.Add(item); // 将数组中的每个元素添加为选项
            }

            string[] tiaomu2 = db.rtn_income_id_all(us_name);        //修改条目的checklistbox  跟主界面相连的时候要修改一下!!!!!!!!!!!!!!!!!
            income_box.Items.Clear();//先清除income_box.Items,再重新重数据库中遍历
            foreach (string item in tiaomu2)//遍历写进items
            {
                income_box.Items.Add(item); // 将数组中的每个元素添加为选项
            }

            usersum = Convert.ToInt32(labelzongzhichu.Text);
            usermax = Convert.ToInt32(shangxian.Text);
            if (usersum < usermax * 0.5)
            {
                shangxian.ForeColor = Color.Green;
                labelzongzhichu.ForeColor = Color.Green;
            }
            else if (usersum >= usermax * 0.5 && usersum < usermax * 0.7)
            {
                shangxian.ForeColor = Color.Orange;
                labelzongzhichu.ForeColor = Color.Orange;
            }
            else if (usersum >= usermax * 0.7)
            {
                shangxian.ForeColor = Color.Red;
                labelzongzhichu.ForeColor = Color.Red;
            }
            db.dbclose();
        }
    }
}
