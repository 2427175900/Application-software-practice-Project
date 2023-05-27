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
            SQLiteCommand cmd = new SQLiteCommand("PRAGMA foreign_keys = ON", this.conn);
            cmd.ExecuteNonQuery();
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
            /*
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            String pk = name + randomNumber.ToString();
           */
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

        public int rtn_max_sum(String name)
        {
            //返回用户name的上限金额

            String sql = $"SELECT max_sum FROM user_info WHERE users_name='{name}'";
            DataTable dt = select_sql(sql);
           int i = Convert.ToInt32(dt.Rows[0]["max_sum"]);

            return i;
        }

        public string rtn_name(String name)
        {
            //返回名字

            String sql = $"SELECT users_name FROM user_info WHERE users_name='{name}'";
            DataTable dt = select_sql(sql);
            String rtn = dt.Rows[0]["uusers_name"].ToString();

            return rtn;
        }

        public void del_user(String name)
        {
            //删除一个用户的所有信息

            String sql = $"DELETE FROM user_info WHERE users_name='{name}'";
            execute_sql(sql);

            return;
        }

        //t2操作
        public void insert_new_income(String name, String today_date, int amount)
        {
            //向收入表中插入新内容
            //需要输入 名字 日期 收入金额

            String pk = today_date + " " + amount.ToString() + " " + "None";
            String sql = $"INSERT INTO income (income_id, users_name, today_date, income_amount, income_note) VALUES ('{pk}', '{name}', '{today_date}', {amount}, 'None')";
            execute_sql (sql);

            return;
        }

        public void update_income_note(String  name, String today_date, String note)
        {
            //给 日期为today_date，用户为name的收入条目更新 note

            String sql = $"UPDATE income SET income_note='{note}' WHERE users_name='{name}' AND today_date='{today_date}'";
            execute_sql (sql);

            String str = today_date + " " + rtn_income_amount(name, today_date).ToString() + " " + note;
            String sql2 = $"UPDATE income SET income_id='{str}' WHERE users_name='{name}' AND today_date='{today_date}'";
            execute_sql(sql2);

            return;
        }

        public int rtn_income_amount(String name, String today_date)
        {
            //返回 日期为today_date名字为name的收入金额

            String sql = $"SELECT income_amount FROM income WHERE users_name='{name}' AND today_date='{today_date}'";
            DataTable dt = select_sql (sql);
            int rtn = Convert.ToInt32(dt.Rows[0]["income_amount"]);

            return rtn;
        }

        public String rtn_income_note(String name, String today_date)
        {
            //返回 日期为today_date名字为name的note

            String sql = $"SELECT income_note FROM income WHERE users_name='{name}' AND today_date='{today_date}'";
            DataTable dt = select_sql(sql);
            String rtn = dt.Rows[0]["income_note"].ToString();

            return rtn;
        }

        public String rtn_income_id(String name, String today_date)
        {
            //返回收入的id

            String sql = $"SELECT income_id FROM income WHERE users_name='{name}' AND today_date='{today_date}'";
            DataTable dt = select_sql(sql);
            String rtn = dt.Rows[0]["income_id"].ToString();

            return rtn;
        }

        public String[] rtn_income_id_all(String name)
        {
            //返回收入所有name的id 日期降序排列

            String sql = $"SELECT income_id FROM income WHERE users_name='{name}' ORDER BY today_date DESC";
            DataTable dt = select_sql(sql);

            string[] dataArray = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataArray[i] = dt.Rows[i]["income_id"].ToString();
            }

            return dataArray;
        }

        public void del_income(String name, String today_date)
        {
            //删除用户 name 于日期today_date的行

            String sql = $"DELETE FROM income WHERE users_name='{name}' AND today_date='{today_date}'";
            execute_sql(sql);

            return;
        }

        public void del_income_id(String exp_id)
        {
            //income_id

            String sql = $"DELETE FROM income WHERE income_id='{exp_id}'";
            execute_sql(sql);

            return;
        }


        //t3 操作
        public void insert_new_expenditure(String name, String today_date, String types)
        {
            //向支出表中插入新内容
            //需要输入 名字 日期 类型

            String pk = today_date + " " + 0 + " " + types + " ";
            String sql = $"INSERT INTO expenditure(expenditure_id, users_name, today_date, types, expenditure_amount, expenditure_note) VALUES('{pk}', '{name}', '{today_date}', '{types}', 0, 'None')";
            execute_sql(sql);

            return;
        }

        public void update_expenditure_amount(String name, String today_date, String types, int amount)
        {
            //更新支出表的具体金额
            //type eat = eating, tak = taking, med = medical, utb = utility_bill, oth = other

            String sql = $"UPDATE expenditure SET types='{types}', expenditure_amount={amount} WHERE users_name='{name}' AND today_date='{today_date}'";
            execute_sql(sql);

            String str = today_date + " " + types + " " + amount.ToString() + " " + rtn_expenditure_note(name, today_date, types);
            String sql2 = $"UPDATE expenditure SET expenditure_id='{str}' WHERE users_name='{name}' AND today_date='{today_date}' AND types='{types}'";
            execute_sql(sql2);

            return;
        }

        public int rtn_expenditure_amount(String name, String today_date, String types)
        {
            //返回具体支出金额
            //type eat = eating, tak = taking, med = medical, utb = utility_bill, oth = other

            int rtn;
            String sql;

            sql = $"SELECT expenditure_amount FROM expenditure WHERE users_name='{name}' AND today_date='{today_date}' AND types='{types}'";
            DataTable dt = select_sql(sql);
            rtn = Convert.ToInt32(dt.Rows[0]["expenditure_amount"]);

            return rtn;
        }

        public void update_expenditure_note(String name, String today_date, String types, String note)
        {
            //给 日期为today_date，用户为name，类型为types的支出条目更新 note

            String sql = $"UPDATE expenditure SET expenditure_note='{note}' WHERE users_name='{name}' AND today_date='{today_date}' AND types='{types}'";
            execute_sql(sql);

            String str = today_date + " " + types + " " + rtn_expenditure_amount(name, today_date, types).ToString() + " " + note;
            String sql2 = $"UPDATE expenditure SET expenditure_id='{str}' WHERE users_name='{name}' AND today_date='{today_date}' AND types='{types}'";
            execute_sql(sql2);

            return;
        }

        public String rtn_expenditure_note(String name, String today_date, String types)
        {
            //返回 日期为today_date名字为name的note 支出

            String sql = $"SELECT expenditure_note FROM expenditure WHERE users_name='{name}' AND today_date='{today_date}' AND types='{types}'";
            DataTable dt = select_sql(sql);
            String rtn = dt.Rows[0]["expenditure_note"].ToString();

            return rtn;
        }

        public String rtn_expenditure_id(String name, String today_date, String types)
        {
            //返回支出的id
            String sql = $"SELECT expenditure_id FROM expenditure WHERE users_name='{name}' AND today_date='{today_date}' AND types='{types}'";
            DataTable dt = select_sql(sql);
            String rtn = dt.Rows[0]["expenditure_id"].ToString();

            return rtn;
        }

        public String[] rtn_expenditure_id_all(String name)
        {
            //返回收入的id,日期降序排列

            String sql = $"SELECT expenditure_id FROM expenditure WHERE users_name='{name}' ORDER BY today_date DESC";
            DataTable dt = select_sql(sql);

            string[] dataArray = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataArray[i] = dt.Rows[i]["expenditure_id"].ToString();
            }

            return dataArray;
        }

        public void del_expenditure(String name, String today_date, String types)
        {
            //删除用户 name 于日期today_date，类型为types的行

            String sql = $"DELETE FROM expenditure WHERE users_name='{name}' AND today_date='{today_date}' AND types='{types}'";
            execute_sql(sql);

            return;
        }

        public void del_expenditure_id(String exp_id)
        {
            //删除expenditure_id

            String sql = $"DELETE FROM expenditure WHERE expenditure_id='{exp_id}'";
            execute_sql(sql);

            return;
        }
    }
}