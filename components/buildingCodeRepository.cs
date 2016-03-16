using System;

namespace Knight_Jeffrey_BuildingCodeRepository
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//SwapName ();
			//BackWards ();
			//AgeConvert ();
			TempConvert();
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
			int age = 0;
			int days = 0;
			int hours = 0;
			int minutes = 0;
			int seconds = 0;

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

		//exercise4//
		public static void TempConvert()
		{
			//varaibles
			double fTemp = 0.0;
			double cTemp = 0.0;
			double fInput = 0.0;
			double cInput = 0.0;

			//input
			Console.WriteLine ("Enter the current temperature in fahrenheit");
			fInput = Convert.ToDouble (Console.ReadLine ());

			//math
			cTemp= (fInput -32)*5/9;
			Console.WriteLine ("The current temperature is {0}F or {1}C",fInput,cTemp);

			Console.WriteLine ("Enter the current temperature in celsius");
			cInput = Convert.ToDouble (Console.ReadLine ());

			fTemp = (cInput * 9 / 5) + 32;
			Console.WriteLine ("The current temperature is {0}C or {1}F",cInput,fTemp);


		}
		//exercise4//
	}
}
