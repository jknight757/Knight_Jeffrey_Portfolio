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
        
    }
}
