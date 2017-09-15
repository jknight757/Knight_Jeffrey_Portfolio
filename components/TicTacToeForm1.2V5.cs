using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Jeffrey Knight
//Project and portfolio 3 9/14/17
//TicTacToe
namespace TicTacToe
{
    public partial class frmTicTacToe : Form
    {
        int imgIndex=-1;                                              //will hold the image index which is seleted when the player chooses X or O
        int numPlays = 0;                                             //counter which holds th number of squares that have been played
        List<bool> tilesPlayed = new List<bool> { false, false, false, false, false, false, false, false, false }; //holds boolean value to store if a tile has already been played

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
        public int checkScore()
        {
            int winner=-1;
            for (int i = -1; i < 2; i++)
            {

                if (playerTiles[i + 1, 0] == playerTiles[i + 1, 1] && playerTiles[i+1, 1] == playerTiles[i + 1, 2]) //checks every row for 3 matches
                {
                    winner = playerTiles[i + 1, 0];                     //sets winner to the saved image index value of that player
                } 
                if (playerTiles[0, i + 1] == playerTiles[1, i + 1] && playerTiles[1, i + 1] == playerTiles[2, i + 1]) //checks every column for 3 matches
                {
                    winner = playerTiles[0, i + 1];                     //sets winner to the saved image index value of that player
                }
                
                
            }
            if (playerTiles[0, 0] == playerTiles[1, 1] && playerTiles[1, 1] == playerTiles[2, 2]) //checks diagonal left to right for 3 matches
            {
                winner = playerTiles[0, 0];                             //sets winner to the saved image index value of that player
            }
            if (playerTiles[0, 2] == playerTiles[1, 1] && playerTiles[1, 1] == playerTiles[2, 0]) //checks diagonal right to left for 3 matches
            {
                winner = playerTiles[0, 2];                             //sets winner to the saved image index value of that player
            }
            return winner;
        }
        
        public void newGame()
        {
            for (int i = 0; i < tilesPlayed.Count; i++)                 //goes through tilesPlayed list
            {
                tilesPlayed[i] = false;                                 //sets all tilesPlayed values to false

            }
            playerTiles = new int[3, 3] {  { -1, -2, -3}                //2D array stores who played each tile       
                                         , { -4, -5, -6}
                                         , { -7, -8, -9} };

            numPlays = 0;                                               //sets number of plays back to 0
            imgIndex = -1;                                              //sets image Index back to -1

            r1c1button.ImageList = blueImages;                          //sets all button imagelists back to blueImages
            r1c2button.ImageList = blueImages;
            r1c3button.ImageList = blueImages;
            r2c1button.ImageList = blueImages;
            r2c2button.ImageList = blueImages;
            r2c3button.ImageList = blueImages;
            r3c1button.ImageList = blueImages;
            r3c2button.ImageList = blueImages;
            r3c3button.ImageList = blueImages;

            r1c1button.ImageIndex = imgIndex;                           //sets all button imageIndexes back to image index variable(-1)
            r1c2button.ImageIndex = imgIndex;
            r1c3button.ImageIndex = imgIndex;
            r2c1button.ImageIndex = imgIndex;
            r2c2button.ImageIndex = imgIndex;
            r2c3button.ImageIndex = imgIndex;
            r3c1button.ImageIndex = imgIndex;
            r3c2button.ImageIndex = imgIndex;
            r3c3button.ImageIndex = imgIndex;

            redToolStripMenuItem.Checked = false;                       //unchecks red option
            blueToolStripMenuItem.Checked = true;                       //checks blue option
        
        }
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgIndex = 1;
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgIndex = 0;
        }

