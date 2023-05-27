--清空表
DROP TABLE user_info;
DROP TABLE income;
DROP TABLE expenditure;

--t1，用户，上限金额
CREATE TABLE user_info (
    users_name TEXT PRIMARY KEY,
    max_sum INTEGER
);

--t2，收入，用户名，具体日期，日具体收入，日具体支出
CREATE TABLE income (
    users_name TEXT PRIMARY KEY,
    today_date TEXT,
    income_amount INTEGER,
    income_note TEXT,
    FOREIGN KEY (users_name) REFERENCES user_info (users_name)
);

--t3，日期，具体用途收支
CREATE TABLE expenditure (
    users_name TEXT PRIMARY KEY,
    today_date TEXT,
    eating INTEGER,
    taking INTEGER,
    medical INTEGER,
    utility_bill INTEGER,
    other INTEGER,
    expenditure_noate TEXT,
    FOREIGN KEY (users_name) REFERENCES user_info (users_name)
);

DELETE FROM user_info WHERE users_name='{name}';