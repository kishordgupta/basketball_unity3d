using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;




public class ShowResultLeague : MonoBehaviour {


	public Button showResultButton; 
	public GameObject resultPrefab;
	public GameObject resultPanelMain;
	public GameObject gameOverPanel;

	public Button PlayAgainButton;
	public Button pointTableButton;
	public Button backToGameOverPanel;
	public Button backToMainMenuFromPositionPanel;

	public GameObject resultParent;
	public GameObject pointParent;
	

	public GameObject pointTablePrefab;
	public GameObject pointPanelMain;
	public GameObject playerPositionPanel;

	private bool resultGeneratorBool;
	private bool pointTableGenerator;



	void Start () {
	
		resultGeneratorBool=true;
		pointTableGenerator=true;

		backToMainMenuFromPositionPanel.onClick.AddListener(()=>{
			League.fixedCountryForFixureArray=null;
			League.tournamentResultList.Clear();
			League.countryArray=null;
			CountrySelect.countryArray=null;
			SpriteChange.roundTournamentResultList.Clear();
			Application.LoadLevel(0);
		});

		showResultButton.onClick.AddListener(()=>{


			this.gameObject.GetComponent<CanvasGroup>().alpha=1;
			this.gameObject.GetComponent<CanvasGroup>().interactable=true;
			this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts=true;

			resultPanelMain.GetComponent<CanvasGroup>().alpha=1;
			resultPanelMain.GetComponent<CanvasGroup>().interactable=true;
			resultPanelMain.GetComponent<CanvasGroup>().blocksRaycasts=true;

			gameOverPanel.GetComponent<CanvasGroup>().alpha=0;
			gameOverPanel.GetComponent<CanvasGroup>().interactable=false;
			gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts=false;

			pointPanelMain.GetComponent<CanvasGroup>().alpha=0f;
			pointPanelMain.GetComponent<CanvasGroup>().interactable=false;
			pointPanelMain.GetComponent<CanvasGroup>().blocksRaycasts=false;


			Time.timeScale=0.0f;

			if(resultGeneratorBool)
			{
			for(int i=0;i<SpriteChange.roundTournamentResultList.Count;i++)
			{
				print(SpriteChange.roundTournamentResultList.ElementAt(i).GetHomeName()+"VS"+SpriteChange.roundTournamentResultList.ElementAt(i).GetAwayName());


				GameObject resultObjectPrefab= Instantiate(resultPrefab)as GameObject;
				resultObjectPrefab.transform.SetParent (GameObject.Find ("ResultParent").transform, false);

				if(CountrySelect.selectedCountry.getCountryName()==SpriteChange.roundTournamentResultList.ElementAt(i).GetHomeName())
				{
					SpriteChange.roundTournamentResultList.ElementAt(i).SetHomeScore(Ball.playerScore.ToString());
					SpriteChange.roundTournamentResultList.ElementAt(i).SetAwayScore(Ball.oppnentScore.ToString());
				}

				else if(CountrySelect.selectedCountry.getCountryName()==SpriteChange.roundTournamentResultList.ElementAt(i).GetAwayName())
				{
					SpriteChange.roundTournamentResultList.ElementAt(i).SetAwayScore(Ball.playerScore.ToString());
					SpriteChange.roundTournamentResultList.ElementAt(i).SetHomeScore(Ball.oppnentScore.ToString());



				}

				else
				{

					SpriteChange.roundTournamentResultList.ElementAt(i).SetHomeScore(Random.Range(0,5).ToString());
					SpriteChange.roundTournamentResultList.ElementAt(i).SetAwayScore(Random.Range(0,5).ToString());


				}

			

				resultObjectPrefab.transform.GetChild(0).GetComponent<Text>().text =SpriteChange.roundTournamentResultList.ElementAt(i).GetMatchNumber().ToString();
				resultObjectPrefab.transform.GetChild(1).GetComponent<Image>().sprite = SpriteChange.roundTournamentResultList.ElementAt(i).GetHomeImage();
				
				resultObjectPrefab.transform.GetChild(2).GetComponent<Text>().text =SpriteChange.roundTournamentResultList.ElementAt(i).GetHomeName();
				
				resultObjectPrefab.transform.GetChild(4).GetComponent<Text>().text =SpriteChange.roundTournamentResultList.ElementAt(i).GetAwayName();
				resultObjectPrefab.transform.GetChild(5).GetComponent<Image>().sprite = SpriteChange.roundTournamentResultList.ElementAt(i).GetAwayImage();
				resultObjectPrefab.transform.GetChild(6).GetComponent<Text>().text =SpriteChange.roundTournamentResultList.ElementAt(i).GetHomeScore();
				resultObjectPrefab.transform.GetChild(7).GetComponent<Text>().text =SpriteChange.roundTournamentResultList.ElementAt(i).GetAwayScore();
			}
				resultGeneratorBool=false;
			}
			PointGenerator();

		});


		PlayAgainButton.onClick.AddListener(()=>{

			int roundNumber= PlayerPrefs.GetInt("roundNumber");
			roundNumber++;
			PlayerPrefs.SetInt("roundNumber",roundNumber);
			if(PlayerPrefs.GetInt("roundNumber")>=League.totalRounds)
			{
				showPositionOfPLayer();

			
			}
			else
			{
			Time.timeScale=1.0f;
			Ball.playerScore=0;
			Ball.oppnentScore=0;
			Application.LoadLevel(1);
			}
		});

		pointTableButton.onClick.AddListener(()=>{

			ShowPointOfTeams();
			this.gameObject.GetComponent<CanvasGroup>().alpha=0.0f;
			this.gameObject.GetComponent<CanvasGroup>().interactable=false;
			this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts=false;

			pointPanelMain.GetComponent<CanvasGroup>().alpha=1f;
			pointPanelMain.GetComponent<CanvasGroup>().interactable=true;
			pointPanelMain.GetComponent<CanvasGroup>().blocksRaycasts=true;


			for(int point=0;point<League.fixedCountryForFixureArray.Length;point++)
			{
				print(League.fixedCountryForFixureArray[point].getCountryName()+":"+League.fixedCountryForFixureArray[point].GetPoints());
			}

		});


		backToGameOverPanel.onClick.AddListener(()=> {

			this.gameObject.GetComponent<CanvasGroup>().alpha=0.0f;
			this.gameObject.GetComponent<CanvasGroup>().interactable=false;
			this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts=false;

			resultPanelMain.GetComponent<CanvasGroup>().alpha=0;
			resultPanelMain.GetComponent<CanvasGroup>().interactable=false;
			resultPanelMain.GetComponent<CanvasGroup>().blocksRaycasts=false;


			gameOverPanel.GetComponent<CanvasGroup>().alpha=1.0f;
			gameOverPanel.GetComponent<CanvasGroup>().interactable=true;
			gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;


		});



	}

