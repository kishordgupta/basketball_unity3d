using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class NetworkMessage : MonoBehaviour {

	public Button BackToMenu;
	public GameObject MessageBoxPanel;
	// Use this for initialization
	void Start () {

		MessageBoxPanel.GetComponent<CanvasGroup> ().alpha = 0f;
		MessageBoxPanel.GetComponent<CanvasGroup> ().interactable = false;
		MessageBoxPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		BackToMenu.onClick.AddListener(()=>{

			Application.LoadLevel(0);
		});
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Time.timeScale == 1){
		if (Network.peerType == NetworkPeerType.Disconnected) {

			MessageBoxPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			MessageBoxPanel.GetComponent<CanvasGroup> ().interactable = true;
			MessageBoxPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		
			gameObject.GetComponent<Text> ().text = "Connection is currently unavailable. Please tab the button below to return to main menu and restart again";
		} else {
		
			MessageBoxPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			MessageBoxPanel.GetComponent<CanvasGroup> ().interactable = false;
			MessageBoxPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}
}
}
