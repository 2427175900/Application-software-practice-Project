namespace ledger
{
    partial class AddUsers
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
            this.adduser_addbutton = new System.Windows.Forms.Button();
            this.addusers_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // adduser_addbutton
            // 
            this.adduser_addbutton.Location = new System.Drawing.Point(228, 60);
            this.adduser_addbutton.Name = "adduser_addbutton";
            this.adduser_addbutton.Size = new System.Drawing.Size(88, 68);
            this.adduser_addbutton.TabIndex = 1;
            this.adduser_addbutton.Text = "ADD";
            this.adduser_addbutton.UseVisualStyleBackColor = true;
            // 
            // addusers_text
            // 
            this.addusers_text.Location = new System.Drawing.Point(24, 38);
            this.addusers_text.Multiline = true;
            this.addusers_text.Name = "addusers_text";
            this.addusers_text.Size = new System.Drawing.Size(178, 114);
            this.addusers_text.TabIndex = 2;
            this.addusers_text.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 196);
            this.Controls.Add(this.addusers_text);
            this.Controls.Add(this.adduser_addbutton);
            this.Name = "AddUsers";
            this.Text = "AddUsers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button adduser_addbutton;
        private System.Windows.Forms.TextBox addusers_text;
    }
}