	void Update () {
	
	}

	void PointGenerator()
	{
		for(int i=0;i<SpriteChange.roundTournamentResultList.Count;i++)
		{
			int homeScore=int.Parse(SpriteChange.roundTournamentResultList.ElementAt(i).GetHomeScore());
			int awayScore = int.Parse(SpriteChange.roundTournamentResultList.ElementAt(i).GetAwayScore());
			if(homeScore>awayScore)
			{
				for(int j=0;j<League.fixedCountryForFixureArray.Length;j++)
				{
					if(SpriteChange.roundTournamentResultList.ElementAt(i).GetHomeName()==League.fixedCountryForFixureArray[j].getCountryName())
					{
						League.fixedCountryForFixureArray[j].SetPoint(3);
						print (League.fixedCountryForFixureArray[j].GetPoints());
					}

					else if(SpriteChange.roundTournamentResultList.ElementAt(i).GetAwayName()==League.fixedCountryForFixureArray[j].getCountryName())
					{
						League.fixedCountryForFixureArray[j].SetPoint(0);
					}
				}
			}

			else if(awayScore>homeScore)
			{
				for(int j=0;j<League.fixedCountryForFixureArray.Length;j++)
				{
					if(SpriteChange.roundTournamentResultList.ElementAt(i).GetHomeName()==League.fixedCountryForFixureArray[j].getCountryName())
					{
						League.fixedCountryForFixureArray[j].SetPoint(0);
					}
					
					else if(SpriteChange.roundTournamentResultList.ElementAt(i).GetAwayName()==League.fixedCountryForFixureArray[j].getCountryName())
					{
						League.fixedCountryForFixureArray[j].SetPoint(3);
					}
				}
			}
			else if(homeScore==awayScore)
			{
				for(int j=0;j<League.fixedCountryForFixureArray.Length;j++)
				{
					if(SpriteChange.roundTournamentResultList.ElementAt(i).GetHomeName()==League.fixedCountryForFixureArray[j].getCountryName())
					{
						League.fixedCountryForFixureArray[j].SetPoint(1);
					}
					
					else if(SpriteChange.roundTournamentResultList.ElementAt(i).GetAwayName()==League.fixedCountryForFixureArray[j].getCountryName())
					{
						League.fixedCountryForFixureArray[j].SetPoint(1);
					}
				}
			}

		}


	}

