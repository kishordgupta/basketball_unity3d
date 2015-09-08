using UnityEngine;
using System.Collections;

public class OpponentHand : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start ()
	{
//		iTween.RotateTo (this.gameObject, iTween.Hash ("z", -180, "time", 2f, "oncomplete", "RotateBack"));
//		AttackBall();
	}

	public void AttackBall()
	{
		iTween.RotateTo (this.gameObject, iTween.Hash ("z", -180, "time", 0.5f, "oncomplete", "RotateBack"));
	}

	public void RotateBack ()
	{
		iTween.RotateTo (this.gameObject, iTween.Hash ("z", -1, "time", 1f));
	}


	void Update ()
	{

		
	}
}
