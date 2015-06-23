using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Back : MonoBehaviour {

	public Button pause;
	public Button play;
	public GameObject resumePanel;

	public GameObject resultParent;
	public GameObject pointParent;

	public int i;

	void Start () {
	
	}

	void Update () {
	
	}
	public void back()
	{

		if(PlayerPrefs.GetInt("modeName")==1&& Ball.playerScore>Ball.oppnentScore)
		{
			PlayerPrefs.SetInt("levelLockPrevious",PlayerPrefs.GetInt("numberNewLevel"));
		
		}

		League.fixedCountryForFixureArray=null;
		SpriteChange.roundTournamentResultList.Clear();
		League.tournamentResultList.Clear();
		CountrySelect.countryArray=null;
		ChampionshipMain.championshipCountryList.Clear();
		ChampionshipMain.championshipTournamentList.Clear();
		Time.timeScale=1.0f;
	
		Application.LoadLevel(0);




	}

	public void tryAgain()
	{
		Time.timeScale=1.0f;
		if(PlayerPrefs.GetInt("modeName")==1)
		{
			Application.LoadLevel(2);
		}
		else
		{
		Application.LoadLevel (1);
		}
	}

	public void pausing()
	{
		Time.timeScale = 0.0f;
		pause.GetComponent<CanvasGroup>().alpha=0.0f;
		pause.GetComponent<CanvasGroup>().interactable=false;
		pause.GetComponent<CanvasGroup>().blocksRaycasts=false;



		resumePanel.GetComponent<CanvasGroup>().alpha=1.0f;
		resumePanel.GetComponent<CanvasGroup>().interactable=true;
		resumePanel.GetComponent<CanvasGroup>().blocksRaycasts=true;

	}



	public void resuming()
	{
		Time.timeScale = 1.0f;
		pause.GetComponent<CanvasGroup>().alpha=1.0f;
		pause.GetComponent<CanvasGroup>().interactable=true;
		pause.GetComponent<CanvasGroup>().blocksRaycasts=true;
		

		resumePanel.GetComponent<CanvasGroup>().alpha=0.0f;
		resumePanel.GetComponent<CanvasGroup>().interactable=false;
		resumePanel.GetComponent<CanvasGroup>().blocksRaycasts=false;
	}

	public void BackToMainMenu()
	{
		League.fixedCountryForFixureArray=null;
		SpriteChange.roundTournamentResultList.Clear();
		League.tournamentResultList.Clear();
		CountrySelect.countryArray=null;
		//SpriteChange.roundTournamentResultList= new List<TournamentResult>();
		Application.LoadLevel(0);
	}

}
