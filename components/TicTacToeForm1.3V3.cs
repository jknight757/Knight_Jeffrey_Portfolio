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
using System.Xml;

//Jeffrey Knight
//Project and portfolio 3 10/12/17
//TicTacToe
namespace TicTacToe
{
    public partial class frmTicTacToe : Form
    {
        int imgIndex=-1;                                              //will hold the image index which is seleted when the player chooses X or O
        int numPlays = 0;                                             //counter which holds th number of squares that have been played
        List<bool> tilesPlayed = new List<bool> { false, false, false, false, false, false, false, false, false }; //holds boolean value to store if a tile has already been played
        string whichImageList = "blueImages";
        int[,] playerTiles =new int[3,3] { { -1, -2, -3}              //2D array stores who played each tile       
                                         , { -4, -5, -6}
                                         , { -7, -8, -9 } };
        

        /* THINGS TO CONSIDER:
            - You must change the project name to conform to the required
              naming convention.
            - You must comment the code throughout.  Failure to do so could result
              in a lower grade.
            - All button names and other provided variables and controls must
              remain the same.  Changing these could result in a 0 on the project.
            - Selecting Blue or Red on the View menu should change the imageList
              attached to all buttons so that any current play will change the color
              of all button images.
            - Saved games should save to XML.  A game should load only from XML and
              should not crash the application if a user tries to load an incorrect 
              file.
        */

        public frmTicTacToe()
        {
            InitializeComponent();
        }
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgIndex = 1;
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgIndex = 0;
        }


        private void redToolStripMenuItem_Click(object sender, EventArgs e) //changes all buttons image list to redImages 
        {

            r1c1button.ImageList = redImages; 
            r1c2button.ImageList = redImages;
            r1c3button.ImageList = redImages;
            r2c1button.ImageList = redImages;
            r2c2button.ImageList = redImages;
            r2c3button.ImageList = redImages;
            r3c1button.ImageList = redImages;
            r3c2button.ImageList = redImages;
            r3c3button.ImageList = redImages;
            whichImageList = "redImages";
            redToolStripMenuItem.Checked = true;   //checks red option
            blueToolStripMenuItem.Checked = false; //unchecks blue option
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e) //changes all buttons image list to blueImages
        {
            r1c1button.ImageList = blueImages;
            r1c2button.ImageList = blueImages;
            r1c3button.ImageList = blueImages;
            r2c1button.ImageList = blueImages;
            r2c2button.ImageList = blueImages;
            r2c3button.ImageList = blueImages;
            r3c1button.ImageList = blueImages;
            r3c2button.ImageList = blueImages;
            r3c3button.ImageList = blueImages;
            whichImageList = "blueImages";
            redToolStripMenuItem.Checked = false;  //unchecks red option
            blueToolStripMenuItem.Checked = true;  //checks blue option
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //exits application
        {
            Application.Exit();
        }

    }
}
