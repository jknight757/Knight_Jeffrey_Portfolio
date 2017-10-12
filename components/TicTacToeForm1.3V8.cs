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
        public void showWinner(int p)
        {
            switch (p)
            {
                case -1:                                                //this case is returned when there is no winner
                    if (numPlays > 8)                                   //this will check if the game is over
                    {
                        MessageBox.Show("Draw");                        //if the game is over and there is no winner Draw is shown
                        newGame();
                    }
                    break;
                case 0:
                    MessageBox.Show("O wins");                          //this case is returned when O wins
                    newGame();
                    break;
                case 1:
                    MessageBox.Show("X wins");                          //this case is returned when X wins
                    newGame();
                    break;
                
            }
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
            whichImageList = "blueImages";
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

        private void toolStripButton1_Click(object sender, EventArgs e) // starts a new game
        {
            newGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //exits application
        {
            Application.Exit();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string list1 = "";                                                          //temporary string to hold list1
            string list2 = "";                                                          //temporary string to hold list2
            XmlWriterSettings settings = new XmlWriterSettings();                       //creates new XML writer settings
            settings.ConformanceLevel = ConformanceLevel.Document;                      //sets up XML writer settings
            settings.Indent = true;                                                     //sets up XML writer settings
            saveFileDialog1.DefaultExt = "xml";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (XmlWriter writer = XmlWriter.Create(saveFileDialog1.FileName, settings)) //creates a new file and xml writer
                {
                    writer.WriteStartElement("TicTacToe");                                      //XML game data start element

                    writer.WriteElementString("FirstPlayerXO", imgIndex.ToString());
                    writer.WriteElementString("GameColor", whichImageList);
                    foreach (bool b in tilesPlayed)                                             //converts list to string to be saved
                    {
                        list1 += b.ToString()+",";
                    }
                    foreach (int i in playerTiles)                                              //converts list to string to be saved
                    {
                        list2 += i.ToString() + ",";
                    }
                    writer.WriteElementString("TilePlayed", list1);
                    writer.WriteElementString("PlayerTiles", list2);
                    writer.WriteElementString("NumPlays", numPlays.ToString());

                    writer.WriteEndElement();
                }
            }
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string listHold1 = "";
            string listHold2 = "";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (XmlReader reader = XmlReader.Create(openFileDialog1.FileName, settings))         //creates path to selected file
                {
                    reader.MoveToContent();
                    int x = 0;
                    if (reader.Name != "TicTacToe")
                    {
                        MessageBox.Show("Invalid file type");
                        return;
                    }

                    while (reader.Read())                                                                //loops through xml elements
                    {
                        switch (x)                                                                       // filters through XML nodes, saves data, iterates
                        {
                            case 0:
                                imgIndex = Convert.ToInt32(reader.ReadString());
                                x++;
                                break;
                            case 1:
                                whichImageList = reader.ReadString();
                                x++;
                                break;
                            case 2:
                                listHold1 = reader.ReadString();
                                x++;
                                break;
                            case 3:
                                listHold2 = reader.ReadString();
                                x++;
                                break;
                            case 4:
                                numPlays = Convert.ToInt32(reader.ReadString());
                                x++;
                                break;
                        }

                    }
                }
                }
            ConfigureLoadedXML(listHold1,listHold2);                                                    // method call to initiate game data usage
         }
        public void ConfigureLoadedXML(string L1, string L2)                                            // this method takes the loaded xml data and creates the loaded game
        {
            
            if (whichImageList == "blueImages")
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
            else
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
            string[] list1Holder = L1.Split(',');                                                       //creates a new temp list from data string
            string[] list2Holder = L2.Split(',');                                                       //creates a new temp list from data string

            for (int x = 0; x < list1Holder.Length-1; x++)                                              //sets data game list from loaded data
            {
                if (list1Holder[x] == "True")
                {
                    tilesPlayed[x] = true;
                    
                }
                else if (list1Holder[x] == "False")
                {
                    tilesPlayed[x] = false;
                }
            }
            
            for (int y = 0; y < list2Holder.Length-1; y++)                                             // sets data game list from loaded data
            {

                if (y > 5)
                {
                    playerTiles[2, (y % 3)] = Convert.ToInt32(list2Holder[y]);
                }
                else if (y > 2)
                {
                    playerTiles[1, (y % 3)] = Convert.ToInt32(list2Holder[y]);
                }
                else
                {
                    playerTiles[0, (y % 3)] = Convert.ToInt32(list2Holder[y]);
                }
            }
            for (int z = 0; z < 9; z++)                                                               // updates the form to display loaded game
            {
                if (tilesPlayed[z] == true)
                {
                    switch (z)
                    {
                        case 0:
                            r1c1button.ImageIndex = playerTiles[0, 0];
                            break;
                        case 1:
                            r1c2button.ImageIndex = playerTiles[0, 1];
                            break;
                        case 2:
                            r1c3button.ImageIndex = playerTiles[0, 2];
                            break;
                        case 3:
                            r2c1button.ImageIndex = playerTiles[1, 0];
                            break;
                        case 4:
                            r2c2button.ImageIndex = playerTiles[1, 1];
                            break;
                        case 5:
                            r2c3button.ImageIndex = playerTiles[1, 2];
                            break;
                        case 6:
                            r3c1button.ImageIndex = playerTiles[2, 0];
                            break;
                        case 7:
                            r3c2button.ImageIndex = playerTiles[2, 1];
                            break;
                        case 8:
                            r3c3button.ImageIndex = playerTiles[2, 2];
                            break;
                    }
                }
            }
        }
    }
}
