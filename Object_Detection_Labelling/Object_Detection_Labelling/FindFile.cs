using System;
using System.IO;

public class FindFile
{
	public string targetLabelFile;

	public void Find()
	{
		//define the image name
		char YesOrNo;

		//to cater to the scenario that the user ends up saying 'no', this has to be a loop
		while (true)
		{

			Console.WriteLine ("=========================================");
			Console.WriteLine ("Define target image file name. Do not include file extension.");
			Console.WriteLine ("=========================================");
			targetLabelFile = Console.ReadLine () + ".txt";


			//echo the label file name
			Console.WriteLine ("=========================================");
			Console.WriteLine (targetLabelFile + " is this correct? [Y/N]");
			Console.WriteLine ("=========================================");

			//parse the input into a character
			Char.TryParse (Console.ReadLine (), out YesOrNo);

			//Convert to uppercase only to reduce hard coding issues
			YesOrNo = Char.ToUpper (YesOrNo);

			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (YesOrNo == 'Y' || YesOrNo == 'N') 
				{
					break;
				}

				//this is when there is an error to the input
				//ask the user again
				string error;
				error = "Error: Invalid input. \n";

				Console.WriteLine ("=========================================");
				Console.WriteLine (error);
				Console.WriteLine ("=========================================");

				//echo the label file name
				Console.WriteLine ("=========================================");
				Console.WriteLine (targetLabelFile + " is this correct? [Y/N]");
				Console.WriteLine ("=========================================");

				Char.TryParse (Console.ReadLine (), out YesOrNo);

				//Convert to uppercase only
				YesOrNo = Char.ToUpper (YesOrNo);
			}

			//based on the user feedback, the program will either find the file and return the file name
			//or it will ask the user again
			if (YesOrNo == 'Y') 
			{
				//check whether this text file exists
				//if it doesn't exist, create the file
				if (!File.Exists (targetLabelFile)) 
				{
					using (FileStream fs = File.Create (targetLabelFile)) 
					{
						Console.WriteLine ("=========================================");
						Console.WriteLine (targetLabelFile + " missing!");
						Console.WriteLine (targetLabelFile + " created!");
						Console.WriteLine ("=========================================");
					}
				} 
				else 
				{
					Console.WriteLine ("=========================================");
					Console.WriteLine (targetLabelFile + " found!");

				}
				return;
			}

		}
	}
}
