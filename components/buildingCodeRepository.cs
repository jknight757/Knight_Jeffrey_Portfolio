using System;
using System.Collections;

namespace Knight_Jeffrey_BuildingCodeRepository
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//varaibles
			string methodName="";
			ArrayList methodNames = new ArrayList();
			methodNames.Add ("SWAPNAME");
			methodNames.Add("BACKWARDS");
			methodNames.Add ("AGECONVERT");
			methodNames.Add("TEMPCONVERT");

			//input
			Console.WriteLine ("Which method would you like to run.");
			Console.WriteLine ("SwapName----BackWards----AgeConvert----TempConvert");
			methodName = Console.ReadLine ();
			methodName = methodName.ToUpper ();

			//input validation
			while (methodNames.Contains (methodName) == false) 
			{
				Console.WriteLine ("Invalid entry, enter a new method name");
				Console.WriteLine ("SwapName----BackWards----AgeConvert----TempConvert");
				methodName = Console.ReadLine ();
				methodName = methodName.ToUpper ();
			}

				//input to method call
				switch (methodName) 
				{
				case "SWAPNAME":
					SwapName ();
					break;
				case "BACKWARDS":
					BackWards ();
					break;
				case "AGECONVERT":
					AgeConvert ();
					break;
				case "TEMPCONVERT":
					TempConvert ();
					break;
				}
			



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
