using System;
using System.IO;

public class SingleLabelling
{
	//All the necessary variables
	float temptruncated;	//truncation angle
	int tempoccluded;		//occlusion value
	float tempalpha;		//alpha value

	//bounding box coordinates
	float tempbboxLeft;
	float tempbboxTop;
	float tempbboxRight;
	float tempbboxBottom;

	//dimensions of object
	float tempdimensionHeight;
	float tempdimensionWidth;
	float tempdimensionLength;

	//location and rotation of object
	float templocationX;
	float templocationY;
	float templocationZ;
	float temprotationY;

	public void SingleImageLabelling ()
	{
		FindFile file = new FindFile();
		Data newData = new Data ();	//create the default constructor of Data

		//find the file and open it
		file.Find ();

		//display console instruction of data type
		DefineType ();
		newData.setType(Console.ReadLine ());							//set the new type

		//display console instruction of truncation
		DefineTruncate ();
		newData.setTruncated (temptruncated);						//set the truncate amount

		//display console instruction of occlusion
		DefineOccluded ();
		newData.setOcculuded (tempoccluded);						//set the occlusion amount

		//display console instruction of alpha
		DefineAlpha ();
		newData.setAlpha (tempalpha);						//set the alpha amount



		//display console instruction of left coordinate
		DefineBBoxLeft ();
		newData.setBBoxLeft (tempbboxLeft);						//set the left coordinate

		//display console instruction of top coordinate
		DefineBBoxTop ();
		newData.setBBoxTop (tempbboxTop);						//set the top coordinate

		//display console instruction of right coordinate
		DefineBBoxRight ();
		newData.setBBoxRight (tempbboxRight);						//set the right coordinate

		//display console instruction of bottom coordinate
		DefineBBoxBottom ();
		newData.setBBoxBottom (tempbboxBottom);						//set the bottom coordinate



		//display console instruction of dimension height
		DefineDimensionHeight ();
		newData.setDimensionHeight (tempdimensionHeight);			//set the dimension height

		//display console instruction of dimension width
		DefineDimensionWidth ();
		newData.setDimensionWidth (tempdimensionWidth);			//set the dimension width

		//display console instruction of dimension length
		DefineDimensionLength ();
		newData.setDimensionLength (tempdimensionLength);			//set the dimension length


		//display console instruction of camera location X
		DefineCamLocX ();
		newData.setLocationX (templocationX);			//set the camera location X

		//display console instruction of camera location Y
		DefineCamLocY ();
		newData.setLocationY (templocationY);			//set the camera location Y

		//display console instruction of camera location Z
		DefineCamLocZ ();
		newData.setLocationZ (templocationZ);			//set the camera location Z

		DefineRotY ();
		newData.setRotationY (temprotationY);			//set the rotation Y


		//review the user's input
		ReviewOrder ();
		Console.WriteLine ("Object Name      : " + newData.getType ());
		Console.WriteLine ("Truncation       : " + newData.getTruncated ());
		Console.WriteLine ("Occlusion        : " + newData.getOcculuded ());
		Console.WriteLine ("Observation Angle: " + newData.getAlpha ());


		Console.WriteLine ("BBox Left Coord  : " + newData.getBBoxLeft ());
		Console.WriteLine ("BBox Top Coord   : " + newData.getBBoxTop ());
		Console.WriteLine ("BBox Right Coord : " + newData.getBBoxRight ());
		Console.WriteLine ("BBox Bottom Coord: " + newData.getBBoxBottom ());

		Console.WriteLine ("3D Object Height : " + newData.getDimensionHeight ());
		Console.WriteLine ("3D Object Width  : " + newData.getDimensionWidth ());
		Console.WriteLine ("3D Object Length : " + newData.getDimensionLength ());

		Console.WriteLine ("Camera Location X: " + newData.getLocationX ());
		Console.WriteLine ("Camera Location Y: " + newData.getLocationY ());
		Console.WriteLine ("Camera Location Z: " + newData.getLocationZ ());
		Console.WriteLine ("Camera Rotation Y: " + newData.getRotationY ());

		ConfirmOrder ();		//confirm the final order

		//write to text file
		//Hook a write to text file, allow for appending of data
		TextWriter writer = new StreamWriter(file.targetLabelFile, true);

		//write into text file
		writer.WriteLine (newData.getType () + " " + newData.getTruncated () + " " + newData.getOcculuded () + " " + newData.getAlpha() 
			+ " " + newData.getBBoxLeft() + " " + newData.getBBoxTop() + " " + newData.getBBoxRight() + " " + newData.getBBoxBottom()
			+ " " + newData.getDimensionHeight() + " " + newData.getDimensionWidth() + " " + newData.getDimensionLength() 
			+ " " + newData.getLocationX() + " " + newData.getLocationY() + " " + newData.getLocationZ() + " " + newData.getRotationY());

		//close the text file
		writer.Close ();
	}
	void DefineType()
	{
		//guide the user through the KITTI labelling standarad
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Follow the instructions and add in the input accordingly");
		Console.WriteLine ("=========================================");

		Console.WriteLine ("Define the object type (eg. Car, Truck)");
	}
	void DefineTruncate()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the truncation (between 0 and 1, leave it to 0 if not needed)");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out temptruncated)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out temptruncated)) 
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

