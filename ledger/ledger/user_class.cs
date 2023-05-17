using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.Entity.Spatial;

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

        public user_class(String name, String date)
        {
            //构造函数，初始化对象
            //插入初始值
            this.UserName = name;
            open_database();
            String sql_command_1 = $"INSERT INTO all_user_info(users_name, max_sum, moth_income, moth_expenditure, moth) VALUES ('{this.UserName}', 0, 0, 0, '{date}')";
            execute_sql(sql_command_1);
            String sql_command_3 = $"INSERT INTO how_to_use(users_name, today_date, eating, taking, medical, utility_bill, other) VALUES ({this.UserName}, '{now_moth})";
            execute_sql(sql_command_3);
        }

        private void connect_database()
        {
            //连接数据库
            String sqlpath = "user_info.db";
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
            connect_database();
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        private void execute_sql(String sql)
        {
            //执行一条非查询SQL语句
            open_database();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            close_database();
        }

        private DataTable select_sql(String sql)
        {
            //执行一条查询语句,返回一个datatable对象
            //应传入sql语句
            open_database();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader r = cmd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(r);
            r.Close();
            close_database();

            return t;
        }


        //返回数据的成员函数
        public String rtn_name()
        {
            //返回用户名
            return this.UserName;
        }


        //t1，t1中的日期格式yy-MM
        public int rtn_max_sum()
        {
            //上限金额
            open_database();
            String s = $"SELECT DISTINCT max_sum FROM all_user_info WHERE user_name={this.UserName}";
            DataTable tempt = select_sql(s);
            int i = Convert.ToInt32(tempt.Rows[0]["max_sum"]);
            close_database();

            return i;
        }

        public int rtn_moth_income(String now_moth)
        {
            //月收入
            open_database();
            String[] now_time = now_moth.Split('-');
            String need_time = now_time[0] + "-" +  now_time[1];
            String s = $"SELECT DISTINCT moth_income FROM all_user_info WHERE user_name={this.UserName} AND moth={need_time}";
            DataTable tempt = select_sql(s);
            int i = Convert.ToInt32(tempt.Rows[0]["moth_income"]);
            close_database();

            return i;
        }

        public int rtn_moth_expenditure(String now_moth)
        {
            //月支出
            open_database();
            String[] now_time = now_moth.Split('-');
            String need_time = now_time[0] + "-" + now_time[1];
            String s = $"SELECT DISTINCT moth_expenditure FROM all_user_info WHERE user_name={this.UserName} AND moth={need_time}";
            DataTable tempt = select_sql(s);
            int i = Convert.ToInt32(tempt.Rows[0]["moth_expenditure"]);
            close_database();

            return i;
        }

        public String rtn_moth(String now_moth)
        {
            //返还月份
            open_database();
            String[] now_time = now_moth.Split('-');
            String need_time = now_time[0] + "-" + now_time[1];
            String s = $"SELECT DISTINCT moth FROM all_user_info WHERE user_name={this.UserName} AND moth={need_time}";
            DataTable tempt = select_sql(s);
            String rtn = tempt.Rows[0]["moth"].ToString();
            close_database();

            return rtn;
        }

        //t2，t2中的日期格式yy-MM-dd
        public String rtn_today_date(String now_date)
        {
            //返回日期
            open_database();
            String s = $"SELECT DISTINCT today_date FROM income_and_expenditure WHERE user_name={this.UserName} AND today_date={now_date}";
            DataTable tempt = select_sql(s);
            String rtn = tempt.Rows[0]["today_date"].ToString();
            close_database();

            return rtn;
        }

        public int rtn_income_amount(String now_date)
        {
            //日收入金额
            open_database();
            String s = $"SELECT DISTINCT income_amount FROM income_and_expenditure WHERE user_name={this.UserName} AND today_date={now_date}";
            DataTable tempt = select_sql(s);
            int rtn = Convert.ToInt32(tempt.Rows[0]["income_amount"]);
            close_database();

            return rtn;
        }

        public String rtn_income_note(String now_date)
        {
            //日收入备注
            open_database();
            String s = $"SELECT DISTINCT income_note FROM income_and_expenditure WHERE user_name={this.UserName} AND today_date={now_date}";
            DataTable tempt = select_sql(s);
            String rtn = tempt.Rows[0]["income_note"].ToString();
            close_database();

            return rtn;
        }

        public int rtn_expenditure_amount(String now_date)
        {
            //日支出金额
            open_database();
            String s = $"SELECT DISTINCT expenditure_amount FROM income_and_expenditure WHERE user_name={this.UserName} AND today_date={now_date}";
            DataTable tempt = select_sql(s);
            int rtn = Convert.ToInt32(tempt.Rows[0]["expenditure_amount"]);
            close_database();

            return rtn;
        }

        public String rtn_expenditure_note(String now_date)
        {
            //日支出备注
            open_database();
            String s = $"SELECT DISTINCT expenditure_note FROM income_and_expenditure WHERE user_name={this.UserName} AND today_date={now_date}";
            DataTable tempt = select_sql(s);
            String rtn = tempt.Rows[0]["expenditure_note"].ToString();
            close_database();

            return rtn;
        }

        //t3，t3中的日期格式yy-MM-dd
        public int rtn_eating(String now_date)
        {
            //具体金额：吃
            open_database();
            String s = $"SELECT DISTINCT eating FROM how_to_use WHERE today_date={now_date}";
            DataTable tempt = select_sql(s);
            int rtn = Convert.ToInt32(tempt.Rows[0]["eating"]);
            close_database();

            return rtn;
        }

        public int rtn_taking(String now_date)
        {
            //具体金额：行
            open_database();
            String s = $"SELECT DISTINCT taking FROM how_to_use WHERE today_date={now_date}";
            DataTable tempt = select_sql(s);
            int rtn = Convert.ToInt32(tempt.Rows[0]["taking"]);
            close_database();

            return rtn;
        }

        public int rtn_medical(String now_date)
        {
            //具体金额：医药
            open_database();
            String s = $"SELECT DISTINCT medical FROM how_to_use WHERE today_date={now_date}";
            DataTable tempt = select_sql(s);
            int rtn = Convert.ToInt32(tempt.Rows[0]["medical"]);
            close_database();

            return rtn;
        }

        public int rtn_utility_bill(String now_date)
        {
            //具体金额：水电
            open_database();
            String s = $"SELECT DISTINCT utility_bill FROM how_to_use WHERE today_date={now_date}";
            DataTable tempt = select_sql(s);
            int rtn = Convert.ToInt32(tempt.Rows[0]["utility_bill"]);
            close_database();

            return rtn;
        }

        public int rtn_other(String now_date)
        {
            //具体金额：其他
            open_database();
            String s = $"SELECT DISTINCT other FROM how_to_use WHERE today_date={now_date}";
            DataTable tempt = select_sql(s);
            int rtn = Convert.ToInt32(tempt.Rows[0]["other"]);
            close_database();

            return rtn;
        }



        //更新插入成员函数
        
        //t1，moth
        public void insert_moth(String moth)
        {
            //创建一个新的列，用于一个新的月份
            String sql = $"INSERT INTO all_user_info(users_name, max_sum, moth_income, moth_expenditure, moth) VALUES ({this.UserName}, 0, 0, 0, {moth})";
            execute_sql(sql);
        }

        //t2，today_date，income_amount, expenditure_amount
        public void insert_date(String date, int income, int expenditure)
        {
            //给传入的日期创建一个新的列，收入支出日期
            String sql = $"INSERT INTO income_and_expenditure(users_name, today_date, income_amount, income_note, expenditure_amount, expenditure_note) VALUES ({this.UserName}, {date}, {income}, '...', {expenditure}, '...')";
            execute_sql(sql);
        }

        //t2，备注
        public void insert_note(String date, String note, int type)
        {
            //传入备注，收入备注type参数传1，支出备注type传2
            if (type == 1)
            {
                String sql = $"UPDATE income_and_expenditure SET income_note={note} WHERE users_name={this.UserName} AND today_date={date}";
                execute_sql(sql);
            }
            else
            {
                String sql = $"UPDATE income_and_expenditure SET expenditure_note={note} WHERE users_name={this.UserName} AND today_date={date}";
                execute_sql(sql);
            }
        }

        //t2,t1，更新某日收入支出
        public void update_amount_t2(String date, int amount, int type)
        {
            //传入需要修改的日期，金额，type参数用于辨别更新收入还是支出，更新收入传1，更新支出传2
            //在更新结束后自动更新t1月总收支
            if (type == 1)
            {
                String sql_1 = $"UPDATE income_and_expenditure SET income_amount={amount} WHERE users_name={this.UserName} AND today_date={date}";
                execute_sql(sql_1);
            }
            else
            {
                String sql_2 = $"UPDATE income_and_expenditure SET expenditure_amount={amount} WHERE users_name={this.UserName} AND today_date={date}";
                execute_sql(sql_2);
            }

            //更新t1收支部分
            String[] now_time = date.Split('-');
            
            String sql_income_amount = $"SELECT SUM(income_amount) FROM income_and_expenditure WHERE users_name='{this.UserName}' AND today_date LIKE '%-{now_time[1]}-%'";
            DataTable income_amount = select_sql(sql_income_amount);
            int income = Convert.ToInt32(income_amount.Rows[0][0]);
            String sql_expenditure_amount = $"SELECT SUM(expenditure_amount) FROM income_and_expenditure WHERE users_name='{this.UserName}' AND today_date LIKE '%-{now_time[1]}-%'";
            DataTable expenditure_amount = select_sql(sql_income_amount);
            int expenditure = Convert.ToInt32(expenditure_amount.Rows[0][0]);

            String need_date = now_time[0] + "-" + now_time[1];
            String sql_update = $"UPDATE all_user_info SET moth_income={income}, moth_expenditure={expenditure} WHERE users_name={this.UserName} AND moth={need_date}";
        }

        //更新t3表
        public void update_t3(String date, int amount, String type)
        {
            //更新t3表，date日的具体支出，type表示支出类型
            //type的值：eat -> eating吃, med -> medical医药, tak -> taking出行, utb -> utility_bill水电, oth -> other其他
            if (type == "eat")
            {
                String sql_1 = $"UPDATE how_to_use SET eating={amount} WHERE users_name={this.UserName} AND today_date='{date}'";
                execute_sql(sql_1);
            }
            else if (type == "med")
            {
                String sql_2 = $"UPDATE how_to_use SET medical={amount} WHERE users_name={this.UserName} AND today_date='{date}'";
                execute_sql(sql_2);
            }
            else if (type == "tak")
            {
                String sql_3 = $"UPDATE how_to_use SET taking={amount} WHERE users_name={this.UserName} AND today_date='{date}'";
                execute_sql(sql_3);
            }
            else if (type == "utb")
            {
                String sql_4 = $"UPDATE how_to_use SET utility_bill={amount} WHERE users_name={this.UserName} AND today_date='{date}'";
                execute_sql(sql_4);
            }
            else
            {
                String sql_5 = $"UPDATE how_to_use SET other={amount} WHERE users_name={this.UserName} AND today_date='{date}'";
                execute_sql(sql_5);
            }
        }
        }
    }
}
