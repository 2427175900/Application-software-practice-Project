using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ledger
{
    internal class user_class
    {
        //对象类，用于操作数据库等
        //查询所有数据
        //插入修改 t1名字，金额上限，月份；t2日期，收入来源、金额、备注，支出地方、金额、备注；t3，各个支出具体金额
        //删除t1名字-t2-t3，t1月-t1月收支-t2月的具体日期收支情况-t3，t2日期-t2数据-t3-修改t1，t2全部内容支持删除

        String UserName;
        SQLiteConnection conn;

        public user_class(String name)
        {
            //构造函数，初始化对象
            //插入初始值
            this.UserName = name;
            open_database();
            String sql_command = $"INSERT INTO all_user_info(users_name, max_sum, moth_income, moth_expenditure, moth) VALUES ({this.UserName}, 0, 0, 0, 0)";
            execute_sql(sql_command);
        }

        private void connect_database()
        {
            //连接数据库
            String sqlpath = "info.db";
            conn = new SQLiteConnection("Data Source=" + sqlpath);
        }

        private void open_database()
        {
            //打开数据库
            connect_database();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private void close_database()
        {
            //关闭数据库
            connect_database() ;
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        private void execute_sql(String sql)
        {
            //执行一条非查询SQL语句
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        private DataTable select_sql(String sql)
        {
            //执行一条查询语句,返回一个datatable对象
            //应传入sql语句
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader r = cmd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(r);
            r.Close();
            
            return t;
        }

        //返回数据的成员函数
        public String rtn_name()
        {
            //返回用户名
            return this.UserName;
        }

        //要改
        public int rtn_max_sum()
        {
            //上限金额
            open_database();
            String s = $"SELECT max_sum FROM all_user_info WHERE user_name={this.UserName}";
            DataTable tempt = select_sql(s);
            int i = Convert.ToInt32(tempt.Rows[0]["max_sum"]);

            return i;
        }

        public int rtn_moth_income()
        {
            //月收入
            open_database();
            String s = $"SELECT moth_income FROM all_user_info WHERE user_name={this.UserName}";
            DataTable tempt = select_sql(s);
            int i = Convert.ToInt32(tempt.Rows[0]["moth_income"]);

            return i;
        }

        public int rtn_moth_expenditure()
        {
            //月支出
            open_database();
            String s = $"SELECT moth_expenditure FROM all_user_info WHERE user_name={this.UserName}";
            DataTable tempt = select_sql(s);
            int i = Convert.ToInt32(tempt.Rows[0]["moth_expenditure"]);

            return i;
        }

        public String rtn_moth()
        {
            //返还月份
            open_database();
            String s = $"SELECT moth FROM all_user_info WHERE user_name={this.UserName}";
            DataTable tempt = select_sql(s);
        }
    }