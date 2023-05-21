-- 创建家庭成员表
CREATE TABLE IF NOT EXISTS FamilyMembers (
    Name TEXT PRIMARY KEY
);

-- 创建收入表
CREATE TABLE IF NOT EXISTS Income (
    IncomeID INTEGER PRIMARY KEY AUTOINCREMENT,
    MemberName TEXT NOT NULL,
    IncomeDate DATE NOT NULL,
    IncomeAmount DECIMAL NOT NULL,
    IncomeNote TEXT,
    FOREIGN KEY (MemberName) REFERENCES FamilyMembers(Name)
);

-- 创建支出表
CREATE TABLE IF NOT EXISTS Expenses (
    ExpenseID INTEGER PRIMARY KEY AUTOINCREMENT,
    MemberName TEXT NOT NULL,
    ExpenseDate DATE NOT NULL,
    ExpenseAmount DECIMAL NOT NULL,
    ExpensePurpose TEXT NOT NULL,
    ExpenseNote TEXT,
    FOREIGN KEY (MemberName) REFERENCES FamilyMembers(Name)
);
