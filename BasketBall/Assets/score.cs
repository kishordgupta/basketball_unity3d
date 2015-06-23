using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {




	void Start () {

		 gameObject.GetComponent<Text>().text=	Ball.str1;

		print ("Score : "+gameObject.GetComponent<Text>().text);
	}
	

	void Update () {
		gameObject.GetComponent<Text>().text=	Ball.str1;
		}

}	