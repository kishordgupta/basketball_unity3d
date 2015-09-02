using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla;








/// <summary>
/// This script is not used...........
/// </summary>





namespace Soomla.Store.Example{

public class MultiPlayerTimer : MonoBehaviour
{

	public static float timerMultiPlayer;
	public static string timeString;
	public static int tmrMultiPlayer;
	public Text ShowTime;
	public static bool Over;
	// Use this for initialization
	void Start ()
	{
		timerMultiPlayer = 60.0f;

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (NetworkManagerScript.connectivityServer && NetworkManagerScript.connectivityClient) {

			Over = false;

			timerMultiPlayer -= Time.deltaTime;
			tmrMultiPlayer = (int)timerMultiPlayer;
			timeString = tmrMultiPlayer.ToString ();

			Time.timeScale = 1;

			DisplayTime();
//			if (networkView.isMine) {
//				DisplayTime ();
//
//			}
		}



		

	}
	
	public void DisplayTime ()
	{
		
		if (tmrMultiPlayer < 0) {


			ShowTime.GetComponent<Text> ().text = "Time's up!";
			Time.timeScale = 0;
			NetworkManagerScript.clientReady = false;
			NetworkManagerScript.serverReady = false;
			Over = true;
		} else {
			
			ShowTime.GetComponent<Text> ().text = timeString;
		}
	}
}
}
