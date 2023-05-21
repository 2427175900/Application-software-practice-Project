namespace ledger
{
    partial class AddUser
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
            this.UserName = new System.Windows.Forms.Label();
            this.UserNameText = new System.Windows.Forms.TextBox();
            this.BtnUserAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserName.Location = new System.Drawing.Point(12, 34);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(131, 21);
            this.UserName.TabIndex = 0;
            this.UserName.Text = "UserName : ";
            // 
            // UserNameText
            // 
            this.UserNameText.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameText.Location = new System.Drawing.Point(138, 31);
            this.UserNameText.Name = "UserNameText";
            this.UserNameText.Size = new System.Drawing.Size(244, 31);
            this.UserNameText.TabIndex = 1;
            // 
            // BtnUserAdd
            // 
            this.BtnUserAdd.Location = new System.Drawing.Point(415, 31);
            this.BtnUserAdd.Name = "BtnUserAdd";
            this.BtnUserAdd.Size = new System.Drawing.Size(87, 31);
            this.BtnUserAdd.TabIndex = 2;
            this.BtnUserAdd.Text = "add";
            this.BtnUserAdd.UseVisualStyleBackColor = true;
            this.BtnUserAdd.Click += new System.EventHandler(this.BtnUserAdd_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 83);
            this.Controls.Add(this.BtnUserAdd);
            this.Controls.Add(this.UserNameText);
            this.Controls.Add(this.UserName);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUser_FormClosing);
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.TextBox UserNameText;
        private System.Windows.Forms.Button BtnUserAdd;
    }
}