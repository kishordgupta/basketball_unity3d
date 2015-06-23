using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections.Generic;

public class League : MonoBehaviour

{
	public int teamNumber;
	public static Country[] countryArray;
	public static  Country[] fixedCountryForFixureArray;
	public static Country selectedCountry;

	public Sprite[] countrySprite;
	public Sprite[] faceSpiteArray;
	public  static List<TournamentResult> tournamentResultList= new List<TournamentResult>();
	public InputField inputField;
	private string teamNumberString;
	public Button fixtureButton;
	public GameObject panel;
	public GameObject PrefabPanel;
	public GameObject countryListPanel;
	public GameObject resultPanel;

	public GameObject confirmPanel;

	public Button resultButton;

	public Button backButton;
	public GameObject countryListParent;
	public GameObject resultPrefab;
	public GameObject fixturePrefab;
	public GameObject showFixureMainPanel;
	public GameObject numberOfPanel;
	public Slider sliderForInput;
	private int roundNo;
	public static int totalRounds;
	public static int matchesPerRound;
	public void GetButton(Button countryButton)
	{


		for (int i=0; i<countryArray.Length; i++) {

			if(countryButton.transform.GetChild(0).GetComponent<Text>().text==countryArray[i].getCountryName())
			{
				selectedCountry= countryArray[i];
				PlayerPrefs.SetString("playerCountry",countryArray[i].getCountryName());

			}
				}
	}



	public void GameStart()
	{
		print("In League Class");
	}

	void Start () 
	{
		countryArray= new Country[19];
		for(int i=0;i<19;i++)
		{
			countryArray[i]= new Country(countrySprite[i],Constants.countryName[i],i,faceSpiteArray[i]);

		}

		for (int i=0; i<19; i++) 
		{
			countryListPanel.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text= countryArray[i].getCountryName();
			countryListPanel.transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().sprite= countryArray[i].getCountryImage();

		}



	//	EventManager.GameStart+=GameStart;

		resultButton.onClick.AddListener(()=>{

//			resultPanel.GetComponent<CanvasGroup> ().alpha = 1f;
//			resultPanel.GetComponent<CanvasGroup> ().interactable = true;
//			resultPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
//
//			PrefabPanel.GetComponent<CanvasGroup> ().alpha = 0f;
//			PrefabPanel.GetComponent<CanvasGroup> ().interactable = false;
//			PrefabPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			if(PlayerPrefs.GetInt("modeName")==3)
			{
			ResultGenerator();	
			}


		});
	
	
	fixtureButton.onClick.AddListener (() => {
					//teamNumberString=inputField.text;

					teamNumberString=sliderForInput.GetComponent<Slider>().value.ToString();
					inputField.text=teamNumberString;
					
					print("number"+teamNumberString);
					//teamNumber = int.Parse(teamNumberString);

					teamNumber = CountrySelect.numberOfTeams;
					//EventManager.TriggerGameStart();
					if(teamNumber<=0||teamNumber>19)
					{
								
					inputField.text =" Sorry,Team number Shouldn't exceed 19";	
						
					}
					else{
							
								
								if(CountrySelect.selectedCountry!=null)
								{
									panel.GetComponent<CanvasGroup> ().alpha = 0f;
									panel.GetComponent<CanvasGroup> ().interactable = false;
									panel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
					
									showFixureMainPanel.GetComponent<CanvasGroup> ().alpha = 1f;//prefabPanel
									showFixureMainPanel.GetComponent<CanvasGroup> ().interactable = true;
									showFixureMainPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

									PrefabPanel.GetComponent<CanvasGroup> ().alpha = 1f;//prefabPanel
									PrefabPanel.GetComponent<CanvasGroup> ().interactable = true;
									PrefabPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

									countryListParent.GetComponent<CanvasGroup> ().alpha = 0f;
									countryListParent.GetComponent<CanvasGroup> ().interactable = false;
									countryListParent.GetComponent<CanvasGroup> ().blocksRaycasts = false;

									fixtureGenerator(teamNumber);
								}

								else{
										inputField.text="Select Your Country";
									}
						
						}
					
				});

		backButton.onClick.AddListener(()=>{


			if(PlayerPrefs.GetInt("modeName")==3)
			{
				fixedCountryForFixureArray=null;
				tournamentResultList.Clear();
			showFixureMainPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			showFixureMainPanel.GetComponent<CanvasGroup> ().interactable = false;
			showFixureMainPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			
			PrefabPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			PrefabPanel.GetComponent<CanvasGroup> ().interactable = false;
			PrefabPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;


			numberOfPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			numberOfPanel.GetComponent<CanvasGroup> ().interactable = true;
			numberOfPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

				for(int i=0;i<PrefabPanel.transform.GetChild(0).transform.childCount;i++)
				{
					Destroy(PrefabPanel.transform.GetChild(0).transform.GetChild(i).gameObject);
					
				}

			}

			else if(PlayerPrefs.GetInt("modeName")==2)
			{
				showFixureMainPanel.GetComponent<CanvasGroup> ().alpha = 0f;
				showFixureMainPanel.GetComponent<CanvasGroup> ().interactable = false;
				showFixureMainPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				
				PrefabPanel.GetComponent<CanvasGroup> ().alpha = 0f;
				PrefabPanel.GetComponent<CanvasGroup> ().interactable = false;
				PrefabPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				
				
				confirmPanel.GetComponent<CanvasGroup> ().alpha = 1f;
				confirmPanel.GetComponent<CanvasGroup> ().interactable = true;
				confirmPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

				ChampionshipMain.championshipTournamentList.Clear();
				ChampionshipMain.championshipCountryList.Clear();
				
				for(int i=0;i<PrefabPanel.transform.GetChild(0).transform.childCount;i++)
				{
					Destroy(PrefabPanel.transform.GetChild(0).transform.GetChild(i).gameObject);
					
				}
			}


		
		
			
		

		});
	
	}


	
	
