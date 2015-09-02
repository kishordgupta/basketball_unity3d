using UnityEngine;
using System.Collections;

public class Opponent : MonoBehaviour {
	public static Vector2 opponentPosition;
	// Use this for initialization
	void Start () {
	
			opponentPosition = new Vector2 (5f, -1.8f);
		gameObject.transform.position = opponentPosition;
		print ("opp here");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
