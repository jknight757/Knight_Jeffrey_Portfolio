using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightJeffreyContactList
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e) //creates instance of contact class with user input and adds to list view and list
        {
            ListViewItem lvi = new ListViewItem();

            long x=0;
            if (long.TryParse(txtNump1.Text, out x)) //checks to make sure phone number is an long integer
            {




                Contact c1 = new Contact(txtFirstN.Text, txtLastN.Text, x, txtEmail.Text); //creates new contact
                lvi.Tag = c1;
                lvi.Text = c1.ToString();
                lvi.ImageIndex = 0;
                listView1.Items.Add(lvi); //adds to listview
            }
            

            
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
            largeToolStripMenuItem.Checked = true;
            smallToolStripMenuItem.Checked = false;
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
            smallToolStripMenuItem.Checked = true;
            largeToolStripMenuItem.Checked = false;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) //determines if selected item is from listview1
            {
                Contact c1 = listView1.SelectedItems[0].Tag as Contact;
                txtFirstN.Text = c1.First;
                txtLastN.Text = c1.Last;
                txtNump1.Text = c1.Phone.ToString();
                txtEmail.Text = c1.Email;

                btnAdd.Visible = false;
                btnDelete.Visible = true;    
                btnSave.Visible = true;
            }
            else
            {
                MessageBox.Show("Contact not selected");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) //deleted seleted contact from listview
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]); //removes item from list at location of selected item idex
            //clears input fields
            txtFirstN.Text = "";
            txtLastN.Text = "";
            txtNump1.Text = "";
            txtEmail.Text = "";
            btnAdd.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();

            long x = 0;
            int loc;
            if (long.TryParse(txtNump1.Text, out x)) //checks to make sure phone number is an long integer
            {
                loc = listView1.SelectedIndices[0];
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);

                Contact c1 = new Contact(txtFirstN.Text, txtLastN.Text, x, txtEmail.Text); //creates new contact
                lvi.Tag = c1;
                lvi.Text = c1.ToString();
                lvi.ImageIndex = 0;
                listView1.Items.Add(lvi);    //adds to listview

                btnAdd.Visible = true;
                btnDelete.Visible = false;
                btnSave.Visible = false;
            }
            else
            {
                MessageBox.Show("Contact not selected");
            }
        }
    }
}