	void ShowPointOfTeams()
	{
		League.fixedCountryForFixureArray= League.fixedCountryForFixureArray.OrderByDescending(Country=>Country.GetPoints()).ToArray();

		if(pointTableGenerator)
		{
		for(int i=0;i<League.fixedCountryForFixureArray.Length;i++)
		{
			GameObject pointTablePrefabObject= Instantiate(pointTablePrefab)as GameObject;
			pointTablePrefabObject.transform.SetParent (GameObject.Find ("PointTableParent").transform, false);
			pointTablePrefabObject.transform.GetChild(0).GetComponent<Text>().text =(i+1).ToString();
			pointTablePrefabObject.transform.GetChild(1).GetComponent<Text>().text =League.fixedCountryForFixureArray[i].getCountryName();
			pointTablePrefabObject.transform.GetChild(2).GetComponent<Image>().sprite =League.fixedCountryForFixureArray[i].getCountryImage();
			pointTablePrefabObject.transform.GetChild(3).GetComponent<Text>().text =League.fixedCountryForFixureArray[i].GetPoints().ToString();

		}
			pointTableGenerator=false;
		}
	}

	void showPositionOfPLayer()
	{
		League.fixedCountryForFixureArray= League.fixedCountryForFixureArray.OrderByDescending(Country=>Country.GetPoints()).ToArray();
		playerPositionPanel.GetComponent<CanvasGroup>().alpha=1.0f;
		playerPositionPanel.GetComponent<CanvasGroup>().interactable=true;
		playerPositionPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;


		for(int i=0;i<League.fixedCountryForFixureArray.Length;i++)
		{
			if(CountrySelect.selectedCountry.getCountryName()==League.fixedCountryForFixureArray[i].getCountryName())
			{
				if(i==0)
				{
					playerPositionPanel.transform.GetChild(0).GetComponent<Text>().text="Congratulations!!!!  You Have Won The league";
				}
				else if(i==1)
				{
					playerPositionPanel.transform.GetChild(0).GetComponent<Text>().text="Good Job! You are Runners Up";
				}
				else if(i==2)
				{
					playerPositionPanel.transform.GetChild(0).GetComponent<Text>().text="You Have Finished "+(i+1).ToString()+"rd in the League";
				}
				else 
				{
					playerPositionPanel.transform.GetChild(0).GetComponent<Text>().text="You Have Finished "+(i+1).ToString()+"th in the League";
				}

				break;
			}
		

			}




		}


}
