using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ClassicModeMain : MonoBehaviour {

	public GameObject classicGridPanel;
	public int levelLocked;


		public void getButtonForLevel(Button levelButton)
		{


			switch(levelButton.transform.GetChild(0).GetComponent<Text>().text)
			{

			case "Level 1":
				PlayerPrefs.SetInt("levelNumber",0);
							Application.LoadLevel(2);
				break;
			case "Level 2":
				PlayerPrefs.SetInt("levelNumber",1);
				Application.LoadLevel(2);
				break;
			case "Level 3":
				PlayerPrefs.SetInt("levelNumber",2);
				Application.LoadLevel(2);
				break;
			case "Level 4":
				PlayerPrefs.SetInt("levelNumber",3);
				Application.LoadLevel(2);
				break;
			case "Level 5":
				PlayerPrefs.SetInt("levelNumber",4);
				Application.LoadLevel(2);
				break;
			case "Level 6":
				PlayerPrefs.SetInt("levelNumber",5);
				Application.LoadLevel(2);
				break;
			case "Level 7":
				PlayerPrefs.SetInt("levelNumber",6);
				Application.LoadLevel(2);
				break;
			case "Level 8":
				PlayerPrefs.SetInt("levelNumber",7);
				Application.LoadLevel(2);
				break;
			case "Level 9":
				PlayerPrefs.SetInt("levelNumber",8);
				Application.LoadLevel(2);
				break;
			case "Level 10":
				PlayerPrefs.SetInt("levelNumber",9);
				Application.LoadLevel(2);
				break;
			case "Level 11":
				PlayerPrefs.SetInt("levelNumber",10);
				Application.LoadLevel(2);
				break;
			case "Level 12":
				PlayerPrefs.SetInt("levelNumber",11);
				Application.LoadLevel(2);
				break;
			default:
				break;

			}
		}
	void Start () {

		if(PlayerPrefs.GetInt("levelLockPrevious")==null)
		{
			levelLocked=1;
		}
		levelLocked= PlayerPrefs.GetInt("levelLockPrevious");
		PlayerPrefs.SetInt("numberNewLevel",levelLocked+1);

		for(int i=1;i<PlayerPrefs.GetInt("numberNewLevel");i++)
		{
			classicGridPanel.transform.GetChild(i).GetComponent<CanvasGroup>().alpha=1f;
			classicGridPanel.transform.GetChild(i).GetComponent<CanvasGroup>().interactable=true;
			classicGridPanel.transform.GetChild(i).GetComponent<CanvasGroup>().blocksRaycasts=true;

			classicGridPanel.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().color= new Color(1,1,1,1);

		}

	}
	

	void Update () {
	
	}
}
