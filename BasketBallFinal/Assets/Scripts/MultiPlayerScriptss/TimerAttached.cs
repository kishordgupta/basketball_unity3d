using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla;

namespace Soomla.Store.Example{
public class TimerAttached : MonoBehaviour {

	public GameObject GameOverMultiPanel;


//	public Text TimerOfMultiplayer;
	public static float TotalTime;



	// Use this for initialization
	void Start () {
		GameOverMultiPanel.GetComponent<CanvasGroup> ().alpha = 0f;
		GameOverMultiPanel.GetComponent<CanvasGroup> ().interactable = false;
		GameOverMultiPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		TotalTime = 60f;
	}
	
	// Update is called once per frame
	void Update () {

		if (NetworkManagerScript.connectivityServer || NetworkManagerScript.connectivityClient) {
	

			TotalTime -= Time.deltaTime;
			int TimeInteger = (int)TotalTime;

			if(TotalTime < 0){
				MultiPlayerGameOver();
				gameObject.GetComponent<Text> ().text = "Time's up!";
				Time.timeScale = 0;

			}
			else
				gameObject.GetComponent<Text> ().text = " " + TimeInteger + " ";
		
		}
	}

	public void MultiPlayerGameOver(){
		
		GameOverMultiPanel.GetComponent<CanvasGroup> ().alpha = 1f;
		GameOverMultiPanel.GetComponent<CanvasGroup> ().interactable = true;
		GameOverMultiPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		 
	}
}
}
