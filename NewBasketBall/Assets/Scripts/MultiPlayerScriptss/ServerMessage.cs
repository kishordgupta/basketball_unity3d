using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ServerMessage : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Network.isServer) {
			if (PlayerGoalCount.ServerCountFor > TemporaryGoalCount.ServerScoreOppo) {
			
				gameObject.GetComponent<Text> ().text = "You Have Won";

			} else if (PlayerGoalCount.ServerCountFor == TemporaryGoalCount.ServerScoreOppo) {

				gameObject.GetComponent<Text> ().text = "Match is draw";

			} else if (PlayerGoalCount.ServerCountFor < TemporaryGoalCount.ServerScoreOppo) {

				gameObject.GetComponent<Text> ().text = "You Have Lost";

			}
		}

		if (!Network.isServer) {
			if (PlayerGoalCount.ClientCountFor > TemporaryGoalCount.ClientScoreOppo) {
				
				gameObject.GetComponent<Text> ().text = "You Have Lost";
				
			} else if (PlayerGoalCount.ClientCountFor == TemporaryGoalCount.ClientScoreOppo) {
				
				gameObject.GetComponent<Text> ().text = "Match is Draw";
				
			} else if (PlayerGoalCount.ClientCountFor < TemporaryGoalCount.ClientScoreOppo) {
				
				gameObject.GetComponent<Text> ().text = "You have Won";
				
			}
		}
	}
}
