using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla;

namespace Soomla.Store.Example{

public class timer : MonoBehaviour {

	public static float timeR;
	public static string st;
	public static int tmr;
	public CanvasGroup game;
	public Button showResultButton;
	public Button pointTableButton;
	public Button tryAgainButton;
	public Button nextRoundTournamentButton;
	public static int playerPoint;
	public static string playerPointKey;

		public GameObject GameOverWinCoinEarnPanel;
		public GameObject GameOverLossCoinDeductionPanel;

	public GameObject championshipGameOverPanel;


	public bool boolTimer;



	void Start () {
		timeR=60.0f;
		Time.timeScale=1.0f;


		boolTimer=true;
	
		playerPoint = PlayerPrefs.GetInt (playerPointKey, 0);

			GameOverLossCoinDeductionPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			GameOverLossCoinDeductionPanel.GetComponent<CanvasGroup> ().interactable = false;
			GameOverLossCoinDeductionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			GameOverWinCoinEarnPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			GameOverWinCoinEarnPanel.GetComponent<CanvasGroup> ().interactable = false;
			GameOverWinCoinEarnPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

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
				if(Ball.playerScore > Ball.oppnentScore)
				{
					playerPoint +=3;
					GameOverWinCoinEarnPanel.GetComponent<CanvasGroup> ().alpha = 1f;
					GameOverWinCoinEarnPanel.GetComponent<CanvasGroup> ().interactable = true;
					GameOverWinCoinEarnPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				}
				else if(Ball.playerScore < Ball.oppnentScore)
				{
					playerPoint --;
					GameOverLossCoinDeductionPanel.GetComponent<CanvasGroup> ().alpha = 1f;
					GameOverLossCoinDeductionPanel.GetComponent<CanvasGroup> ().interactable = true;
					GameOverLossCoinDeductionPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

				}

				} 
		else if(boolTimer) 
		{
						
			gameObject.GetComponent<Text> ().text = st;
			game.alpha = 0;
			game.interactable = false;
			game.blocksRaycasts = false;
		
				}
		PlayerPrefs.SetInt (playerPointKey, playerPoint);
		PlayerPrefs.Save ();
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
}
