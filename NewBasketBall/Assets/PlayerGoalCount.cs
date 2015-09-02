using UnityEngine;
using System.Collections;

public class PlayerGoalCount : MonoBehaviour
{

	public static int ServerCountFor;
	public static int ClientCountFor;

	// Use this for initialization
	void Start ()
	{
		ServerCountFor = 0;
		ClientCountFor = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.gameObject.tag == "Ball") {
			
			if (Network.isServer) {		
				ServerCountFor++;
			}
			if (!Network.isServer) {
				ClientCountFor++;
			}
		}
	}
}