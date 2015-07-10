using UnityEngine;
using System.Collections;

public class AnimationActive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator AnimWait()
	{
		yield return new WaitForSeconds (5f);
		gameObject.SetActive (false);
	}

	public void ActivatingAnim()
	{
		gameObject.SetActive (true);
		StartCoroutine (AnimWait ());
//		gameObject.SetActive (false);
	}
}
