using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class ChampionshipGame : MonoBehaviour {


	public Button showResultButton;

	public GameObject resultPrefab;
	public GameObject championshipGameOverPanel;

	public Button playNextRoundButton;
	public Button backTogameOverChampionship;
	public Button backToMainMenuFromChampionship;
	public Text roundName;
	private bool ownCountry=false;

	public GameObject playerPositionPanel;

	public Text positionText;

	public bool showResultBool;

	void Start () {
		showResultBool=true;
		backTogameOverChampionship.onClick.AddListener(()=>{

			championshipGameOverPanel.GetComponent<CanvasGroup>().alpha=1.0f;
			championshipGameOverPanel.GetComponent<CanvasGroup>().interactable=true;
			championshipGameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;

			this.gameObject.GetComponent<CanvasGroup>().alpha=0.0f;
			this.gameObject.GetComponent<CanvasGroup>().interactable=false;
			this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts=false;

		});

		backToMainMenuFromChampionship.onClick.AddListener(()=>{

			Application.LoadLevel(0);
			ChampionshipMain.championshipCountryList.Clear();
			ChampionshipMain.championshipCountryList.Clear();
		});




		switch(ChampionshipMain.championshipCountryList.Count)
		{
		case 2:

			roundName.text="Final";
			break;
		case 4:
			roundName.text="Semi Final";
			break;
		case 8:
			roundName.text="Quarter Final";
			break;
		case 16:
			roundName.text="1st Round";
			break;
		default:
			break;

		}

		if(PlayerPrefs.GetInt("modeValue")==4)
		{
			showResultButton.GetComponent<CanvasGroup>().alpha=0.0f;
			showResultButton.GetComponent<CanvasGroup>().interactable=false;
			showResultButton.GetComponent<CanvasGroup>().blocksRaycasts=false;
		}
	
		showResultButton.onClick.AddListener(()=>{
			championshipGameOverPanel.GetComponent<CanvasGroup>().alpha=0.0f;
			championshipGameOverPanel.GetComponent<CanvasGroup>().interactable=false;
			championshipGameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts=false;
			Time.timeScale=0.0f;

			ShowChampionshipResult();

		});

		playNextRoundButton.onClick.AddListener(()=>{


			print("tournamentNumber"+ChampionshipMain.championshipTournamentList.Count);
			for(int i=0;i<ChampionshipMain.championshipTournamentList.Count;i++)
			{
				if(CountrySelect.selectedCountry.getCountryName()==ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeName())
				   
				{ int homeScore= int.Parse(ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeScore()); 
					int awayScore= int.Parse(ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayScore()); 

					if(homeScore>=awayScore)
					{
						ownCountry=true;
					}
					break;
				}

				else if(CountrySelect.selectedCountry.getCountryName()==ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayName())
				{
					int homeScore= int.Parse(ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeScore()); 
					int awayScore= int.Parse(ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayScore()); 
					
					if(awayScore>=homeScore)
					{
						ownCountry=true;
					}
					break;
				}
			}
			if(ownCountry)
			{
				Time.timeScale=1.0f;
				GenerateChampionshipResult();
				Application.LoadLevel(1);
			}
			else
			{
				playerPositionPanel.GetComponent<CanvasGroup>().alpha=1.0f;
				playerPositionPanel.GetComponent<CanvasGroup>().interactable=true;
				playerPositionPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;

				this.gameObject.GetComponent<CanvasGroup>().alpha=0.0f;
				this.gameObject.GetComponent<CanvasGroup>().interactable=false;
				this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts=false;

				positionText.GetComponent<Text>().text="You Have Been Knocked Out!!!";
				print("You Have Been Knocked Out!");
			}
		});
	}
	

	void Update () {
	
	}

	void ShowChampionshipResult()
	{
		this.gameObject.GetComponent<CanvasGroup>().alpha=1.0f;
		this.gameObject.GetComponent<CanvasGroup>().interactable=true;
		this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts=true;

		if(showResultBool)
		{
		for(int i=0;i<ChampionshipMain.championshipTournamentList.Count;i++)
		{


			GameObject resultObjectPrefab= Instantiate(resultPrefab)as GameObject;
			resultObjectPrefab.transform.SetParent (GameObject.Find ("championShipParent").transform, false);
			
			if(CountrySelect.selectedCountry.getCountryName()==ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeName())
			{
				ChampionshipMain.championshipTournamentList.ElementAt(i).SetHomeScore(Ball.playerScore.ToString());
				ChampionshipMain.championshipTournamentList.ElementAt(i).SetAwayScore(Ball.oppnentScore.ToString());
			}
			
			else if(CountrySelect.selectedCountry.getCountryName()==ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayName())
			{
				ChampionshipMain.championshipTournamentList.ElementAt(i).SetAwayScore(Ball.playerScore.ToString());
				ChampionshipMain.championshipTournamentList.ElementAt(i).SetHomeScore(Ball.oppnentScore.ToString());
				
			}
			
			else
			{
				ChampionshipMain.championshipTournamentList.ElementAt(i).SetHomeScore(Random.Range(0,5).ToString());
				ChampionshipMain.championshipTournamentList.ElementAt(i).SetAwayScore(Random.Range(0,5).ToString());
			}

			resultObjectPrefab.transform.GetChild(0).GetComponent<Text>().text =(i+1).ToString();
			resultObjectPrefab.transform.GetChild(1).GetComponent<Image>().sprite = ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeImage();
			
			resultObjectPrefab.transform.GetChild(2).GetComponent<Text>().text =ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeName();
			
			resultObjectPrefab.transform.GetChild(4).GetComponent<Text>().text =ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayName();
			resultObjectPrefab.transform.GetChild(5).GetComponent<Image>().sprite = ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayImage();
			resultObjectPrefab.transform.GetChild(6).GetComponent<Text>().text =ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeScore();
			resultObjectPrefab.transform.GetChild(7).GetComponent<Text>().text =ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayScore();
		}
		}
		showResultBool=false;
	}

	void GenerateChampionshipResult()
	{
		ChampionshipMain.championshipCountryList= new List<Country>();


		for(int i=0;i<ChampionshipMain.championshipTournamentList.Count;i++)
		{
			int homeScore= int.Parse(ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeScore());
			int awayScore= int.Parse(ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayScore());

			if(homeScore>awayScore)
			{
				Country inputForCountryList = new Country(ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeImage(),
				                                          ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeName(),
				                                          i,ChampionshipMain.championshipTournamentList.ElementAt(i).GetFaceHomeSprite());
				print ("input"+inputForCountryList.getCountryName());
				ChampionshipMain.championshipCountryList.Add(inputForCountryList);

			}

			else if(awayScore>homeScore)
			{
				Country inputForCountryList = new Country(ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayImage(),
				                                          ChampionshipMain.championshipTournamentList.ElementAt(i).GetAwayName(),
				                                          i,ChampionshipMain.championshipTournamentList.ElementAt(i).GetFaceAwaySprite());

				ChampionshipMain.championshipCountryList.Add(inputForCountryList);

			}

			else if(homeScore==awayScore)
			{
				Country inputForCountryList = new Country(ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeImage(),
				                                          ChampionshipMain.championshipTournamentList.ElementAt(i).GetHomeName(),
				                                          i,ChampionshipMain.championshipTournamentList.ElementAt(i).GetFaceHomeSprite());
				
				ChampionshipMain.championshipCountryList.Add(inputForCountryList);
			}
		}

		ChampionshipMain.championshipTournamentList=new List<TournamentResult>();

		print("countryNumber"+ChampionshipMain.championshipCountryList.Count);


		for(int i=0,j=(ChampionshipMain.championshipCountryList.Count-1);i<j;i++,j--)
		{
			TournamentResult inputForTournament =new TournamentResult(ChampionshipMain.championshipCountryList.ElementAt(i).getCountryName(),ChampionshipMain.championshipCountryList.ElementAt(i).getCountryImage(),
			                                                          ChampionshipMain.championshipCountryList.ElementAt(j).getCountryName(),ChampionshipMain.championshipCountryList.ElementAt(j).getCountryImage(),
			                                                          ChampionshipMain.championshipCountryList.ElementAt(i).getFaceForCountry(),ChampionshipMain.championshipCountryList.ElementAt(j).getFaceForCountry());

			ChampionshipMain.championshipTournamentList.Add (inputForTournament);
		}


	}
}
