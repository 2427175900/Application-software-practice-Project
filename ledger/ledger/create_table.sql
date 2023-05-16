--t1，用户，上限金额，月收入，月支出，月份
CREATE TABLE all_user_info (
    users_name TEXT PRIMARY KEY,
    max_sum INTEGER,
    moth_income INTEGER,
    moth_expenditure INTEGER,
    moth TEXT
);

--t2，用户名，具体日期，金钱用途（/来源），日具体收入，日具体支出，用途备注（/来源备注）
CREATE TABLE income_and_expenditure (
    users_name TEXT PRIMARY KEY,
    today_date TEXT,
    income_from TEXT,
    income_amount INTEGER,
    income_note TEXT,
    expenditure_where TEXT,
    expenditure_amount INTEGER,
    expenditure_note TEXT
);

--t3，日期，具体用途收支
CREATE TABLE how_to_use (
    today_date TEXT PRIMARY KEY,
    eating INTEGER,
    taking INTEGER,
    medical INTEGER,
    utility_bill INTEGER,
    other INTEGER
);