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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Visible = true;
            btnSwitch.Visible = true;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Visible = true;
            btnSwitch.Visible = true;
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();

            if (listView1.SelectedItems.Count >0) //determines if selected item is from listview1
            {
                lvi.Text = listView1.SelectedItems[0].Text; //sets the new listview item text to the text of the selected listviewitem
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]); //removes selected item from the list view
                listView2.Items.Add(lvi); //adds the selected item to the other list view
                wants.Add(lvi.Text); //adds selected item to other list

                for (int i = 0; i < needs.Count; i++) //finds selected item in the current list and removes it
                {
                    if (needs[i] == lvi.Text)
                    {
                        needs.RemoveAt(i);
                    }
                }
            }
            if (listView2.SelectedItems.Count >0) //determines if selected item is from listview2
            {
                lvi.Text = listView2.SelectedItems[0].Text; //sets the new listview item text to the text of the selected listviewitem
                listView2.Items.RemoveAt(listView2.SelectedIndices[0]); //removes selected item from the list view
                listView1.Items.Add(lvi); //adds the selected item to the other list view
                needs.Add(lvi.Text); //adds selected item to other list

                for (int i = 0; i < wants.Count; i++) //finds selected item in the current list and removes it
                {
                    if (wants[i] == lvi.Text)
                    {
                        wants.RemoveAt(i);
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string item = "";
            if (listView1.SelectedItems.Count > 0) //determines if selected item is from listview1
            {
                item = listView1.SelectedItems[0].Text;
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                for (int i = 0; i < needs.Count; i++) //finds selected item in the current list and removes it
                {
                    if (needs[i] == item)
                    {
                        needs.RemoveAt(i);
                    }
                }

            }

            if (listView2.SelectedItems.Count > 0) //determines if selected item is from listview1
            {
                item = listView2.SelectedItems[0].Text;
                listView2.Items.RemoveAt(listView2.SelectedIndices[0]);
                for (int i = 0; i < wants.Count; i++) //finds selected item in the current list and removes it
                {
                    if (wants[i] == item)
                    {
                        wants.RemoveAt(i);
                    }
                }
            }

        }
    }
}
