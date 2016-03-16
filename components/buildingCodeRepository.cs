using System;

namespace Knight_Jeffrey_BuildingCodeRepository
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//SwapName ();
			BackWards ();
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


	}
}
