using System;

public class Data
{
	string type;		//type of object
	float truncated;	//truncation angle
	int occluded;		//occlusion value
	float alpha;		//alpha value

	//bounding box coordinates
	float bboxLeft;
	float bboxTop;
	float bboxRight;
	float bboxBottom;

	//dimensions of object
	float dimensionHeight;
	float dimensionWidth;
	float dimensionLength;

	//location and rotation of object
	float locationX;
	float locationY;
	float locationZ;
	float rotationY;

	//constructor
	public Data()
	{
		type = "";
		truncated = 0f;
		occluded = 0;
		alpha = 0f;

		bboxLeft = 0f;
		bboxTop = 0f;
		bboxRight = 0f;
		bboxBottom = 0f;

		dimensionHeight = 0f;
		dimensionWidth = 0f;
		dimensionLength = 0f;

		locationX = 0f;
		locationY = 0f;
		locationZ = 0f;
		rotationY = 0f;
	}

	public void setType(string type)
	{
		this.type = type;
	}
	public string getType()
	{
		return type;
	}
	public void setTruncated(float truncated)
	{
		this.truncated = truncated;
	}
	public float getTruncated()
	{
		return truncated;
	}
	public void setOcculuded(int occluded)
	{
		this.occluded = occluded;
	}
	public int getOcculuded()
	{
		return occluded;
	}
	public void setAlpha(float alpha)
	{
		this.alpha = alpha;
	}
	public float getAlpha()
	{
		return alpha;
	}
	public void setBBoxLeft(float bboxLeft)
	{
		this.bboxLeft = bboxLeft;
	}
	public float getBBoxLeft()
	{
		return bboxLeft;
	}
	public void setBBoxTop(float bboxTop)
	{
		this.bboxTop = bboxTop;
	}
	public float getBBoxTop()
	{
		return bboxTop;
	}
	public void setBBoxRight(float bboxRight)
	{
		this.bboxRight = bboxRight;
	}
	public float getBBoxRight()
	{
		return bboxRight;
	}
	public void setBBoxBottom(float bboxBottom)
	{
		this.bboxBottom = bboxBottom;
	}
	public float getBBoxBottom()
	{
		return bboxBottom;
	}
	public void setDimensionHeight(float dimensionHeight)
	{
		this.dimensionHeight = dimensionHeight;
	}
	public float getDimensionHeight()
	{
		return dimensionHeight;
	}
	public void setDimensionWidth(float dimensionWidth)
	{
		this.dimensionWidth = dimensionWidth;
	}
	public float getDimensionWidth()
	{
		return dimensionWidth;
	}
	public void setDimensionLength(float dimensionLength)
	{
		this.dimensionLength = dimensionLength;
	}
	public float getDimensionLength()
	{
		return dimensionLength;
	}
	public void setLocationX(float locationX)
	{
		this.locationX = locationX;
	}
	public float getLocationX()
	{
		return locationX;
	}
	public void setLocationY(float locationY)
	{
		this.locationY = locationY;
	}
	public float getLocationY()
	{
		return locationY;
	}
	public void setLocationZ(float locationZ)
	{
		this.locationZ = locationZ;
	}
	public float getLocationZ()
	{
		return locationZ;
	}
	public void setRotationY(float rotationY)
	{
		this.rotationY = rotationY;
	}
	public float getRotationY()
	{
		return rotationY;
	}
}