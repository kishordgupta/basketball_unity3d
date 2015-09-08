using UnityEngine;
using System.Collections;

public class TemporaryGoalCount : MonoBehaviour {


	public static int ServerScoreOppo;
	public static int ClientScoreOppo;

	// Use this for initialization
	void Start () {
		ServerScoreOppo = 0;
		ClientScoreOppo = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		
		if (other.gameObject.tag == "Ball") {
			
			if(Network.isServer){
			ServerScoreOppo++;
			}

			if(!Network.isServer){
				ClientScoreOppo++;
			}
		}
	}
}
