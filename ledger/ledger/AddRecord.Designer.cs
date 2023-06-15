namespace ledger
{
    partial class AddRecord
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.yongtu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.beizhu = new System.Windows.Forms.TextBox();
            this.textbox_TM1 = new System.Windows.Forms.TextBox();
            this.sure1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.beizhu2 = new System.Windows.Forms.TextBox();
            this.textbox_TM2 = new System.Windows.Forms.TextBox();
            this.sure2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(415, 261);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.yongtu);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.beizhu);
            this.tabPage1.Controls.Add(this.textbox_TM1);
            this.tabPage1.Controls.Add(this.sure1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(407, 231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "지출";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 45);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // yongtu
            // 
            this.yongtu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yongtu.FormattingEnabled = true;
            this.yongtu.Items.AddRange(new object[] {
            "식사",
            "교통",
            "의료",
            "생활",
            "기타"});
            this.yongtu.Location = new System.Drawing.Point(267, 12);
            this.yongtu.Name = "yongtu";
            this.yongtu.Size = new System.Drawing.Size(104, 24);
            this.yongtu.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(207, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "용도:";
            // 
            // beizhu
            // 
            this.beizhu.Location = new System.Drawing.Point(56, 80);
            this.beizhu.Multiline = true;
            this.beizhu.Name = "beizhu";
            this.beizhu.Size = new System.Drawing.Size(267, 137);
            this.beizhu.TabIndex = 6;
            // 
            // textbox_TM1
            // 
            this.textbox_TM1.Location = new System.Drawing.Point(56, 13);
            this.textbox_TM1.Name = "textbox_TM1";
            this.textbox_TM1.Size = new System.Drawing.Size(86, 26);
            this.textbox_TM1.TabIndex = 4;
            this.textbox_TM1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_TM1_KeyPress);
            // 
            // sure1
            // 
            this.sure1.Location = new System.Drawing.Point(327, 185);
            this.sure1.Name = "sure1";
            this.sure1.Size = new System.Drawing.Size(75, 32);
            this.sure1.TabIndex = 3;
            this.sure1.Text = "확인";
            this.sure1.UseVisualStyleBackColor = true;
            this.sure1.Click += new System.EventHandler(this.sure1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "비고:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "금액:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dateTimePicker2);
            this.tabPage2.Controls.Add(this.beizhu2);
            this.tabPage2.Controls.Add(this.textbox_TM2);
            this.tabPage2.Controls.Add(this.sure2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 231);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "수입";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(6, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // beizhu2
            // 
            this.beizhu2.Location = new System.Drawing.Point(56, 80);
            this.beizhu2.Multiline = true;
            this.beizhu2.Name = "beizhu2";
            this.beizhu2.Size = new System.Drawing.Size(267, 137);
            this.beizhu2.TabIndex = 13;
            // 
            // textbox_TM2
            // 
            this.textbox_TM2.Location = new System.Drawing.Point(56, 13);
            this.textbox_TM2.Name = "textbox_TM2";
            this.textbox_TM2.Size = new System.Drawing.Size(86, 26);
            this.textbox_TM2.TabIndex = 12;
            this.textbox_TM2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_TM2_KeyPress);
            // 
            // sure2
            // 
            this.sure2.Location = new System.Drawing.Point(327, 185);
            this.sure2.Name = "sure2";
            this.sure2.Size = new System.Drawing.Size(75, 32);
            this.sure2.TabIndex = 11;
            this.sure2.Text = "확인";
            this.sure2.UseVisualStyleBackColor = true;
            this.sure2.Click += new System.EventHandler(this.sure2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "비고:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "금액:";
            // 
            // AddRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 261);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddRecord";
            this.Text = "AddRecord";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sure1;
        private System.Windows.Forms.TextBox beizhu;
        private System.Windows.Forms.TextBox textbox_TM1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox yongtu;
        private System.Windows.Forms.TextBox beizhu2;
        private System.Windows.Forms.TextBox textbox_TM2;
        private System.Windows.Forms.Button sure2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}