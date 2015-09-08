using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ChampionshipMain : MonoBehaviour {

	public GameObject selectCountryParentPanel;
	public GameObject mainPanel;

	public GameObject fixureShowPanel;
	public GameObject showFixurePrefab;
	public GameObject scrollParentPanelShow;



	public Text roundNameText;

	public Button goButtonFromConfirmPanel;
	public Button playFromChampionship;

	public static Country selectedCountry;
	public static List<Country> championshipCountryList= new List<Country>();
	public static List<TournamentResult> championshipTournamentList = new List<TournamentResult>();





	void Start () {
	

		playFromChampionship.onClick.AddListener(()=>{


								if(PlayerPrefs.GetInt("modeName")==2){
												
											Application.LoadLevel(1);
														}
		                                     });


		goButtonFromConfirmPanel.onClick.AddListener(()=>{
			if(PlayerPrefs.GetInt("modeName")==2)
			{
			scrollParentPanelShow.gameObject.GetComponent<CanvasGroup>().alpha=1.0f;
			scrollParentPanelShow.gameObject.GetComponent<CanvasGroup>().interactable=true;
			scrollParentPanelShow.gameObject.GetComponent<CanvasGroup>().blocksRaycasts=true;
			
			
			roundNameText.gameObject.GetComponent<CanvasGroup>().alpha=1.0f;
			roundNameText.gameObject.GetComponent<CanvasGroup>().interactable=true;
			roundNameText.gameObject.GetComponent<CanvasGroup>().blocksRaycasts=true;
			FixureForChampionship();
			print("Fixures");
		}

			else if(PlayerPrefs.GetInt("modeName")==3)
			{
				roundNameText.gameObject.GetComponent<CanvasGroup>().alpha=0.0f;
				roundNameText.gameObject.GetComponent<CanvasGroup>().interactable=false;
				roundNameText.gameObject.GetComponent<CanvasGroup>().blocksRaycasts=false;
			}
		});



	}

	void Update () {
	
	}

	void FixureForChampionship()
	{

		championshipCountryList.Add (CountrySelect.selectedCountry);
		
		print(championshipCountryList.ElementAt(0).getCountryName());
		
		int randomNumber = Random.Range(1,18);
		for(int i=1;i<16;)
		{
			Country inputForChampionshipList = CountrySelect.countryArray[randomNumber];
			randomNumber++;
			if(randomNumber>=19)
			{
				randomNumber=0;
			}
			if(CountrySelect.selectedCountry.GetCountryTag()!=inputForChampionshipList.GetCountryTag())
			{ 
				championshipCountryList.Add(inputForChampionshipList);
				i++;
			}
			else
			{
				print ("for test only in Championship class");
			}
		}
		
		for(int i=0,j=(championshipCountryList.Count-1);i<j;i++,j--)
		{
			TournamentResult championshipObject= new TournamentResult(championshipCountryList.ElementAt(i).getCountryName(),championshipCountryList.ElementAt(i).getCountryImage(),
			                                                          championshipCountryList.ElementAt(j).getCountryName(),championshipCountryList.ElementAt(j).getCountryImage(),
			                                                          championshipCountryList.ElementAt(i).getFaceForCountry(),championshipCountryList.ElementAt(j).getFaceForCountry());

			championshipTournamentList.Add(championshipObject);
		}


		for(int i=0;i<championshipTournamentList.Count;i++)
		{
			print(championshipTournamentList.ElementAt(i).GetHomeName()+"Vs"+championshipTournamentList.ElementAt(i).GetAwayName());

			GameObject fixureObject= Instantiate(showFixurePrefab)as GameObject;
			fixureObject.transform.SetParent (GameObject.Find ("ParentPanelPrefab").transform, false);
			
			fixureObject.transform.GetComponent<CanvasGroup>().alpha=1f;
			fixureObject.transform.GetComponent<CanvasGroup>().interactable=true;
			fixureObject.transform.GetComponent<CanvasGroup>().blocksRaycasts=true;
			
			
			fixureObject.transform.GetChild(0).GetComponent<Text>().text =championshipTournamentList.ElementAt(i).GetHomeName();
			fixureObject.transform.GetChild(3).GetComponent<Text>().text =championshipTournamentList.ElementAt(i).GetAwayName();
			fixureObject.transform.GetChild(2).GetComponent<Image>().sprite = championshipTournamentList.ElementAt(i).GetHomeImage();
			fixureObject.transform.GetChild(4).GetComponent<Image>().sprite = championshipTournamentList.ElementAt(i).GetAwayImage();

		}


	}
}
