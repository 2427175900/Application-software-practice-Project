namespace ledger
{
    partial class personal_ledger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.user_name = new System.Windows.Forms.Label();
            this.上限金额 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shangxian = new System.Windows.Forms.Label();
            this.Amount_modification = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chushihuariqi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.income_box = new System.Windows.Forms.CheckedListBox();
            this.expenditure_box = new System.Windows.Forms.CheckedListBox();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Add_Button = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelqita = new System.Windows.Forms.Label();
            this.labelshuidian = new System.Windows.Forms.Label();
            this.labelmedc = new System.Windows.Forms.Label();
            this.labeljiaotong = new System.Windows.Forms.Label();
            this.labelfood = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.jieyu = new System.Windows.Forms.Label();
            this.labelzongshouru = new System.Windows.Forms.Label();
            this.labelzongzhichu = new System.Windows.Forms.Label();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Location = new System.Drawing.Point(705, 25);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // user_name
            // 
            this.user_name.AutoSize = true;
            this.user_name.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.user_name.Location = new System.Drawing.Point(28, 21);
            this.user_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(58, 29);
            this.user_name.TabIndex = 1;
            this.user_name.Text = "yzx";
            // 
            // 上限金额
            // 
            this.上限金额.AutoSize = true;
            this.上限金额.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.上限金额.Location = new System.Drawing.Point(9, 18);
            this.上限金额.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.上限金额.Name = "上限金额";
            this.上限金额.Size = new System.Drawing.Size(114, 24);
            this.上限金额.TabIndex = 2;
            this.上限金额.Text = "제한금액:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shangxian);
            this.groupBox1.Controls.Add(this.Amount_modification);
            this.groupBox1.Controls.Add(this.上限金额);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(20, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(200, 136);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // shangxian
            // 
            this.shangxian.AutoSize = true;
            this.shangxian.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.shangxian.Location = new System.Drawing.Point(20, 56);
            this.shangxian.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.shangxian.Name = "shangxian";
            this.shangxian.Size = new System.Drawing.Size(57, 20);
            this.shangxian.TabIndex = 4;
            this.shangxian.Text = "label2";
            // 
            // Amount_modification
            // 
            this.Amount_modification.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Amount_modification.Location = new System.Drawing.Point(7, 89);
            this.Amount_modification.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Amount_modification.Name = "Amount_modification";
            this.Amount_modification.Size = new System.Drawing.Size(131, 41);
            this.Amount_modification.TabIndex = 3;
            this.Amount_modification.Text = "수정";
            this.Amount_modification.UseVisualStyleBackColor = true;
            this.Amount_modification.Click += new System.EventHandler(this.Amount_modification_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chushihuariqi);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.income_box);
            this.groupBox2.Controls.Add(this.expenditure_box);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.Delete_Button);
            this.groupBox2.Controls.Add(this.Add_Button);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(20, 200);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(940, 330);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "장부";
            // 
            // chushihuariqi
            // 
            this.chushihuariqi.Location = new System.Drawing.Point(509, 25);
            this.chushihuariqi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chushihuariqi.Name = "chushihuariqi";
            this.chushihuariqi.Size = new System.Drawing.Size(174, 25);
            this.chushihuariqi.TabIndex = 7;
            this.chushihuariqi.Text = "전제 보기";
            this.chushihuariqi.UseVisualStyleBackColor = true;
            this.chushihuariqi.Click += new System.EventHandler(this.chushihuariqi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(485, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "수입";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "지출";
            // 
            // income_box
            // 
            this.income_box.CheckOnClick = true;
            this.income_box.FormattingEnabled = true;
            this.income_box.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.income_box.Location = new System.Drawing.Point(485, 92);
            this.income_box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.income_box.Name = "income_box";
            this.income_box.Size = new System.Drawing.Size(420, 214);
            this.income_box.TabIndex = 3;
            // 
            // expenditure_box
            // 
            this.expenditure_box.CheckOnClick = true;
            this.expenditure_box.FormattingEnabled = true;
            this.expenditure_box.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.expenditure_box.Location = new System.Drawing.Point(24, 92);
            this.expenditure_box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.expenditure_box.Name = "expenditure_box";
            this.expenditure_box.Size = new System.Drawing.Size(420, 214);
            this.expenditure_box.TabIndex = 2;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(158, 25);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(119, 26);
            this.Delete_Button.TabIndex = 1;
            this.Delete_Button.Text = "삭제";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(24, 25);
            this.Add_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(119, 26);
            this.Add_Button.TabIndex = 0;
            this.Add_Button.Text = "추가";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelqita);
            this.groupBox3.Controls.Add(this.labelshuidian);
            this.groupBox3.Controls.Add(this.labelmedc);
            this.groupBox3.Controls.Add(this.labeljiaotong);
            this.groupBox3.Controls.Add(this.labelfood);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(507, 21);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(451, 170);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "당월 소비";
            // 
            // labelqita
            // 
            this.labelqita.AutoSize = true;
            this.labelqita.Location = new System.Drawing.Point(160, 122);
            this.labelqita.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelqita.Name = "labelqita";
            this.labelqita.Size = new System.Drawing.Size(57, 16);
            this.labelqita.TabIndex = 9;
            this.labelqita.Text = "label14";
            // 
            // labelshuidian
            // 
            this.labelshuidian.AutoSize = true;
            this.labelshuidian.Location = new System.Drawing.Point(18, 122);
            this.labelshuidian.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelshuidian.Name = "labelshuidian";
            this.labelshuidian.Size = new System.Drawing.Size(56, 16);
            this.labelshuidian.TabIndex = 8;
            this.labelshuidian.Text = "label13";
            // 
            // labelmedc
            // 
            this.labelmedc.AutoSize = true;
            this.labelmedc.Location = new System.Drawing.Point(304, 59);
            this.labelmedc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelmedc.Name = "labelmedc";
            this.labelmedc.Size = new System.Drawing.Size(56, 16);
            this.labelmedc.TabIndex = 7;
            this.labelmedc.Text = "label12";
            // 
            // labeljiaotong
            // 
            this.labeljiaotong.AutoSize = true;
            this.labeljiaotong.Location = new System.Drawing.Point(160, 59);
            this.labeljiaotong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeljiaotong.Name = "labeljiaotong";
            this.labeljiaotong.Size = new System.Drawing.Size(56, 16);
            this.labeljiaotong.TabIndex = 6;
            this.labeljiaotong.Text = "label11";
            // 
            // labelfood
            // 
            this.labelfood.AutoSize = true;
            this.labelfood.Location = new System.Drawing.Point(18, 59);
            this.labelfood.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelfood.Name = "labelfood";
            this.labelfood.Size = new System.Drawing.Size(56, 16);
            this.labelfood.TabIndex = 5;
            this.labelfood.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(160, 93);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "개인 기타:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 93);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "생활:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "의료:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "교통:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "식사:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 34);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 16);
            this.label15.TabIndex = 11;
            this.label15.Text = "지출합계";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 86);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 16);
            this.label16.TabIndex = 12;
            this.label16.Text = "수입합계";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 136);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 16);
            this.label17.TabIndex = 13;
            this.label17.Text = "잔금";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.jieyu);
            this.groupBox4.Controls.Add(this.labelzongshouru);
            this.groupBox4.Controls.Add(this.labelzongzhichu);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.Location = new System.Drawing.Point(227, 20);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(237, 170);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // jieyu
            // 
            this.jieyu.AutoSize = true;
            this.jieyu.Location = new System.Drawing.Point(108, 136);
            this.jieyu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.jieyu.Name = "jieyu";
            this.jieyu.Size = new System.Drawing.Size(34, 16);
            this.jieyu.TabIndex = 15;
            this.jieyu.Text = "xxx";
            // 
            // labelzongshouru
            // 
            this.labelzongshouru.AutoSize = true;
            this.labelzongshouru.Location = new System.Drawing.Point(108, 86);
            this.labelzongshouru.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelzongshouru.Name = "labelzongshouru";
            this.labelzongshouru.Size = new System.Drawing.Size(34, 16);
            this.labelzongshouru.TabIndex = 14;
            this.labelzongshouru.Text = "xxx";
            // 
            // labelzongzhichu
            // 
            this.labelzongzhichu.AutoSize = true;
            this.labelzongzhichu.Location = new System.Drawing.Point(108, 34);
            this.labelzongzhichu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelzongzhichu.Name = "labelzongzhichu";
            this.labelzongzhichu.Size = new System.Drawing.Size(34, 16);
            this.labelzongzhichu.TabIndex = 10;
            this.labelzongzhichu.Text = "xxx";
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // personal_ledger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 561);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.user_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "personal_ledger";
            this.Text = "personal_ledger";
            this.Load += new System.EventHandler(this.personal_ledger_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label user_name;
        private System.Windows.Forms.Label 上限金额;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Amount_modification;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.CheckedListBox expenditure_box;
        private System.Windows.Forms.CheckedListBox income_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelqita;
        private System.Windows.Forms.Label labelshuidian;
        private System.Windows.Forms.Label labelmedc;
        private System.Windows.Forms.Label labeljiaotong;
        private System.Windows.Forms.Label labelfood;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label jieyu;
        private System.Windows.Forms.Label labelzongshouru;
        private System.Windows.Forms.Label labelzongzhichu;
        private System.Windows.Forms.Label shangxian;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.Button chushihuariqi;
    }
}