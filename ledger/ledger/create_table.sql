--清空表
DROP TABLE user_info;
DROP TABLE income;
DROP TABLE expenditure;

--t1，用户，上限金额
CREATE TABLE user_info (
    u_id INTEGER PRIMARY KEY,
    users_name TEXT,
    max_sum INTEGER
);

--t2，收入，用户名，具体日期，日具体收入，日具体支出
CREATE TABLE income (
    income_id TEXT PRIMARY KEY,
    users_name TEXT,
    today_date TEXT,
    income_amount INTEGER,
    income_note TEXT,
    FOREIGN KEY (users_name) REFERENCES user_info (users_name)
);

--t3，日期，具体用途收支
CREATE TABLE expenditure (
    expenditure_id TEXT PRIMARY KEY,
    users_name TEXT,
    today_date TEXT,
    types TEXT,
    expenditure_amount INTEGER,
    expenditure_note TEXT,
    FOREIGN KEY (users_name) REFERENCES user_info (users_name)
);
