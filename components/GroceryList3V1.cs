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
//Project Portfolio 3
// 9/25/17
namespace KnightJeffrey_groceryList_assignment1
{
    public partial class Form1 : Form
    {       
        List<string> needs = new List<string>();                            //list to hold needs items
        List<string> wants = new List<string>();                            //list to hold wanted items

        public Form1()
        {
            InitializeComponent();
        }
                                                                            
        private void btnAddN_Click(object sender, EventArgs e)              //this button adds inputed item to the needs list
        {
            ListViewItem lvi = new ListViewItem();                          //creates a new list view item
            if (txtNeeds.Text != "")
            {
                needs.Add(txtNeeds.Text);                                       //text entered into the text box is added to the list
                lvi.Text = needs[needs.Count - 1];                                //listview item's text is set to the item most recently added to the list
                listView1.Items.Add(lvi);                                       //new listview item is added to the the listview
            }
            txtNeeds.Text = "";
        }
                                                                           
        

        
    }
}
