using System;

namespace Knight_Jeffrey_BuildingCodeRepository
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SwapName ();
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


	}
}
