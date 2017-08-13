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
        List<Contact> contacts = new List<Contact>();

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
                //lvi.ImageIndex = 0;
                listView1.Items.Add(lvi); //adds to listview
                contacts.Add(c1);
            }
            
        }
        
    }
}
