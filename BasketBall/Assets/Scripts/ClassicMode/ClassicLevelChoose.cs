using UnityEngine;
using System.Collections;

public class ClassicLevelChoose : MonoBehaviour {

	public GameObject[] levelClassic;
	public int levelIndex;



	void Start () {
		SelectLevel ();
	}
	

	void Update () {
	

		}

	void SelectLevel()
	{
		levelIndex=PlayerPrefs.GetInt("levelNumber");
		switch (levelIndex) {
		
		case 0:
		
			Instantiate(levelClassic[levelIndex]);
			break;
		case 1:
			Instantiate(levelClassic[levelIndex]);
			break;
		case 2:
			Instantiate(levelClassic[levelIndex]);
			break;
		case 3:
			Instantiate(levelClassic[levelIndex]);
			break;
		case 4:
			
			Instantiate(levelClassic[levelIndex]);
			break;
		case 5:
			Instantiate(levelClassic[levelIndex]);
			break;
		case 6:
			Instantiate(levelClassic[levelIndex]);
			break;
		case 7:
			Instantiate(levelClassic[levelIndex]);
			break;

		case 8:
			
			Instantiate(levelClassic[levelIndex]);
			break;
		case 9:
			Instantiate(levelClassic[levelIndex]);
			break;
		case 10:
			Instantiate(levelClassic[levelIndex]);
			break;
		case 11:
			Instantiate(levelClassic[levelIndex]);
			break;
		default:
			break;

		
		}

	}
	}


