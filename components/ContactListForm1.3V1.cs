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
// 10/5/2017
namespace KnightJeffreyContactList
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
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


    }
}