	void Update () {
		
	}


	
	
	void fixtureGenerator(int numberOfTeams)
	{
		
		 totalRounds= numberOfTeams-1;
		 matchesPerRound = numberOfTeams / 2;
		//bool sameCountry = true;

		
		fixedCountryForFixureArray = new Country[numberOfTeams];

		fixedCountryForFixureArray[0]= CountrySelect.selectedCountry;
		int randomNumber = Random.Range(1,18);


		for(int i=1;i<numberOfTeams;)
		{
			Country inputForFixureArray =countryArray[randomNumber];
			randomNumber++;
			if(randomNumber>=19)
			{
				randomNumber=0;
			}
			if(CountrySelect.selectedCountry.GetCountryTag()!=inputForFixureArray.GetCountryTag())
			{ 
				fixedCountryForFixureArray[i]= inputForFixureArray;
				i++;
			}
			else
			{
				print ("for test only in league class");
			}
		}
	


		
		string[][] rounds = new string[totalRounds][];
		
		
		for (int i = 0; i < totalRounds; i++)
			{
				rounds[i] = new string[matchesPerRound];
				
			}
		for (int round = 0; round < totalRounds; round++)
			{
				for (int match = 0; match < matchesPerRound; match++)
				{
					int home = (round + match) % (numberOfTeams - 1);
					int away = (numberOfTeams - 1 - match + round) % (numberOfTeams - 1);
					if (match == 0){
						away = numberOfTeams - 1;
					}
					
					rounds[round][match] = fixedCountryForFixureArray[home].getCountryImage() + " v" + fixedCountryForFixureArray[away].getCountryName();
					int matchNumber=round*matchesPerRound+match+1;
					TournamentResult tournamentResultObject= new TournamentResult(round+1,matchNumber,fixedCountryForFixureArray[home].getCountryName(),
				                                                              fixedCountryForFixureArray[home].getCountryImage(),fixedCountryForFixureArray[away].getCountryImage(),
				                                                              fixedCountryForFixureArray[away].getCountryName(),fixedCountryForFixureArray[home].getFaceForCountry(),
				                                                              fixedCountryForFixureArray[away].getFaceForCountry());
						tournamentResultList.Add(tournamentResultObject);
						
					
					

					GameObject fixureObject= Instantiate(fixturePrefab)as GameObject;
					fixureObject.transform.SetParent (GameObject.Find ("ParentPanelPrefab").transform, false);
					
					fixureObject.transform.GetComponent<CanvasGroup>().alpha=1f;
					fixureObject.transform.GetComponent<CanvasGroup>().interactable=true;
					fixureObject.transform.GetComponent<CanvasGroup>().blocksRaycasts=true;
					
					
					fixureObject.transform.GetChild(0).GetComponent<Text>().text =fixedCountryForFixureArray[home].getCountryName();
					fixureObject.transform.GetChild(3).GetComponent<Text>().text =fixedCountryForFixureArray[away].getCountryName();
					fixureObject.transform.GetChild(2).GetComponent<Image>().sprite = fixedCountryForFixureArray[home].getCountryImage();
					fixureObject.transform.GetChild(4).GetComponent<Image>().sprite = fixedCountryForFixureArray[away].getCountryImage();

					
				}
				
			}
			
			

	}

