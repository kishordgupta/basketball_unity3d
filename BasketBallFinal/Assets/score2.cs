using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla;

namespace Soomla.Store.Example{
public class score2 : MonoBehaviour {


	// Use this for initialization
	void Start () {
			Ball.str2 = "0";
		gameObject.GetComponent<Text>().text=	Ball.str2;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text=	Ball.str2;
	
	}

}

}