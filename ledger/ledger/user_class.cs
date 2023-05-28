using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.Entity.Spatial;
using System.Xml.Linq;

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

        public string[] rtn_name()
        {
            //返回所有名字

            String sql = $"SELECT users_name FROM user_info";
            DataTable dt = select_sql(sql);
            string[] dataArray = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataArray[i] = dt.Rows[i]["users_name"].ToString();
            }

            return dataArray;
        }

        public void del_user(String name)
        {
            //删除一个用户的所有信息

            String sql = $"DELETE FROM user_info WHERE users_name='{name}'";
            execute_sql(sql);

            return;
        }


        //t2操作, 日期 储存格式"yyyy-MM-dd HH:mm:ss"， 日期输入格式："yyyy-MM-dd"
        public void insert_new_income(String name, String today_date, int amount, String note)
        {
            //向收入表中插入新内容
            //需要输入 名字 日期 收入金额

            String pk = today_date + " " + amount.ToString() + " " + note;
            String sql = $"INSERT INTO income (income_id, users_name, today_date, income_amount, income_note) VALUES ('{pk}', '{name}', '{today_date}', {amount}, '{note}')";
            execute_sql (sql);

            return;
        }

        public int[] rtn_income_amount_all(String name)
        {
            //返回 名字为name的全部收入金额

            String sql = $"SELECT income_amount FROM income WHERE users_name='{name}'";
            DataTable dt = select_sql(sql);

            int[] dataArray = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataArray[i] = Convert.ToInt32(dt.Rows[i]["income_amount"]);
            }

            return dataArray;
        }

        public String[] rtn_income_id_two_inp(String name, String today_date)
        {
            //返回 收入 日期today_date所有name的id 

            String sql = $"SELECT income_id FROM income WHERE users_name='{name}' AND today_date LIKE '%{today_date}%'";
            DataTable dt = select_sql(sql);

            string[] dataArray = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataArray[i] = dt.Rows[i]["income_id"].ToString();
            }

            return dataArray;
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

        public void del_income_id(String exp_id)
        {
            //income_id

            String sql = $"DELETE FROM income WHERE income_id='{exp_id}'";
            execute_sql(sql);

            return;
        }


        //t3 操作， 日期 储存格式"yyyy-MM-dd HH:mm:ss"， 日期输入格式："yyyy-MM-dd"
        public void insert_new_expenditure(String name, String today_date, String types, int amount, String note)
        {
            //向支出表中插入新内容
            //需要输入 名字 日期 类型

            String pk = today_date + " " + amount.ToString() + " " + types + " " + note;
            String sql = $"INSERT INTO expenditure(expenditure_id, users_name, today_date, types, expenditure_amount, expenditure_note) VALUES('{pk}', '{name}', '{today_date}', '{types}', {amount}, '{note}')";
            execute_sql(sql);

            return;
        }

        public int[] rtn_expenditure_amount_type(String name, String types)
        {
            //返回具体支出金额
            //type eat = eating, tak = taking, med = medical, utb = utility_bill, oth = other

            String sql;

            sql = $"SELECT expenditure_amount FROM expenditure WHERE users_name='{name}' AND types='{types}'";
            DataTable dt = select_sql(sql);
            int[] dataArray = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataArray[i] = Convert.ToInt32(dt.Rows[i]["expenditure_amount"]);
            }

            return dataArray;
        }

        public int[] rtn_expenditure_amount_type_with_date(String name, String types, String today_date)
        {
            //返回具体支出金额 需要日期搜索 日期输入格式"yyyy-MM"
            //type eat = eating, tak = taking, med = medical, utb = utility_bill, oth = other

            String sql;

            sql = $"SELECT expenditure_amount FROM expenditure WHERE users_name='{name}' AND types='{types}' AND today_date LIKE '%{today_date}%'";
            DataTable dt = select_sql(sql);
            int[] dataArray = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataArray[i] = Convert.ToInt32(dt.Rows[i]["expenditure_amount"]);
            }

            return dataArray;
        }

        public int[] rtn_expenditure_amount_all(String name)
        {
            //返回 名字为name的全部支出金额

            String sql = $"SELECT expenditure_amount FROM expenditure WHERE users_name='{name}'";
            DataTable dt = select_sql(sql);

            int[] dataArray = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataArray[i] = Convert.ToInt32(dt.Rows[i]["expenditure_amount"]);
            }

            return dataArray;
        }

        public String[] rtn_expenditure_id_two_inp(String name, String today_date)
        {
            //返回支出的id 传参name和日期today_date, 依据月份分类输入日期格式"yyyy-MM"即可
            String sql = $"SELECT expenditure_id FROM expenditure WHERE users_name='{name}' AND today_date LIKE '%{today_date}%'";
            DataTable dt = select_sql(sql);
            string[] dataArray = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataArray[i] = dt.Rows[i]["expenditure_id"].ToString();
            }

            return dataArray;
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

        public void del_expenditure_id(String exp_id)
        {
            //删除expenditure_id

            String sql = $"DELETE FROM expenditure WHERE expenditure_id='{exp_id}'";
            execute_sql(sql);

            return;
        }
    }
}