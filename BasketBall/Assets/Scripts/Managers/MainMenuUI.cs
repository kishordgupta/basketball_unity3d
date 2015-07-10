using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {



	//	added later
	
	public Button SinglePlayerMode;
	public Button MultiPlayerMode;
	public Button Shop;
	
	public Button BackToMainMenu;
	public Button BackShop; 
	public Button CreateServer;
	public Button ConnectServer;

	public GameObject SinglePlayerPanel;
	public GameObject PurchasePanel;
	public GameObject MultiPlayerPanel;
	public GameObject SearchDevicePanel;


	//	till here


public Button ArcadeModeButton;
public GameObject bgPanel;
public Button ClassicButton;
public Button ChampionShipButton;
public Button TournamentButton;
public Button InstructionButton;
public Button SettingsButton;


public GameObject countryListPanel;
public GameObject arcadeModePanel;
public GameObject instructionPanel;

public Button backMenuInstruction;
public Button backClassicButton;


public Button backSettingToMenu;


public GameObject countrySelectPanel;
public GameObject settingsPanel;

public GameObject fixturePanel;
	
	void Start () {
		
		TournamentButton.onClick.AddListener (() => {


						
								
								SinglePlayerPanel.GetComponent<CanvasGroup> ().alpha = 0f;
								SinglePlayerPanel.GetComponent<CanvasGroup> ().interactable = false;
								SinglePlayerPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;


								fixturePanel.GetComponent<CanvasGroup> ().alpha = 1f;
								fixturePanel.GetComponent<CanvasGroup> ().interactable = true;
								fixturePanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;





								countrySelectPanel.GetComponent<CanvasGroup> ().alpha = 1f;
								countrySelectPanel.GetComponent<CanvasGroup> ().interactable = true;
								countrySelectPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

								PlayerPrefs.SetInt("modeName",3);



						


				});

		ArcadeModeButton.onClick.AddListener (() => {
			
			


				SinglePlayerPanel.GetComponent<CanvasGroup> ().alpha = 0f;
				SinglePlayerPanel.GetComponent<CanvasGroup> ().interactable = false;
				SinglePlayerPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				
				



				countrySelectPanel.GetComponent<CanvasGroup> ().alpha = 1f;
				countrySelectPanel.GetComponent<CanvasGroup> ().interactable = true;
				countrySelectPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

				fixturePanel.GetComponent<CanvasGroup> ().alpha = 1f;
				fixturePanel.GetComponent<CanvasGroup> ().interactable = true;
				fixturePanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				

				PlayerPrefs.SetInt("modeName",0);
				
			 
			
			
		});


		ChampionShipButton.onClick.AddListener (() => {
			
			PlayerPrefs.SetInt("modeName",2);


			SinglePlayerPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			SinglePlayerPanel.GetComponent<CanvasGroup> ().interactable = false;
			SinglePlayerPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			
			
			
			
			
			countrySelectPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			countrySelectPanel.GetComponent<CanvasGroup> ().interactable = true;
			countrySelectPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			
			fixturePanel.GetComponent<CanvasGroup> ().alpha = 1f;
			fixturePanel.GetComponent<CanvasGroup> ().interactable = true;
			fixturePanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				
			
		});

		backMenuInstruction.onClick.AddListener(()=>{
			bgPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			bgPanel.GetComponent<CanvasGroup> ().interactable = true;
			bgPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

			instructionPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			instructionPanel.GetComponent<CanvasGroup> ().interactable = false;
			instructionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		});

		InstructionButton.onClick.AddListener(()=>{
			bgPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			bgPanel.GetComponent<CanvasGroup> ().interactable = false;
			bgPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			
			instructionPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			instructionPanel.GetComponent<CanvasGroup> ().interactable = true;
			instructionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		});

		MultiPlayerMode.onClick.AddListener(()=>{
			bgPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			bgPanel.GetComponent<CanvasGroup> ().interactable = false;
			bgPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			
			MultiPlayerPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			MultiPlayerPanel.GetComponent<CanvasGroup> ().interactable = true;
			MultiPlayerPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		});

		ClassicButton.onClick.AddListener (() => {
			
			PlayerPrefs.SetInt("modeName",1);
			
			
			SinglePlayerPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			SinglePlayerPanel.GetComponent<CanvasGroup> ().interactable = false;
			SinglePlayerPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			
			countrySelectPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			countrySelectPanel.GetComponent<CanvasGroup> ().interactable = true;
			countrySelectPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			
			fixturePanel.GetComponent<CanvasGroup> ().alpha = 1f;
			fixturePanel.GetComponent<CanvasGroup> ().interactable = true;
			fixturePanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			
			
		});

		SettingsButton.onClick.AddListener (() => {
			
			PlayerPrefs.SetInt("modeName",5);
			
			
			bgPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			bgPanel.GetComponent<CanvasGroup> ().interactable = false;
			bgPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			
			settingsPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			settingsPanel.GetComponent<CanvasGroup> ().interactable = true;
			settingsPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			
			
		});

		backSettingToMenu.onClick.AddListener(()=>{
			bgPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			bgPanel.GetComponent<CanvasGroup> ().interactable = true;
			bgPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			
			settingsPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			settingsPanel.GetComponent<CanvasGroup> ().interactable = false;
			settingsPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		});

		SinglePlayerMode.onClick.AddListener (() => {
			

			
			bgPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			bgPanel.GetComponent<CanvasGroup> ().interactable = false;
			bgPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			
			
			SinglePlayerPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			SinglePlayerPanel.GetComponent<CanvasGroup> ().interactable = true;
			SinglePlayerPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			
			
		});

		BackToMainMenu.onClick.AddListener(()=>{
			bgPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			bgPanel.GetComponent<CanvasGroup> ().interactable = true;
			bgPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			
			SinglePlayerPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			SinglePlayerPanel.GetComponent<CanvasGroup> ().interactable = false;
			SinglePlayerPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		});

		BackShop.onClick.AddListener(()=>{
			bgPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			bgPanel.GetComponent<CanvasGroup> ().interactable = true;
			bgPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			
			PurchasePanel.GetComponent<CanvasGroup> ().alpha = 0f;
			PurchasePanel.GetComponent<CanvasGroup> ().interactable = false;
			PurchasePanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		});

		Shop.onClick.AddListener (()=>{
			bgPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			bgPanel.GetComponent<CanvasGroup> ().interactable = false;
			bgPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			
			PurchasePanel.GetComponent<CanvasGroup> ().alpha = 1f;
			PurchasePanel.GetComponent<CanvasGroup> ().interactable = true;
			PurchasePanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		});


		ConnectServer.onClick.AddListener (()=>{
			MultiPlayerPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			MultiPlayerPanel.GetComponent<CanvasGroup> ().interactable = false;
			MultiPlayerPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			
			SearchDevicePanel.GetComponent<CanvasGroup> ().alpha = 1f;
			SearchDevicePanel.GetComponent<CanvasGroup> ().interactable = true;
			SearchDevicePanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		});




	
	}
	
	
	void Update () {
	
	}
}
