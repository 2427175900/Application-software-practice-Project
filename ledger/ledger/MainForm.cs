using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ledger
{
    public partial class MainForm : Form
    {
        public string username;
        public MainForm()
        {
            InitializeComponent();
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }
        internal void UpdateLabel(string text)
        {
            throw new NotImplementedException();
        }

        private void btnAdduser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Owner = this;
            this.Enabled = false;
            addUser.ShowDialog();
            this.Enabled = true;
        }
     
    }
}