	void ResultGenerator()
	{
//		string homeScore;
	//	string awayScore;
		PlayerPrefs.SetInt("roundNumber",1);

		for(int i=0;i<tournamentResultList.Count;i++)
		{

			if(tournamentResultList.ElementAt(i).GetRoundNumber()==PlayerPrefs.GetInt("roundNumber"))
			{

				if(tournamentResultList.ElementAt(i).GetHomeName()==CountrySelect.selectedCountry.getCountryName()||tournamentResultList.ElementAt(i).GetAwayName()==CountrySelect.selectedCountry.getCountryName())
			{
			 	
//				tournamentResultList.ElementAt(i).SetHomeScore(PlayerPrefs.GetInt("playerScore").ToString());
//				tournamentResultList.ElementAt(i).SetAwayScore(PlayerPrefs.GetInt("opponentScore").ToString());

					if(tournamentResultList.ElementAt(i).GetHomeName()==CountrySelect.selectedCountry.getCountryName())
					{
						//PlayerPrefs.SetString("opponentName",tournamentResultList.ElementAt(i).GetAwayName());
						Application.LoadLevel(1);

					}
					else
					{
						//PlayerPrefs.SetString("opponentName",tournamentResultList.ElementAt(i).GetHomeName());
						Application.LoadLevel(1);
					}


			}
			else
			{
//				homeScore= Random.Range(0,5).ToString();
//				awayScore = Random.Range(0,5).ToString();
//				tournamentResultList.ElementAt(i).SetHomeScore(homeScore);
//				tournamentResultList.ElementAt(i).SetAwayScore(awayScore);

			}
	





//				GameObject resultObjectPrefab= Instantiate(resultPrefab)as GameObject;
//				resultObjectPrefab.transform.SetParent (GameObject.Find ("ResultParent").transform, false);
//				resultObjectPrefab.transform.GetComponent<CanvasGroup>().alpha=1f;
//				resultObjectPrefab.transform.GetComponent<CanvasGroup>().interactable=true;
//				resultObjectPrefab.transform.GetComponent<CanvasGroup>().blocksRaycasts=true;
//				resultObjectPrefab.transform.GetChild(0).GetComponent<Text>().text =tournamentResultList.ElementAt(i).GetMatchNumber().ToString();
//				resultObjectPrefab.transform.GetChild(1).GetComponent<Image>().sprite = tournamentResultList.ElementAt(i).GetHomeImage();
//
//				resultObjectPrefab.transform.GetChild(2).GetComponent<Text>().text =tournamentResultList.ElementAt(i).GetHomeName();
//
//				resultObjectPrefab.transform.GetChild(4).GetComponent<Text>().text =tournamentResultList.ElementAt(i).GetAwayName();
//				resultObjectPrefab.transform.GetChild(5).GetComponent<Image>().sprite = tournamentResultList.ElementAt(i).GetAwayImage();
//				resultObjectPrefab.transform.GetChild(6).GetComponent<Text>().text =tournamentResultList.ElementAt(i).GetHomeScore();
//				resultObjectPrefab.transform.GetChild(7).GetComponent<Text>().text =tournamentResultList.ElementAt(i).GetAwayScore();


			}

		}
	}

	void PlayBasketBall()
	{
		string homeScore;
		string awayScore;
		for(int i=0;i<tournamentResultList.Count;i++)
		{
			if(tournamentResultList.ElementAt(i).GetHomeName()==CountrySelect.selectedCountry.getCountryName()||tournamentResultList.ElementAt(i).GetAwayName()==CountrySelect.selectedCountry.getCountryName())
			{
				
				tournamentResultList.ElementAt(i).SetHomeScore("?");
				tournamentResultList.ElementAt(i).SetAwayScore("?");
				
			}
			else
			{
				homeScore= Random.Range(0,5).ToString();
				awayScore = Random.Range(0,5).ToString();
				tournamentResultList.ElementAt(i).SetHomeScore(homeScore);
				tournamentResultList.ElementAt(i).SetAwayScore(awayScore);
				
			}
			
		}

	}
}
