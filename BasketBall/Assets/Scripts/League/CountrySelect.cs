using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountrySelect : MonoBehaviour {



	public static Country[] countryArray;
	public Sprite[] countrySprite;
	public Sprite[] faceSpiteArray;

	public static  Country selectedCountry;

	public GameObject confirmCountryPanel;
	public GameObject numberOfTeamsPanel;
	public GameObject fixurePanel;
	public GameObject mainMenuPanel;
	public GameObject showFixurePanelChampionship;
	public GameObject classicModemainPanel;
	public GameObject classicModeGridpanel;

	public GameObject panel;

	public Button goButton;
	public Button cancelButton;
	public Button nextButton;
	public Button cancelButtonNOTeams;
	public Button backToMainMenu;

	public Button backClassicButton;


	public Text numberOfTeamsText;

	public Slider numberOfTeamsSlider;

	public static int numberOfTeams;




	public void GetCountryNameAndImage(Button countryName)
	{
		gameObject.GetComponent<CanvasGroup>().alpha=0.0f;
		gameObject.GetComponent<CanvasGroup>().interactable=false;
		gameObject.GetComponent<CanvasGroup>().blocksRaycasts=false;

		confirmCountryPanel.GetComponent<CanvasGroup>().alpha=1.0f;
		confirmCountryPanel.GetComponent<CanvasGroup>().interactable=true;
		confirmCountryPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;

		fixurePanel.GetComponent<CanvasGroup>().alpha=0.0f;
		fixurePanel.GetComponent<CanvasGroup>().interactable=false;
		fixurePanel.GetComponent<CanvasGroup>().blocksRaycasts=false;


		for (int i=0; i<countryArray.Length; i++) {
			
			if(countryName.transform.GetChild(0).GetComponent<Text>().text==countryArray[i].getCountryName())
			{
				selectedCountry= countryArray[i];
				print (selectedCountry.getCountryName());

				confirmCountryPanel.gameObject.transform.GetChild(0).GetComponent<Image>().sprite=countryArray[i].getFaceForCountry();
				confirmCountryPanel.gameObject.transform.GetChild(3).GetComponent<Text>().text=countryArray[i].getCountryName();

			
				PlayerPrefs.SetString("playerCountry",countryArray[i].getCountryName());

				print (countryArray[i].getCountryName());
				
			}
		}


	}

	void Start () {


		countryArray= new Country[19];
		for(int i=0;i<19;i++)
		{
			countryArray[i]= new Country(countrySprite[i],Constants.countryName[i],i,faceSpiteArray[i]);

		}

		for(int i=0;i<countryArray.Length;i++)
		{
			gameObject.transform.GetChild(0).transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text=countryArray[i].getCountryName();
			gameObject.transform.GetChild(0).transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().sprite=countryArray[i].getCountryImage();
		}

		cancelButton.onClick.AddListener(()=>{

			gameObject.GetComponent<CanvasGroup>().alpha=1.0f;
			gameObject.GetComponent<CanvasGroup>().interactable=true;
			gameObject.GetComponent<CanvasGroup>().blocksRaycasts=true;
			
			confirmCountryPanel.GetComponent<CanvasGroup>().alpha=0.0f;
			confirmCountryPanel.GetComponent<CanvasGroup>().interactable=false;
			confirmCountryPanel.GetComponent<CanvasGroup>().blocksRaycasts=false;

			fixurePanel.GetComponent<CanvasGroup>().alpha=1.0f;
			fixurePanel.GetComponent<CanvasGroup>().interactable=true;
			fixurePanel.GetComponent<CanvasGroup>().blocksRaycasts=true;
			panel.GetComponent<CanvasGroup>().alpha=1.0f;
			panel.GetComponent<CanvasGroup>().interactable=true;
			panel.GetComponent<CanvasGroup>().blocksRaycasts=true;


			

		});

		goButton.onClick.AddListener(()=>{
			switch(PlayerPrefs.GetInt("modeName"))
			{
				case 0:
				SetArcadeMOdeParameter();
				break;
				case 1:
				SetClassicModeParameter();
				break;
				case 2:
				SetChampionshipParametre();
				break;
				case 3:
				SetTournamentParameter();
				break;
				default:
				break;


			}
		});

		nextButton.onClick.AddListener(()=>{

			numberOfTeamsPanel.GetComponent<CanvasGroup>().alpha=0.0f;
			numberOfTeamsPanel.GetComponent<CanvasGroup>().interactable=false;
			numberOfTeamsPanel.GetComponent<CanvasGroup>().blocksRaycasts=false;
		});

		cancelButtonNOTeams.onClick.AddListener(()=>{
			
			numberOfTeamsPanel.GetComponent<CanvasGroup>().alpha=0.0f;
			numberOfTeamsPanel.GetComponent<CanvasGroup>().interactable=false;
			numberOfTeamsPanel.GetComponent<CanvasGroup>().blocksRaycasts=false;

			confirmCountryPanel.GetComponent<CanvasGroup>().alpha=1.0f;
			confirmCountryPanel.GetComponent<CanvasGroup>().interactable=true;
			confirmCountryPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;
		});
	
		backToMainMenu.onClick.AddListener(()=>{
		                                   gameObject.GetComponent<CanvasGroup>().alpha=0.0f;
		                                   gameObject.GetComponent<CanvasGroup>().interactable=false;
		                                   gameObject.GetComponent<CanvasGroup>().blocksRaycasts=false;

			gameObject.GetComponent<CanvasGroup>().alpha=0.0f;
			gameObject.GetComponent<CanvasGroup>().interactable=false;
			gameObject.GetComponent<CanvasGroup>().blocksRaycasts=false;

			fixurePanel.GetComponent<CanvasGroup>().alpha=0.0f;
			fixurePanel.GetComponent<CanvasGroup>().interactable=false;
			fixurePanel.GetComponent<CanvasGroup>().blocksRaycasts=false;

			mainMenuPanel.GetComponent<CanvasGroup>().alpha=1.0f;
			mainMenuPanel.GetComponent<CanvasGroup>().interactable=true;
			mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;

		                                
		     });

		backClassicButton.onClick.AddListener(()=>{

			classicModemainPanel.GetComponent<CanvasGroup>().alpha=0.0f;
			classicModemainPanel.GetComponent<CanvasGroup>().interactable=false;
			classicModemainPanel.GetComponent<CanvasGroup>().blocksRaycasts=false;
			
			classicModeGridpanel.GetComponent<CanvasGroup>().alpha=0.0f;
			classicModeGridpanel.GetComponent<CanvasGroup>().interactable=false;
			classicModeGridpanel.GetComponent<CanvasGroup>().blocksRaycasts=false;

			confirmCountryPanel.GetComponent<CanvasGroup>().alpha=1.0f;
			confirmCountryPanel.GetComponent<CanvasGroup>().interactable=true;
			confirmCountryPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;

		});
	}
	

	void Update () {
	
		numberOfTeamsText.GetComponent<Text>().text= numberOfTeamsSlider.GetComponent<Slider>().value.ToString();
		numberOfTeams=int.Parse(numberOfTeamsSlider.GetComponent<Slider>().value.ToString());
	}

	void SetArcadeMOdeParameter()
	{
		print ("You are in Arcade");

		Application.LoadLevel(1);
	}

	void SetClassicModeParameter()
	{
		print("You are in Classic");

		classicModemainPanel.GetComponent<CanvasGroup>().alpha=1.0f;
		classicModemainPanel.GetComponent<CanvasGroup>().interactable=true;
		classicModemainPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;

		classicModeGridpanel.GetComponent<CanvasGroup>().alpha=1.0f;
		classicModeGridpanel.GetComponent<CanvasGroup>().interactable=true;
		classicModeGridpanel.GetComponent<CanvasGroup>().blocksRaycasts=true;

	
	}

	void SetChampionshipParametre()
	{
		print("You are in Championship");
		confirmCountryPanel.GetComponent<CanvasGroup>().alpha=0.0f;
		confirmCountryPanel.GetComponent<CanvasGroup>().interactable=false;
		confirmCountryPanel.GetComponent<CanvasGroup>().blocksRaycasts=false;

		showFixurePanelChampionship.GetComponent<CanvasGroup>().alpha=1.0f;
		showFixurePanelChampionship.GetComponent<CanvasGroup>().interactable=true;
		showFixurePanelChampionship.GetComponent<CanvasGroup>().blocksRaycasts=true;
	
	}

	void SetTournamentParameter()
	{

		print("You are in Tournament mode");
		confirmCountryPanel.GetComponent<CanvasGroup>().alpha=0.0f;
		confirmCountryPanel.GetComponent<CanvasGroup>().interactable=false;
		confirmCountryPanel.GetComponent<CanvasGroup>().blocksRaycasts=false;
		numberOfTeamsPanel.GetComponent<CanvasGroup>().alpha=1.0f;
		numberOfTeamsPanel.GetComponent<CanvasGroup>().interactable=true;
		numberOfTeamsPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;
		print(numberOfTeams);

	}
}
