using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ledger
{
    public partial class AddUser : Form
    {
        string connectionString = "Data Source=info.db;Version=3;";
        private SQLiteConnection connection;
        public AddUser()
        {
            InitializeComponent();
        }
        public void AddUser_Load(object sender, EventArgs e)
        {
            //居中显示
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            
            //连接数据库 并打开
            connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("已成功连接到数据库。");
                }
                else
                {
                    MessageBox.Show("无法连接到数据库。");
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("连接数据库时发生错误: " + ex.Message);
            }
        }

        //程序关闭时关闭数据库
        public void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
               
                if (connection.State == ConnectionState.Closed)
                {
                    MessageBox.Show("数据库已关闭。");
                }
                else
                {
                    MessageBox.Show("数据库连接仍然打开");
                }
                connection.Dispose();
            }
        }


        //用来实现sql命令的 函数
        private void ExecuteSqlCommand(string sqlCommand)
        {
            try
            {
                // 创建SQLite命令对象
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = sqlCommand;
                    command.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                // 处理异常
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void BtnUserAdd_Click(object sender, EventArgs e)
        {
            // 执行插入操作
            string userName = UserNameText.Text; // 获取 TextBox 中的文本
            string insertSql = "INSERT INTO FamilyMembers (Name) VALUES (@Name)";

            using (SQLiteCommand command = new SQLiteCommand(insertSql, connection))
            {
                command.Parameters.AddWithValue("@Name", userName); // 添加参数
                command.ExecuteNonQuery();
            }
            this.Close();
        }
    }
}
