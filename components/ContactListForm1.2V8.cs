using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//Jeffrey Knight
//Project and Portfolio 3
// 9/7/17
namespace KnightJeffreyContactList
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)               //creates instance of contact class with user input and adds to list view and list
        {
            //txtFirstN.Update();
            ListViewItem lvi = new ListViewItem();
            if (txtFirstN.Text != "" && txtLastN.Text != "" && txtEmail.Text != "" && txtNump1.Text != "")
            {
                long x = long.Parse(txtNump1.Text);

                Contact c1 = new Contact(txtFirstN.Text, txtLastN.Text, x, txtEmail.Text); //creates new contact
                lvi.Tag = c1;
                lvi.Text = c1.ToString();
                lvi.ImageIndex = 0;
                listView1.Items.Add(lvi);                                                   //adds to listview
                txtFirstN.Text = "";
                txtLastN.Text = "";
                txtEmail.Text = "";
                txtNump1.Text = "";
            }
            else
            {
                MessageBox.Show("All fields must have input");
            }

        }

        public bool checkInput(string txt)
        {
            bool ans = true;                                                            //creates the return bool and sets to default
            for (int i = 0; i < txt.Length; i++)                                        //loops through input string
            {
                if (char.IsDigit(txt[i]))                                               //checks if it contains a digit and sets answer to false
                {
                    ans = false;
                }
            }

            return ans;
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
            if (listView1.SelectedItems.Count > 0)                                      //determines if selected item is from listview1
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

        private void btnDelete_Click(object sender, EventArgs e)                       //deleted seleted contact from listview
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);                    //removes item from list at location of selected item idex
            
            txtFirstN.Text = "";                                                       //clears input fields
            txtLastN.Text = "";                                                        //clears input fields
            txtNump1.Text = "";                                                        //clears input fields
            txtEmail.Text = "";                                                        //clears input fields
            btnAdd.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();

            long x = 0;
            int loc;
            if (long.TryParse(txtNump1.Text, out x))                                  //checks to make sure phone number is an long integer
            {
                loc = listView1.SelectedIndices[0];
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);

                Contact c1 = new Contact(txtFirstN.Text, txtLastN.Text, x, txtEmail.Text); //creates new contact
                lvi.Tag = c1;
                lvi.Text = c1.ToString();
                lvi.ImageIndex = 0;
                listView1.Items.Add(lvi);                                             //adds to listview

                btnAdd.Visible = true;
                btnDelete.Visible = false;
                btnSave.Visible = false;
            }
            else
            {
                MessageBox.Show("Contact not selected");
            }
        }

        

        private void txtFirstN_Leave(object sender, EventArgs e)
        {
            if (!checkInput(txtFirstN.Text)&&txtFirstN.Text!="")                //validates input and checks for blank input
            {
                MessageBox.Show("Invalid First name");                          //if input is invalid and text box is not blank, message is shown
                txtFirstN.Focus();
                txtFirstN.Select(0, txtFirstN.Text.Length);                     //clears text box for new input
            }

        }

        private void txtLastN_Leave(object sender, EventArgs e)
        {

            if (!checkInput(txtLastN.Text)&&txtLastN.Text!="")                 //validates input and checks for blank input 
            {
                MessageBox.Show("Invalid Last name");                          //if input is invalid and text box is not blank, message is shown
                txtLastN.Focus();
                txtLastN.Select(0, txtLastN.Text.Length);                      //clears text box for new input
            }
            
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!txtEmail.Text.Contains('@')&&txtEmail.Text!="")               //validates input and checks for blank input
            {
                MessageBox.Show("Invalid Email");                              //if input is invalid and text box is not blank, message is shown
                txtEmail.Focus();
                txtEmail.Select(0, txtEmail.Text.Length);                      //clears text box for new input
            }
        }

        private void txtNump1_Leave(object sender, EventArgs e)
        {
            long x = 0;
            if (!long.TryParse(txtNump1.Text, out x)&&txtNump1.Text!="")       //checks that input is a number and not blank
            {
                MessageBox.Show("Must contain only integers");                 //if input can not be converted to long and is not blank, message is shown
                txtNump1.Focus();
                txtNump1.Select(0, txtNump1.Text.Length);                      //clears text box for new input
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter myStream;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (myStream = new StreamWriter(saveFileDialog1.FileName)) //uses the streamwriter to create a file with the given filename
                {
                    myStream.WriteLine("Contacts");
                    Contact c1;
                    for (int i = 0; i < listView1.Items.Count; i++)           //Loops through all of the listview items
                    {
                        myStream.WriteLine("----------");
                        c1 = listView1.Items[i].Tag as Contact;               //Sets a instance of the contact class to the listview item
                        myStream.WriteLine(c1.First);                         //writes to the mystream
                        myStream.WriteLine(c1.Last);
                        myStream.WriteLine(c1.Phone);
                        myStream.WriteLine(c1.Email);
                       
                    }
                }
            }
        
        }
    }
}