        private void r1c1button_Click(object sender, EventArgs e)
        {
            if (imgIndex > -1)                                          //checks to make sure someone selected X or O
            {
                if (!tilesPlayed[0])                                    //checks if this tile has been selected already
                {

                    tilesPlayed[0] = true;                              //sets bool list value to true at button Number index to show button has already been selected
                    r1c1button.ImageIndex = (numPlays + imgIndex) % 2;  //sets image index to X or O based on whose turn and is X or O
                    playerTiles[0,0]= (numPlays + imgIndex) % 2;       //saves which player claimed this tile
                    numPlays++;
                    showWinner(checkScore());
                }
                else
                {
                    MessageBox.Show("Tile already selected");           //returns message to tell user that this tile has been selected already
                }
            }
            else
            {
                MessageBox.Show("Select X or O");                       //returns message to tell user that they havent selected X or O
            }
        }

        private void r1c2button_Click(object sender, EventArgs e)
        {
            if (imgIndex > -1)                                          //checks to make sure someone selected X or O
            {
                if (!tilesPlayed[1])                                    //checks if this tile has been selected already
                {

                    tilesPlayed[1] = true;                              //sets bool list value to true at button Number index to show button has already been selected
                    r1c2button.ImageIndex = (numPlays + imgIndex) % 2;  //sets image index to X or O based on whose turn and is X or O
                    playerTiles[0,1] = (numPlays + imgIndex) % 2;       //saves which player claimed this tile
                    numPlays++;
                    showWinner(checkScore());
                }
                else
                {
                    MessageBox.Show("Tile already selected");           //returns message to tell user that this tile has been selected already
                }
            }
            else
            {
                MessageBox.Show("Select X or O");                       //returns message to tell user that they havent selected X or O
            }
        }

        private void r1c3button_Click(object sender, EventArgs e)
        {
            if (imgIndex > -1)                                          //checks to make sure someone selected X or O
            {
                if (!tilesPlayed[2])                                    //checks if this tile has been selected already
                {

                    tilesPlayed[2] = true;                              //sets bool list value to true at button Number index to show button has already been selected
                    r1c3button.ImageIndex = (numPlays + imgIndex) % 2;  //sets image index to X or O based on whose turn and is X or O
                    playerTiles[0,2] = (numPlays + imgIndex) % 2;       //saves which player claimed this tile
                    numPlays++;
                    showWinner(checkScore());
                }
                else
                {
                    MessageBox.Show("Tile already selected");           //returns message to tell user that this tile has been selected already
                }
            }
            else
            {
                MessageBox.Show("Select X or O");                       //returns message to tell user that they havent selected X or O
            }
        }

        private void r2c1button_Click(object sender, EventArgs e)
        {
            if (imgIndex > -1)                                          //checks to make sure someone selected X or O
            {
                if (!tilesPlayed[3])                                    //checks if this tile has been selected already
                {

                    tilesPlayed[3] = true;                              //sets bool list value to true at button Number index to show button has already been selected
                    r2c1button.ImageIndex = (numPlays + imgIndex) % 2;  //sets image index to X or O based on whose turn and is X or O
                    playerTiles[1,0] = (numPlays + imgIndex) % 2;       //saves which player claimed this tile
                    numPlays++;
                    showWinner(checkScore());
                }
                else
                {
                    MessageBox.Show("Tile already selected");           //returns message to tell user that this tile has been selected already
                }
            }
            else
            {
                MessageBox.Show("Select X or O");                       //returns message to tell user that they havent selected X or O
            }
        }

        private void r2c2button_Click(object sender, EventArgs e)
        {
            if (imgIndex > -1)                                          //checks to make sure someone selected X or O
            {
                if (!tilesPlayed[4])                                    //checks if this tile has been selected already
                {

                    tilesPlayed[4] = true;                              //sets bool list value to true at button Number index to show button has already been selected
                    r2c2button.ImageIndex = (numPlays + imgIndex) % 2;  //sets image index to X or O based on whose turn and is X or O
                    playerTiles[1,1] = (numPlays + imgIndex) % 2;       //saves which player claimed this tile
                    numPlays++;
                    showWinner(checkScore());
                }
                else
                {
                    MessageBox.Show("Tile already selected");           //returns message to tell user that this tile has been selected already
                }
            }
            else
            {
                MessageBox.Show("Select X or O");                       //returns message to tell user that they havent selected X or O
            }
        }

