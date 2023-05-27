using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.Entity.Spatial;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ledger
{
    public class database
    {
        SQLiteConnection conn;

        //构造函数，连接数据库
        public database()
        {
            String sqlname = "Data Source=user_info.db";
            this.conn = new SQLiteConnection(sqlname);
        }

        //打开数据库
        public void dbopen()
        {
            this.conn.Open();
        }

        //关闭数据库
        public void dbclose()
        {
            this.conn.Close();
        }

        private void execute_sql(String sql)
        {
            //执行一条非查询SQL语句
            SQLiteCommand cmd = new SQLiteCommand(sql, this.conn);
            cmd.ExecuteNonQuery();

            return;
         }

        private DataTable select_sql(String sql)
        {
            //执行一条查询语句,返回一个datatable对象
            //应传入sql语句
            SQLiteCommand cmd = new SQLiteCommand(sql, this.conn);
            SQLiteDataReader r = cmd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(r);
            r.Close();

            return t;
        }
        
        //t1操作
        public void insert_new(String name)
        {
            //创建一个新用户，名字为name
            
            String sql = $"INSERT INTO user_info (users_name, max_sum) VALUES ('{name}', 0)";
            execute_sql(sql);

            return;
        }

        public void update_max_sum(String name, int count)
        {
            //将用户name的上限金额更新为count

            String sql = $"UPDATE user_info SET max_sum={count} WHERE users_name='{name}'";
            execute_sql(sql);

            return;
        }

        public int get_max_sum(String name)
        {
            //返回用户name的上限金额

            String sql = $"SELECT max_sum FROM user_info WHERE users_name='{name}'";
            DataTable dt = select_sql(sql);
           int i = Convert.ToInt32(dt.Rows[0]["max_sum"]);

            return i;
        }

        //t2操作
        public void insert_new_income(String name, String today_date, int amount)
        {
            //向收入表中插入新内容
            //需要输入 名字 日期 收入金额

            String sql = $"INSERT INTO income (users_name, today_date, income_amount, income_note) VALUES ('{name}', '{today_date}', {amount}, 'None')";
            execute_sql (sql);

            return;
        }

        public void update_income_note(String  name, String today_date, String note)
        {
            //给 日期为today_date，用户为name的收入条目更新 note

            String sql = $"UPDATE income SET income_note='{note}' WHERE users_name='{name}' AND today_date='{today_date}'";
            execute_sql (sql);

            return;
        }

        public int rtn_income_amount(String name, String today_date)
        {
            //返回 日期为today_date名字为name的收入金额

            String sql = $"SELECT income_amount FROM income WHERE users_name='{name}' AND today_date='{today_date}'";
            DataTable dt = select_sql (sql);
            int rtn = Convert.ToInt32(dt.Rows[0]["amount"]);

            return rtn;
        }

        public String rtn_income_note(String name, String today_date)
        {
            //返回 日期为today_date名字为name的note

            String sql = $"SELECT income_note FROM income WHERE users_name='{name}' AND today_date='{today_date}'";
            DataTable dt = select_sql(sql);
            String rtn = dt.Rows[0]["note"].ToString();

            return rtn;
        }

        //t3 支出表
        public void insert_new_expenditure(String name, String today_date)
        {
            //向支出表中插入新内容
            //需要输入 名字 日期 收入金额

            String sql = $"INSERT INTO expenditure(users_name, today_date, eating, taking, medical, utility_bill, other, expenditure_note) VALUES('{name}', '{today_date}', 0, 0, 0, 0, 0, 'None')";
            execute_sql(sql);

            return;
        }

        public void update_exoenditure_amount(String name, String today_date, String type, int amount)
        {
            //更新支出表的具体金额
            //type eat = eating, tak = taking, med = medical, utb = utility_bill, oth = other

            if (type == "eat")
            {
                String sql = $"UPDATE expenditure SET eating={amount} WHERE users_name='{name}' AND today_date='{today_date}'";
                execute_sql(sql);
            }
            else if (type == "tak")
            {
                String sql = $"UPDATE expenditure SET taking={amount} WHERE users_name='{name}' AND today_date='{today_date}'";
                execute_sql(sql);
            }
            else if (type == "med")
            {
                String sql = $"UPDATE expenditure SET medical={amount} WHERE users_name='{name}' AND today_date='{today_date}'";
                execute_sql(sql);
            }
            else if (type == "utb")
            {
                String sql = $"UPDATE expenditure SET utility_bill={amount} WHERE users_name='{name}' AND today_date='{today_date}'";
                execute_sql(sql);
            }
            else if (type == "oth")
            {
                String sql = $"UPDATE expenditure SET other={amount} WHERE users_name='{name}' AND today_date='{today_date}'";
                execute_sql(sql);
            }

            return;
        }

        public int rtn_expenditure_amount(String name, String today_date, String type )
        {
            //返回具体支出金额
            //type eat = eating, tak = taking, med = medical, utb = utility_bill, oth = other

            int rtn;
            String sql;

            if (type == "eat")
            {
                sql = $"SELECT eating FROM expenditure WHERE users_name='{name}' AND today_date='{today_date}''";
                DataTable dt = select_sql(sql);
                rtn = Convert.ToInt32(dt.Rows[0]["eating"]);

                return rtn;
            }
            else if (type == "tak")
            {
                sql = $"SELECT taking FROM expenditure WHERE users_name='{name}' AND today_date='{today_date}''";
                DataTable dt = select_sql(sql);
                rtn = Convert.ToInt32(dt.Rows[0]["taking"]);

                return rtn;
            }
            else if (type == "med")
            {
                sql = $"SELECT medical FROM expenditure WHERE users_name='{name}' AND today_date='{today_date}''";
                DataTable dt = select_sql(sql);
                rtn = Convert.ToInt32(dt.Rows[0]["medical"]);

                return rtn;
            }
            else if (type == "utb")
            {
                sql = $"SELECT utiliby_bill FROM expenditure WHERE users_name='{name}' AND today_date='{today_date}''";
                DataTable dt = select_sql(sql);
                rtn = Convert.ToInt32(dt.Rows[0]["utility_bill"]);

                return rtn;
            }
            else
            {
                sql = $"SELECT other FROM expenditure WHERE users_name='{name}' AND today_date='{today_date}''";
                DataTable dt = select_sql(sql);
                rtn = Convert.ToInt32(dt.Rows[0]["other"]);

                return rtn;
            }
        }

        public void update_expenditure_note(String name, String today_date, String note)
        {
            //给 日期为today_date，用户为name的支出条目更新 note

            String sql = $"UPDATE expenditure SET income_note='{note}' WHERE users_name='{name}' AND today_date='{today_date}'";
            execute_sql(sql);

            return;
        }

        public String rtn_expenditure_note(String name, String today_date)
        {
            //返回 日期为today_date名字为name的note 支出

            String sql = $"SELECT expenditure_note FROM income WHERE users_name='{name}' AND today_date='{today_date}'";
            DataTable dt = select_sql(sql);
            String rtn = dt.Rows[0]["note"].ToString();

            return rtn;
        }
    }
}