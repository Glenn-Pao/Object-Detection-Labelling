using System;
using System.IO;

public class MainProgram
{
	public void Run()
	{
		//run the main program here
		//the welcome message
		ReadTextFile ("welcome.txt");

		int optionNum;
		SingleLabelling sLabel = new SingleLabelling();

		//Choose a number, attempt to parse the phrase typed in by user into int
		if (!Int32.TryParse (Console.ReadLine (), out optionNum)) 
		{
			string error;
			error = "Error: Invalid input. Try again.";

			Console.WriteLine (error);
		}

		//If number = 1, trigger single entry key in
		if (optionNum == 1) 
		{
			sLabel.SingleImageLabelling ();
		}
		//If number = 2, trigger multiple entries key in
		else if (optionNum == 2) 
		{
			Test ();
		}
		//If number = 3, trigger the help text
		else if (optionNum == 3) 
		{
			ReadTextFile ("help.txt");
		}
		//If number = 4, break this loop
		else if (optionNum == 4) 
		{
			//break;
		}

	}

	//the function to use when reading from text file and printing to console
	void ReadTextFile(string textFile)
	{
		//Open the file into a stream reader
		StreamReader file = File.OpenText(textFile);

		//Read the file into a string
		string s = file.ReadToEnd();

		//close the file
		file.Close();

		Console.WriteLine (s);
	}

	decimal CountDecimalPlaces(decimal dec)
	{
		int[] bits = Decimal.GetBits(dec);
		int exponent = bits[3] >> 16;
		int result = exponent;
		long lowDecimal = bits[0] | (bits[1] >> 8);
		while ((lowDecimal % 10) == 0)
		{
			result--;
			lowDecimal /= 10;
		}

		return result;
	}
	void Test()
	{
		Console.WriteLine(CountDecimalPlaces(1.6m));
		Console.WriteLine(CountDecimalPlaces(1.600m));
		Console.WriteLine(CountDecimalPlaces(decimal.MaxValue));
		Console.WriteLine(CountDecimalPlaces(1m * 0.00025m));
		Console.WriteLine(CountDecimalPlaces(4000m * 0.00025m));
	}
}