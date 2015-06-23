using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score2 : MonoBehaviour {


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text>().text=	Ball.str2;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text=	Ball.str2;
	
	}

}
