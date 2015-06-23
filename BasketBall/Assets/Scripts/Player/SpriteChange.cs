using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;



public class SpriteChange : MonoBehaviour {


	public static List<TournamentResult> roundTournamentResultList= new List<TournamentResult>();
	public Opponent opponentTeam;

	public Image homeImage;
	public Image awayImage;

	void Start () {
	


		switch(PlayerPrefs.GetInt("modeName"))
		{
		case 0:
			SetArcadeSprite();
			break;
		case 1:
			SetClassicSprite();
			break;
		case 2:
			SetChampionshipSprite();
			break;
		case 3:
			SetTournamentSprite();
			break;
		default:
			break;
			
			
		}
	}

	void SetArcadeSprite()
	{

	
		for(int i=0;;i++)
		{
			int randomNumber = Random.Range(0,18);
			if(CountrySelect.countryArray[randomNumber].getCountryName()!=CountrySelect.selectedCountry.getCountryName())
			{
				opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=	CountrySelect.countryArray[randomNumber].getFaceForCountry();
				awayImage.GetComponent<Image>().sprite=CountrySelect.countryArray[randomNumber].getCountryImage();
				break;
			}
		}

	
							for(int i=0;i<CountrySelect.countryArray.Length;i++)
								{
									
									if(CountrySelect.countryArray[i].getCountryName()==CountrySelect.selectedCountry.getCountryName())
									{
										gameObject.GetComponent<SpriteRenderer>().sprite=CountrySelect.countryArray[i].getFaceForCountry();
										homeImage.GetComponent<Image>().sprite=CountrySelect.countryArray[i].getCountryImage();
								
									}
									
								}


						

	}

	void SetClassicSprite()
	{
		for(int i=0;;i++)
		{
			int randomNumber = Random.Range(0,18);
			if(CountrySelect.countryArray[randomNumber].getCountryName()!=CountrySelect.selectedCountry.getCountryName())
			{
				opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=	CountrySelect.countryArray[randomNumber].getFaceForCountry();
				awayImage.GetComponent<Image>().sprite=CountrySelect.countryArray[randomNumber].getCountryImage();
				break;
			}
		}
		
		
		for(int i=0;i<CountrySelect.countryArray.Length;i++)
		{
			
			if(CountrySelect.countryArray[i].getCountryName()==CountrySelect.selectedCountry.getCountryName())
			{
				gameObject.GetComponent<SpriteRenderer>().sprite=CountrySelect.countryArray[i].getFaceForCountry();
				homeImage.GetComponent<Image>().sprite=CountrySelect.countryArray[i].getCountryImage();
				
			}
			
		}
	}

	void SetChampionshipSprite()
	{

		for(int i=0;i<ChampionshipMain.championshipTournamentList.Count;i++)
		{
			if(ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeName()==CountrySelect.selectedCountry.getCountryName())
			{
				gameObject.GetComponent<SpriteRenderer>().sprite=ChampionshipMain.championshipTournamentList.ElementAt(i).GetFaceHomeSprite();
				opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=ChampionshipMain.championshipTournamentList.ElementAt(i).GetFaceAwaySprite();

				homeImage.GetComponent<Image>().sprite=ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeImage();
				awayImage.GetComponent<Image>().sprite=ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayImage();

				print(ChampionshipMain.championshipTournamentList.ElementAt(i).GetFaceHomeSprite());
				break;



			}

			else if(ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayName()==CountrySelect.selectedCountry.getCountryName())
			{
				gameObject.GetComponent<SpriteRenderer>().sprite=ChampionshipMain.championshipTournamentList.ElementAt(i).GetFaceAwaySprite();
				opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=ChampionshipMain.championshipTournamentList.ElementAt(i).GetFaceHomeSprite();
				homeImage.GetComponent<Image>().sprite=ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayImage();
				awayImage.GetComponent<Image>().sprite=ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeImage();
				break;
				
			}
				
			
		}
	}

	void SetTournamentSprite()
	{

		roundTournamentResultList=new List<TournamentResult>();

		
		for(int i=0;i<League.tournamentResultList.Count;i++)
		{
			if(League.tournamentResultList.ElementAt(i).GetRoundNumber()==PlayerPrefs.GetInt("roundNumber"))
			{
				roundTournamentResultList.Add (League.tournamentResultList.ElementAt(i));
				print (PlayerPrefs.GetInt("roundNumber"));
			}
			
		}
		
		
		for(int i=0;i<roundTournamentResultList.Count;i++)
		{
			if(CountrySelect.selectedCountry.getCountryName()==roundTournamentResultList.ElementAt(i).GetHomeName())
			{
				gameObject.GetComponent<SpriteRenderer>().sprite=roundTournamentResultList.ElementAt(i).GetFaceHomeSprite();
				opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=roundTournamentResultList.ElementAt(i).GetFaceAwaySprite();
				print("home"+roundTournamentResultList.ElementAt(i).GetHomeImage());
				homeImage.GetComponent<Image>().sprite=roundTournamentResultList.ElementAt(i).GetHomeImage();
				awayImage.GetComponent<Image>().sprite=roundTournamentResultList.ElementAt(i).GetAwayImage();
				print(roundTournamentResultList.ElementAt(i).GetHomeName()+roundTournamentResultList.ElementAt(i).GetAwayName());
			}
			else if(CountrySelect.selectedCountry.getCountryName()==roundTournamentResultList.ElementAt(i).GetAwayName())
			{
				gameObject.GetComponent<SpriteRenderer>().sprite=roundTournamentResultList.ElementAt(i).GetFaceAwaySprite();
				opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=roundTournamentResultList.ElementAt(i).GetFaceHomeSprite();
				print("Away "+roundTournamentResultList.ElementAt(i).GetHomeImage());
				homeImage.GetComponent<Image>().sprite=roundTournamentResultList.ElementAt(i).GetAwayImage();
				awayImage.GetComponent<Image>().sprite=roundTournamentResultList.ElementAt(i).GetHomeImage();
				
			}
		}

	}

	void generateRandomNumber()
	{
		int randomNumber = Random.Range(0,18);
		if(CountrySelect.countryArray[randomNumber].getCountryName()!=CountrySelect.selectedCountry.getCountryName())
		{
			opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=	CountrySelect.countryArray[randomNumber].getFaceForCountry();
		}
		
		else
		{
		}
	}
	

	void Update () {
	
	}
}
