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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.Replace(" ", ""); // 移除空格
        }

        //点击按钮的时候 把 name  插入到数据库
        private void button1_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;

            //储存的用户小于10 的时候 进行插入操作
            if (maxUser())
            {
                //接收所有用户名到 names
                string[] names = (db.rtn_name());

                //在没有用户的情况下, 直接进行插入
                if (names.Length > 0)
                {


                    for (int i = 0; i < names.Length; i++)
                    {
                        //用户名是否已存在判断
                        if (names[i] == name)
                        {
                            MessageBox.Show("\"" + name + "\"" + " 사용자 존재합니다. 다시해주세요.");
                            break;
                        }
                        else
                        {

                            db.insert_new(name);
                            MessageBox.Show("사용자" + "\"" + name + "\"" + "가 추가완료 되었습니다.");
                            break;


                        }
                    }

                }
                else if(name == null)
                {
                    MessageBox.Show("사용자 이름 입력해주세요");
                }
                else//插入操作完成后 弹窗提示
                {
                    db.insert_new(name);
                    MessageBox.Show("사용자" + "\"" + name + "\"" + "가 추가완료 되었습니다.");
                }
                //插入完成后关闭该窗口
                this.Close();
            }
            //用户数 超过10 的情况 弹窗提示后关闭窗口
            else
            {
                MessageBox.Show("사용자 수가 10명이 넘었습니다. 추가 볼가능 합니다.");
                this.Close();
            }
        }

        // 检测储存的用户是否大于10 
        private bool maxUser()
        {

            string[] names = (db.rtn_name());
            if(names.Length >= 10) {
                return false;
            }
            return true;
        }
    }
}
