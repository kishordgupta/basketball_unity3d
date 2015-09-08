using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Country {

	
	
	private Sprite countryImage;
	private Sprite faceForCountry;
	private string countryName;
	private int countryTag;
	private int points=0;
	
	public Country(Sprite countryImage,string countryName,int countryTag,Sprite faceForCountry)
	{
		this.countryImage= countryImage;
		this.countryName = countryName;
		this.countryTag = countryTag;
		this.faceForCountry = faceForCountry;
	}

	public Country(Sprite faceForCountry,int countryTag,string countryName)
	{
		this.faceForCountry=faceForCountry;
		this.countryName=countryName;
		this.countryTag=countryTag;
	}
	
	public string getCountryName()
	{
		return countryName;
	}
	
	
	
	public Sprite getCountryImage()
	{
		return countryImage;
	}

	public Sprite getFaceForCountry()
	{
		return faceForCountry;
	}

	public int GetCountryTag()
	{
		return countryTag;
	}

	public int GetPoints()
	{
		return points;
	}

	public void SetPoint(int points)
	{
		this.points+=points;
	}
	
}