				Console.WriteLine ("Define the truncation (between 0 and 1, leave it to 0 if not needed)");

				float.TryParse (Console.ReadLine (), out temptruncated);
			}
		}
		//check that it has the 2 decimal places required
		if (temptruncated % 1 == 0 || CountDecimalPlaces ((decimal)temptruncated) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineTruncate ();
		} 
		else if (temptruncated > 1 || temptruncated < 0) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Input is not between 0 and 1. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineTruncate ();
		}
	}
	void DefineOccluded()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the occluded value (0 = fully visible, 1 = partly occuluded, 2 = largely occulded, 3 = unknown)");

		//parse the input into a floating number, error checking
		if (!int.TryParse (Console.ReadLine (), out tempoccluded)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (int.TryParse (Console.ReadLine (), out tempoccluded)) 
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

				Console.WriteLine ("Define the occluded value (0 = fully visible, 1 = partly occuluded, 2 = largely occulded, 3 = unknown)");

				int.TryParse (Console.ReadLine (), out tempoccluded);
			}
		}
		if (tempoccluded > 3 || tempoccluded < 0) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Input is not between 0 and 1. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineOccluded ();
		}
	}
	void DefineAlpha()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the observation angle (between -pi and pi, leave it to 0 if not needed)");

		//float.TryParse (Console.ReadLine (), out tempalpha);

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out tempalpha)) 
		{
			//enter into a loop that throws an error if invalid input
			while (!float.TryParse (Console.ReadLine (), out tempalpha)) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out tempalpha)) 
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

				Console.WriteLine ("Define the observation angle (between -pi and pi, leave it to 0 if not needed)");

				float.TryParse (Console.ReadLine (), out tempalpha);
				Math.Round (tempalpha, 2);
			}
		}
		//check that it has the 2 decimal places required
		if (tempalpha%1 == 0 || CountDecimalPlaces ((decimal)tempalpha) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineAlpha ();
		}
		//check if alpha value is between -pi and and pi
		else if (tempalpha > Math.PI || tempalpha < Math.PI) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value is not between -pi and pi. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineAlpha ();
		}
	}
	void DefineBBoxLeft()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the left coordinate of the bounding box");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out tempbboxLeft)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out tempbboxLeft)) 
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

				Console.WriteLine ("Define the left coordinate of the bounding box");

				float.TryParse (Console.ReadLine (), out tempbboxLeft);
				Math.Round (tempbboxLeft, 2);
			}
		}
		//check that it has the 2 decimal places required
		if (tempbboxLeft%1 == 0 || CountDecimalPlaces ((decimal)tempbboxLeft) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineBBoxLeft ();
		}
	}
	void DefineBBoxRight()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the right coordinate of the bounding box");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out tempbboxRight)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out tempbboxRight)) 
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

				Console.WriteLine ("Define the right coordinate of the bounding box");

				float.TryParse (Console.ReadLine (), out tempbboxRight);
				Math.Round (tempbboxRight, 2);
			}
		}
		//check that it has the 2 decimal places required
		if (tempbboxRight%1 == 0 || CountDecimalPlaces ((decimal)tempbboxRight) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineBBoxRight ();
		}
	}
	void DefineBBoxTop()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the top coordinate of the bounding box");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out tempbboxTop)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out tempbboxTop)) 
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

				Console.WriteLine ("Define the top coordinate of the bounding box");

				float.TryParse (Console.ReadLine (), out tempbboxTop);
				Math.Round (tempbboxTop, 2);
			}
		}
		//check that it has the 2 decimal places required
		if (tempbboxTop%1 == 0 || CountDecimalPlaces ((decimal)tempbboxTop) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineBBoxTop ();
		}
	}
	void DefineBBoxBottom()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the bottom coordinate of the bounding box");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out tempbboxBottom)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out tempbboxBottom)) 
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

				Console.WriteLine ("Define the bottom coordinate of the bounding box");

				float.TryParse (Console.ReadLine (), out tempbboxBottom);
				Math.Round (tempbboxBottom, 2);
			}
		}
		//check that it has the 2 decimal places required
		if (tempbboxBottom%1 == 0 || CountDecimalPlaces ((decimal)tempbboxBottom) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineBBoxBottom ();
		}
	}
	void DefineDimensionHeight()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the height of object in the 3D space");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out tempdimensionHeight)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out tempdimensionHeight)) 
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

				Console.WriteLine ("Define the height of object in the 3D space");

				float.TryParse (Console.ReadLine (), out tempdimensionHeight);
				Math.Round (tempdimensionHeight, 2);
			}
		} 
		//check that it has the 2 decimal places required
		if (tempdimensionHeight%1 == 0 || CountDecimalPlaces ((decimal)tempdimensionHeight) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineDimensionHeight ();
		}
	}
	void DefineDimensionWidth()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the width of object in the 3D space");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out tempdimensionWidth)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out tempdimensionWidth)) 
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

				Console.WriteLine ("Define the width of object in the 3D space");

				float.TryParse (Console.ReadLine (), out tempdimensionWidth);
				Math.Round (tempdimensionWidth, 2);
			}
		} 
		//check that it has the 2 decimal places required
		if (tempdimensionWidth%1 == 0 || CountDecimalPlaces ((decimal)tempdimensionWidth) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineDimensionWidth ();
		}
	}
	void DefineDimensionLength()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the length of object in the 3D space");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out tempdimensionLength)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out tempdimensionLength)) 
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

				Console.WriteLine ("Define the length of object in the 3D space");

				float.TryParse (Console.ReadLine (), out tempdimensionLength);
				Math.Round (tempdimensionLength, 2);
			}
		} 
		//check that it has the 2 decimal places required
		if (tempdimensionLength%1 == 0 || CountDecimalPlaces ((decimal)tempdimensionLength) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineDimensionLength ();
		}
	}
	void DefineCamLocX()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the object location in camera coordinate X in meters");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out templocationX)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out templocationX)) 
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

				Console.WriteLine ("Define the object location in camera coordinate X in meters");

				float.TryParse (Console.ReadLine (), out templocationX);
			}
		} 
		//check that it has the 2 decimal places required
		if (templocationX%1 == 0 || CountDecimalPlaces ((decimal)templocationX) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineCamLocX ();
		}
	}
	void DefineCamLocY()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the object location in camera coordinate Y in meters");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out templocationY)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out templocationY)) 
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

				Console.WriteLine ("Define the object location in camera coordinate Y in meters");

				float.TryParse (Console.ReadLine (), out templocationY);
				Math.Round (templocationY, 2);
			}
		} 
		//check that it has the 2 decimal places required
		if (templocationY%1 == 0 || CountDecimalPlaces ((decimal)templocationY) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineCamLocY ();
		}
	}
	void DefineCamLocZ()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the object location in camera coordinate Z in meters");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out templocationZ)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out templocationZ)) 
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

				Console.WriteLine ("Define the object location in camera coordinate Z in meters");

				float.TryParse (Console.ReadLine (), out templocationZ);
			}
		} 
		//check that it has the 2 decimal places required
		if (templocationZ%1 == 0 || CountDecimalPlaces ((decimal)templocationZ) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineCamLocZ ();
		}
	}
	void DefineRotY()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Define the rotation angle of camera around Y axis (between -pi and pi)");

		//parse the input into a floating number, error checking
		if (!float.TryParse (Console.ReadLine (), out temprotationY)) 
		{
			//enter into a loop that throws an error if invalid input
			while (true) 
			{
				//break out of this loop once input is correct
				if (float.TryParse (Console.ReadLine (), out temprotationY)) 
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

				Console.WriteLine ("Define the rotation angle of camera around Y axis (between -pi and pi)");

				float.TryParse (Console.ReadLine (), out temprotationY);
				Math.Round (temprotationY, 2);
			}
		} 
		//check that it has the 2 decimal places required
		if (temprotationY%1 == 0 || CountDecimalPlaces ((decimal)temprotationY) != 2) 
		{
			//this is when there is an error to the input
			//ask the user again
			string error;
			error = "Error: Value needs to be in 2 decimal places. \n";

			Console.WriteLine ("=========================================");
			Console.WriteLine (error);
			DefineRotY ();
		}
	}

	void ReviewOrder()
	{
		Console.WriteLine ("=========================================");
		Console.WriteLine ("Here is the review for all the parameters set. Please check the details are correct.");
	}
	void ConfirmOrder()
	{
		char YesOrNo;					//for confirmation from user later on

		Console.WriteLine ("Confirm? Y/N");

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
			Console.WriteLine ("Confirm? Y/N");
			Console.WriteLine ("=========================================");

			Char.TryParse (Console.ReadLine (), out YesOrNo);

			//Convert to uppercase only
			YesOrNo = Char.ToUpper (YesOrNo);
		}
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
	void WriteToFile(string fileName)
	{
		//write to text file
		//Hook a write to text file, allow for appending of data
		TextWriter writer = new StreamWriter(fileName, true);

		//write into text file
		writer.WriteLine (Console.ReadLine ());

		//close the text file
		writer.Close ();
	}
}