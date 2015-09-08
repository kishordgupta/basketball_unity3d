using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TempGoal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Network.isServer) {
			gameObject.GetComponent<Text> ().text = " " + TemporaryGoalCount.ServerScoreOppo + " ";
		}

		if (!Network.isServer) {
			gameObject.GetComponent<Text> ().text = " " + TemporaryGoalCount.ClientScoreOppo + " ";
		}
	}
}
