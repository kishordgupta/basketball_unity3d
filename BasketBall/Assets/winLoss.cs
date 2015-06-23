using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class winLoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Ball.playerScore > Ball.oppnentScore)
			gameObject.GetComponent<Text> ().text = "You win!";
		else if(Ball.playerScore < Ball.oppnentScore)
			gameObject.GetComponent<Text> ().text = "You Lost!";
		else
			gameObject.GetComponent<Text> ().text = "The match is drawn";
	}
}
