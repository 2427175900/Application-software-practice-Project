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

        //窗口开始时连接数据库
        private void AddUser_Load(object sender, EventArgs e)
        {
            // 在窗口加载时建立数据库连接
            string connectionString = "Data Source=info.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
            connection.Open();

            // 检测数据库连接是否成功
            if (connection.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("数据库连接成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("数据库连接失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //窗口关闭时关闭数据库
        private void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 在窗口关闭时关闭数据库连接
            connection.Close();

            // 检测数据库连接是否成功关闭
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                MessageBox.Show("数据库连接已成功关闭！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("无法关闭数据库连接！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            SQLiteTransaction transaction = null;

            try
            {
                // 开始事务
                transaction = connection.BeginTransaction();

                // 创建插入命令
                string insertQuery = "INSERT INTO FamilyMembers (Name) VALUES (@Name)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    // 执行插入命令前的行数
                    int rowCountBefore = GetRowCount();

                    // 执行插入命令
                    command.ExecuteNonQuery();

                    // 执行插入命令后的行数
                    int rowCountAfter = GetRowCount();

                    // 显示行数
                    string message = $"插入前行数：{rowCountBefore}\n插入后行数：{rowCountAfter}";
                    MessageBox.Show(message, "行数", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 提交事务
                transaction.Commit();

                // 显示数据插入成功提示
                MessageBox.Show("数据已成功插入！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // 回滚事务
                transaction?.Rollback();

                MessageBox.Show("插入数据时出现错误：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 关闭连接
                connection.Close();
                this.Close();
            }

            //string nameToCheck = "wang";

            // 创建查询命令
            //string selectQuery = "SELECT COUNT(*) FROM FamilyMembers WHERE Name = @Name";
            //using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            //{
            //    command.Parameters.AddWithValue("@Name", nameToCheck);

            //    int count = Convert.ToInt32(command.ExecuteScalar());

            //    // 检查数据是否存在
            //    if (count > 0)
            //    {
            //        MessageBox.Show("数据存在！", "存在", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("数据不存在！", "不存在", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        // 获取数据库中的行数
        private int GetRowCount()
        {
            string countQuery = "SELECT COUNT(*) FROM FamilyMembers";
            using (SQLiteCommand command = new SQLiteCommand(countQuery, connection))
            {
                int rowCount = Convert.ToInt32(command.ExecuteScalar());
                return rowCount;
            }
        }
    }
}
