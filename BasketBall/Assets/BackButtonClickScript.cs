using UnityEngine;
using System.Collections;

public class BackButtonClickScript : MonoBehaviour {

	// Use this for initialization
//	public void NextLevelButton(int index)
//	{
//		Application.LoadLevel(index);
//	}
	
	public void NextLevelButton()
	{
		Application.LoadLevel("newMainMenu");
	}
}
