using UnityEngine;
using System.Collections;

public class AnimObj2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}

	IEnumerator AnimWait()
	{
		yield return new WaitForSeconds (5f);
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivatingAnim()
	{
		gameObject.SetActive (true);
		StartCoroutine (AnimWait ());
		//		gameObject.SetActive (false);
	}
}
