using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla;

namespace Soomla.Store.Example{
public class score : MonoBehaviour {




	void Start () {

			Ball.playerScore = 0;
			Ball.oppnentScore = 0;
			Ball.str1 = "0";
			gameObject.GetComponent<Text>().text=	Ball.str1;

		
	}
	

	void Update () {
		gameObject.GetComponent<Text>().text=	Ball.str1;
		}

}
}