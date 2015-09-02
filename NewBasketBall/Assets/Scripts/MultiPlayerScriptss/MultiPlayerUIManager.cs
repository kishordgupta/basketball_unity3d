using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MultiPlayerUIManager : MonoBehaviour
{

//	public GameObject GameOverMultiPanel;  :: moved to timerAttached Class..


	public Button PlayAgain;
	public Button MenuThere;
//	public Text ServerSideResult;
//	public Text ClientSideResult;


	// Use this for initialization
	void Start ()
	{
	
		PlayAgain.onClick.AddListener (() => {

//			GameOverMultiPanel.GetComponent<CanvasGroup> ().alpha = 0f;
//			GameOverMultiPanel.GetComponent<CanvasGroup> ().interactable = false;
//			GameOverMultiPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			Application.LoadLevel (3);
			
			
		});

		MenuThere.onClick.AddListener (() => {
			
			
			
			
//			GameOverMultiPanel.GetComponent<CanvasGroup> ().alpha = 0f;
//			GameOverMultiPanel.GetComponent<CanvasGroup> ().interactable = false;
//			GameOverMultiPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
//			
			BluetoothMultiplayerAndroid.StopDiscovery();
			BluetoothMultiplayerAndroid.Disconnect();
			Application.LoadLevel (0);
			
			
		});
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (MultiPlayerTimer.Over) {
//		
//
//		
//		}
//		MultiPlayerResult ();
	}

//	public void MultiPlayerResult ()
//	{
//
//		if (TimerAttached.TotalTime < 0) {
//
//			if (Network.isServer) {
//
//				ServerSideResult.GetComponent<CanvasGroup> ().alpha = 1f;
//				ServerSideResult.GetComponent<CanvasGroup> ().interactable = true;
//				ServerSideResult.GetComponent<CanvasGroup> ().blocksRaycasts = true;
//
//				if (PlayerGoalCount.ServerCountFor > TemporaryGoalCount.ServerScoreOppo) {
//
//					ServerSideResult = gameObject.GetComponent<Text> (); 
//					ServerSideResult.text = "You Have Won!";
//				} else if (PlayerGoalCount.ServerCountFor == TemporaryGoalCount.ServerScoreOppo) {
//					ServerSideResult = gameObject.GetComponent<Text> (); 
//					ServerSideResult.text = "Mtach Draw!";
//				} else if (PlayerGoalCount.ServerCountFor < TemporaryGoalCount.ServerScoreOppo) {
//					ServerSideResult = gameObject.GetComponent<Text> (); 
//					ServerSideResult.text = "You Have Lost";
//				}
//
//
//			}
//
//			if (Network.isClient) {
//				
//				ServerSideResult.GetComponent<CanvasGroup> ().alpha = 1f;
//				ServerSideResult.GetComponent<CanvasGroup> ().interactable = true;
//				ServerSideResult.GetComponent<CanvasGroup> ().blocksRaycasts = true;
//
//				if (PlayerGoalCount.ClientCountFor > TemporaryGoalCount.ClientScoreOppo) {
//					
//					ServerSideResult = gameObject.GetComponent<Text> (); 
//					ServerSideResult.text = "You Have Lost!";
//				} else if (PlayerGoalCount.ClientCountFor == TemporaryGoalCount.ClientScoreOppo) {
//					ServerSideResult = gameObject.GetComponent<Text> (); 
//					ServerSideResult.text = "Mtach Draw!";
//				} else if (PlayerGoalCount.ClientCountFor < TemporaryGoalCount.ClientScoreOppo) {
//					ServerSideResult = gameObject.GetComponent<Text> (); 
//					ServerSideResult.text = "You Have Won!";
//				}
//			}
//		}
//	}

}
