using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightJeffrey_groceryList_assignment1
{
    public partial class Form1 : Form
    {
        List<string> needs = new List<string>(); //list to hold needs items
        List<string> wants = new List<string>(); //list to hold wanted items

        public Form1()
        {
            InitializeComponent();
        }
        //this button adds inputed item to the needs list
        private void btnAddN_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(); //creates a new list view item

            needs.Add(txtNeeds.Text);              //text entered into the text box is added to the list
            lvi.Text = needs[needs.Count-1];       //listview item's text is set to the item most recently added to the list
            listView1.Items.Add(lvi);              //new listview item is added to the the listview
            

        }
        //this button adds inputed item to the wants list
        private void btnAddW_Click(object sender, EventArgs e)
        {
            ListViewItem lvi=new ListViewItem();   //creates a new list view item

            wants.Add(txtWants.Text);              //text entered into the text box is added to the list
            lvi.Text = wants[wants.Count-1];       //listview item's text is set to the item most recently added to the list
            listView2.Items.Add(lvi);              //new listview item is added to the the listview

        }
        /*
        private void updateNeeds()
        {
            ListViewItem lvi = new ListViewItem();
            foreach (string item in needs)
            {
                lvi.Text = item;
                listView1.Items.Add(lvi);
            }
        }
        private void updateWants()
        {
            ListViewItem lvi = new ListViewItem();
            foreach (string item in wants)
            {
                lvi.Text = item;
                listView2.Items.Add(lvi);
            }
        }*/
    }
}
