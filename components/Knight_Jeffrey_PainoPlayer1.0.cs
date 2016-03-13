using System;
using System.IO;
using System.Collections;
using System.Media;

namespace ABC_piano
{
	class MainClass
	{
		//Jeffrey Knight
		//Project portfolio 
		//This program alows users to enter paino notes to hear there corrisponding sounds.

		public static void Main (string[] args)
		{
			//varaibles
			string input = "";
			ArrayList notes = new ArrayList{"C","D","E","F","G","A","B"};
			//prompts users for input
			Console.WriteLine ("Enter a single piano note or multiple piano notes then press enter");
			Console.WriteLine ("C,D,E,F,G,A,B");
			input = Console.ReadLine ();
			input = input.ToUpper ();

			//input validation

			if (notes.Contains (input)) {
				switch (input) {
				case "C":
					playNote (1);
					break;
				case "D":
					playNote (2);
					break;
				case "E":
					playNote (3);
					break;
				case "F":
					playNote (4);
					break;
				case "G":
					playNote (5);
					break;
				case "A":
					playNote (6);
					break;
				case "B":
					playNote (7);
					break;

				}
			} else 
			{
				Console.WriteLine("Enter a valid note");
			}

			//

		}

		public static void playNote(int noteInt)
		{
			//this method will accept a integer value representing a piano key and play the note
			Console.WriteLine(noteInt+"this works");

		}
		private void playPainoNoteC()
		{
			SoundPlayer C = new SoundPlayer(@"c:\fileLocation");
			C.Play();
		}

	}
}
