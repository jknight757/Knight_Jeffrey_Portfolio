using System;

namespace Knight_Jeffrey_BuildingCodeRepository
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//SwapName ();
			//BackWards ();
			AgeConvert ();
		}

		//exercise1//
		public static void SwapName()
		{
			//varaibles
			string firstName = "";
			string lastName = "";
			string temp = "";

			Console.WriteLine ("Enter your first name.");
			firstName = Console.ReadLine ();
			Console.WriteLine ("Enter your last name.");
			lastName = Console.ReadLine ();
			Console.WriteLine (firstName+" "+lastName);

			temp = firstName;
			firstName = lastName;
			lastName = temp;
			Console.WriteLine (firstName+" "+lastName);
		}
		//exercise1//

		//exercise2//
		public static void BackWards()
		{
			//variables
			string input = "";
			string output = "";
			String[] sentence;

			Console.WriteLine ("Enter a sentence with atleast 6 words");
			input = Console.ReadLine ();
			sentence = input.Split (' ');

			for (int i = sentence.Length-1; i >= 0; i--) 
			{
				output+=sentence[i]+" ";
			}
			Console.WriteLine (output);


		}
		//exercise2//

		//exercise3//
		public static void AgeConvert()
		{
			//varaibles
			string name="";
			double age = 0.0;
			double days = 0.0;
			double hours = 0.0;
			double minutes = 0.0;
			double seconds = 0.0;

			Console.WriteLine ("Enter your name.");
			name = Console.ReadLine ();
			Console.WriteLine ("Enter your age.");
			age = Convert.ToInt32 (Console.ReadLine ());

			days = age * 365 + (age / 4);
			hours = days * 24;
			minutes = hours * 60;
			seconds = minutes * 60;

			Console.WriteLine ("{0} has been alive for {1} days\nor {2} hours\nor {3} minutes\nor {4} seconds.",name,days,hours,minutes,seconds);



		}
		//exercise3//
	}
}
