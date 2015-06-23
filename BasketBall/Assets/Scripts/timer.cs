using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public static float timeR;
	public static string st;
	public static int tmr;
	public CanvasGroup game;
	public Button showResultButton;
	public Button pointTableButton;
	public Button tryAgainButton;
	public Button nextRoundTournamentButton;

	public GameObject championshipGameOverPanel;


	public bool boolTimer;



	void Start () {
		timeR=60.0f;
		Time.timeScale=1.0f;


		boolTimer=true;
	


	}
	

	void Update () {
		timeR -= Time.deltaTime;
		tmr = (int)timeR;
		st = tmr.ToString ();
				
		if (tmr < 0 && boolTimer) {
			gameObject.GetComponent<Text> ().text = "Time's up!";
			Time.timeScale = 0;
			switch(PlayerPrefs.GetInt("modeName"))
			{
			case 0:
				SetArcadePanel();
				break;
			case 1:
				SetClassicPanel();
				break;
			case 2:
				SetChampionshipPanel();
				break;
			case 3:
				SetTournamentPanel();
				break;
			default:
				break;
			}
			boolTimer = false;

				} 
		else if(boolTimer) 
		{
						
			gameObject.GetComponent<Text> ().text = st;
			game.alpha = 0;
			game.interactable = false;
			game.blocksRaycasts = false;
		
				}
		}



	 


	void SetArcadePanel()
	{

		game.alpha = 1;
		game.interactable = true;
		game.blocksRaycasts = true;
		tryAgainButton.GetComponent<CanvasGroup>().alpha=1.0f;
		tryAgainButton.GetComponent<CanvasGroup>().interactable=true;
		tryAgainButton.GetComponent<CanvasGroup>().blocksRaycasts=true;

		nextRoundTournamentButton.GetComponent<CanvasGroup>().alpha=0.0f;
		nextRoundTournamentButton.GetComponent<CanvasGroup>().interactable=false;
		nextRoundTournamentButton.GetComponent<CanvasGroup>().blocksRaycasts=false;

		showResultButton.GetComponent<CanvasGroup>().alpha=0.0f;
		showResultButton.GetComponent<CanvasGroup>().interactable=false;
		showResultButton.GetComponent<CanvasGroup>().blocksRaycasts=false;

		pointTableButton.GetComponent<CanvasGroup>().alpha=0.0f;
		pointTableButton.GetComponent<CanvasGroup>().interactable=false;
		pointTableButton.GetComponent<CanvasGroup>().blocksRaycasts=false;

	}

	void SetTournamentPanel()
	{

		game.alpha = 1;
		game.interactable = true;
		game.blocksRaycasts = true;
		tryAgainButton.GetComponent<CanvasGroup>().alpha=0.0f;
		tryAgainButton.GetComponent<CanvasGroup>().interactable=false;
		tryAgainButton.GetComponent<CanvasGroup>().blocksRaycasts=false;

		nextRoundTournamentButton.GetComponent<CanvasGroup>().alpha=1.0f;
		nextRoundTournamentButton.GetComponent<CanvasGroup>().interactable=true;
		nextRoundTournamentButton.GetComponent<CanvasGroup>().blocksRaycasts=true;
		
		showResultButton.GetComponent<CanvasGroup>().alpha=1.0f;
		showResultButton.GetComponent<CanvasGroup>().interactable=true;
		showResultButton.GetComponent<CanvasGroup>().blocksRaycasts=true;
		
		pointTableButton.GetComponent<CanvasGroup>().alpha=1.0f;
		pointTableButton.GetComponent<CanvasGroup>().interactable=true;
		pointTableButton.GetComponent<CanvasGroup>().blocksRaycasts=true;
	}

	void SetClassicPanel()
	{
		game.alpha = 1;
		game.interactable = true;
		game.blocksRaycasts = true;
		tryAgainButton.GetComponent<CanvasGroup>().alpha=1.0f;
		tryAgainButton.GetComponent<CanvasGroup>().interactable=true;
		tryAgainButton.GetComponent<CanvasGroup>().blocksRaycasts=true;
		
		nextRoundTournamentButton.GetComponent<CanvasGroup>().alpha=0.0f;
		nextRoundTournamentButton.GetComponent<CanvasGroup>().interactable=false;
		nextRoundTournamentButton.GetComponent<CanvasGroup>().blocksRaycasts=false;
		
		showResultButton.GetComponent<CanvasGroup>().alpha=0.0f;
		showResultButton.GetComponent<CanvasGroup>().interactable=false;
		showResultButton.GetComponent<CanvasGroup>().blocksRaycasts=false;
		
		pointTableButton.GetComponent<CanvasGroup>().alpha=0.0f;
		pointTableButton.GetComponent<CanvasGroup>().interactable=false;
		pointTableButton.GetComponent<CanvasGroup>().blocksRaycasts=false;
	}

	void SetChampionshipPanel()
	{
		championshipGameOverPanel.GetComponent<CanvasGroup>().alpha=1.0f;
		championshipGameOverPanel.GetComponent<CanvasGroup>().interactable=true;
		championshipGameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;
	}


}
