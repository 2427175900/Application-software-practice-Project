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
    public partial class 导出 : Form
    {
        public 导出()
        {
            InitializeComponent();
        }
        public void CopyListViewItems(ListView sourceListView)
        {
            foreach (ListViewItem item in sourceListView.Items)
            {
                ListViewItem newItem = new ListViewItem(item.Text);
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    newItem.SubItems.Add(subItem.Text);
                }
                listView1.Items.Add(newItem);
            }
        }

        public void LoadListViewItems(ListView.ListViewItemCollection items)
        {
            foreach (ListViewItem item in items)
            {
                ListViewItem newItem = new ListViewItem(item.Text);
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    newItem.SubItems.Add(subItem.Text);
                }
                AddListViewItem(newItem);
            }
        }

        public void AddListViewItem(ListViewItem item)
        {
            listView1.Items.Add(item);
        }




        private void 导出_Load(object sender, EventArgs e)
        {

        }
    }
}
