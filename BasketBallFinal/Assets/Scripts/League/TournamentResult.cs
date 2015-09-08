using UnityEngine;
using System.Collections;

public class TournamentResult  {


	private int roundNUmber;
	private int matchNumber;
	private string homeName;
	private Sprite homeImage;
	private string homeTeamScore;
	private string awayTeamScore;
	private Sprite awayImage;
	private string awayName;
	private Sprite faceCountryHomeSprite;
	private Sprite faceCountryAwaySprite;


	public TournamentResult(int roundNumber,int matchNumber,string homeName, Sprite homeImage,Sprite awayImage,string awayName,Sprite faceCountryHomeSprite,Sprite faceCountryAwaySprite)
	{
		this.roundNUmber=roundNumber;
		this.matchNumber=matchNumber;
		this.homeName=homeName;
		this.homeImage=homeImage;
		this.awayName=awayName;
		this.awayImage=awayImage;
		this.faceCountryHomeSprite=faceCountryHomeSprite;
		this.faceCountryAwaySprite=faceCountryAwaySprite;

	}

	public TournamentResult(string homeName,Sprite homeImage,string awayName,Sprite awayImage)
	{
		this.homeName=homeName;
		this.homeImage=homeImage;
		this.awayName=awayName;
		this.awayImage=awayImage;
	}

	public TournamentResult(string homeName,Sprite homeImage,string awayName,Sprite awayImage,Sprite faceCountryHomeSprite, Sprite faceCountryAwaySprite)
	{
		this.homeName=homeName;
		this.homeImage=homeImage;
		this.awayName=awayName;
		this.awayImage=awayImage;
		this.faceCountryHomeSprite=faceCountryHomeSprite;
		this.faceCountryAwaySprite=faceCountryAwaySprite;
	}

	public int GetRoundNumber()
	{
		return roundNUmber;
	}

	public int GetMatchNumber()
	{
		return matchNumber;
	}

	public Sprite GetHomeImage()
	{
		return homeImage;
	}
	public string GetHomeName()
	{
		return homeName;
	}
	public Sprite GetAwayImage()
	{
		return awayImage;
	}
	public string GetAwayName()
	{
		return awayName;
	}

	public string GetHomeScore()
	{
		return homeTeamScore;
	}

	public string GetAwayScore()
	{
		return awayTeamScore;
	}

	public void SetHomeScore(string homeScore)
	{
		this.homeTeamScore=homeScore;
	}

	public void SetAwayScore(string awayScore)
	{
		this.awayTeamScore= awayScore;
	}

	public Sprite GetFaceHomeSprite()
	{
		return faceCountryHomeSprite;
	}
	public Sprite GetFaceAwaySprite()
	{
		return faceCountryAwaySprite;
	}


}