        private void r2c3button_Click(object sender, EventArgs e)
        {
            if (imgIndex > -1)                                          //checks to make sure someone selected X or O
            {
                if (!tilesPlayed[5])                                    //checks if this tile has been selected already
                {

                    tilesPlayed[5] = true;                              //sets bool list value to true at button Number index to show button has already been selected
                    r2c3button.ImageIndex = (numPlays + imgIndex) % 2;  //sets image index to X or O based on whose turn and is X or O
                    playerTiles[1,2] = (numPlays + imgIndex) % 2;       //saves which player claimed this tile
                    numPlays++;
                    showWinner(checkScore());
                }
                else
                {
                    MessageBox.Show("Tile already selected");           //returns message to tell user that this tile has been selected already
                }
            }
            else
            {
                MessageBox.Show("Select X or O");                       //returns message to tell user that they havent selected X or O
            }
        }

        private void r3c1button_Click(object sender, EventArgs e)
        {
            if (imgIndex > -1)                                          //checks to make sure someone selected X or O
            {
                if (!tilesPlayed[6])                                    //checks if this tile has been selected already
                {

                    tilesPlayed[6] = true;                              //sets bool list value to true at button Number index to show button has already been selected
                    r3c1button.ImageIndex = (numPlays + imgIndex) % 2;  //sets image index to X or O based on whose turn and is X or O
                    playerTiles[2,0] = (numPlays + imgIndex) % 2;       //saves which player claimed this tile
                    numPlays++;
                    showWinner(checkScore());
                }
                else
                {
                    MessageBox.Show("Tile already selected");           //returns message to tell user that this tile has been selected already
                }
            }
            else
            {
                MessageBox.Show("Select X or O");                       //returns message to tell user that they havent selected X or O
            }
        }

        private void r3c2button_Click(object sender, EventArgs e)
        {
            if (imgIndex > -1)                                          //checks to make sure someone selected X or O
            {
                if (!tilesPlayed[7])                                    //checks if this tile has been selected already
                {

                    tilesPlayed[7] = true;                              //sets bool list value to true at button Number index to show button has already been selected
                    r3c2button.ImageIndex = (numPlays + imgIndex) % 2;  //sets image index to X or O based on whose turn and is X or O
                    playerTiles[2,1] = (numPlays + imgIndex) % 2;       //saves which player claimed this tile
                    numPlays++;
                    showWinner(checkScore());
                }
                else
                {
                    MessageBox.Show("Tile already selected");           //returns message to tell user that this tile has been selected already
                }
            }
            else
            {
                MessageBox.Show("Select X or O");                       //returns message to tell user that they havent selected X or O
            }
        }

        private void r3c3button_Click(object sender, EventArgs e)
        {
            if (imgIndex > -1)                                          //checks to make sure someone selected X or O
            {
                if (!tilesPlayed[8])                                    //checks if this tile has been selected already
                {

                    tilesPlayed[8] = true;                              //sets bool list value to true at button Number index to show button has already been selected
                    r3c3button.ImageIndex = (numPlays + imgIndex) % 2;  //sets image index to X or O based on whose turn and is X or O
                    playerTiles[2,2] = (numPlays + imgIndex) % 2;       //saves which player claimed this tile
                    numPlays++;
                    showWinner(checkScore());
                }
                else
                {
                    MessageBox.Show("Tile already selected");           //returns message to tell user that this tile has been selected already
                }
            }
            else
            {
                MessageBox.Show("Select X or O");                       //returns message to tell user that they havent selected X or O
            }
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

            redToolStripMenuItem.Checked = false;  //unchecks red option
            blueToolStripMenuItem.Checked = true;  //checks blue option
        }

        private void toolStripButton1_Click(object sender, EventArgs e) // starts a new game
        {
            newGame();
        }
    }
}
