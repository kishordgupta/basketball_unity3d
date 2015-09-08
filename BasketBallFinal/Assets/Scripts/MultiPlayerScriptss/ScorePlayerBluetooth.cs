using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePlayerBluetooth : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Network.isServer) {
			gameObject.GetComponent<Text> ().text = " " + PlayerGoalCount.ServerCountFor + " ";
		}

		if (!Network.isServer) {
			gameObject.GetComponent<Text> ().text = " " + PlayerGoalCount.ClientCountFor + " ";
		}
	}
}
