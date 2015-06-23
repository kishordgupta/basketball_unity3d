using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Arcade : MonoBehaviour {

	public Sprite[] countryFlag;
	public Sprite[] faceForCountry;
	private Country[] countryArcadeArray;
	public GameObject arcadeParentPanel;
	public Country selectedCountry;
	public Button playButton;

	public Button goButtonArcade;



	void Start () {
	
//		countryArcadeArray= new Country[19];
//		for(int i=0;i<countryArcadeArray.Length;i++)
//		{
//			countryArcadeArray[i]= new Country(countryFlag[i],Constants.countryName[i],i,faceForCountry[i]);
//
//		}

//		for(int i=0;i<countryArcadeArray.Length;i++)
//		{
//			arcadeParentPanel.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite=countryArcadeArray[i].getCountryImage();
//
//			arcadeParentPanel.transform.GetChild(i).transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text=countryArcadeArray[i].getCountryName();
//			arcadeParentPanel.transform.GetChild(i).transform.GetChild(2).GetComponent<Image>().sprite=countryArcadeArray[i].getFaceForCountry();
//		}

//		playButton.onClick.AddListener(()=>{
//
//			Application.LoadLevel(1);
//		});


//		goButtonArcade.onClick.AddListener(()=>{
//
//			Application.LoadLevel(1);
//
//		});


	}

//	public void SelectCountryFromButton(Button selectedButton)
//	{
//
//		for (int i=0; i<countryArcadeArray.Length; i++) {
//			
//			if(selectedButton.transform.GetChild(0).GetComponent<Text>().text==countryArcadeArray[i].getCountryName())
//			{
//				selectedCountry= countryArcadeArray[i];
//				print(selectedCountry.GetCountryTag());
//			}
//		}
//
//		PlayerPrefs.SetString("playerCountry",selectedCountry.getCountryName());
//
//	}


	void Update () {
	
	}


}
