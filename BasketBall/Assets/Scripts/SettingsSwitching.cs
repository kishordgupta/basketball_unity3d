using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsSwitching : MonoBehaviour {

//	public bool sound;
//	public bool music;
	public Button sndOn;
	public Button sndOff;
	public Button mscOn;
	public Button mscOff;


	// Use this for initialization
	void Start () {
	

	}

	public void SoundOn()
	{
		sndOn.GetComponent<CanvasGroup>().alpha=0.0f;
		sndOn.GetComponent<CanvasGroup>().interactable=false;
		sndOn.GetComponent<CanvasGroup>().blocksRaycasts=false;

		sndOff.GetComponent<CanvasGroup>().alpha=1.0f;
		sndOff.GetComponent<CanvasGroup>().interactable=true;
		sndOff.GetComponent<CanvasGroup>().blocksRaycasts=true;

	
	}


	public void SoundOff()
	{
		sndOff.GetComponent<CanvasGroup>().alpha=0.0f;
		sndOff.GetComponent<CanvasGroup>().interactable=false;
		sndOff.GetComponent<CanvasGroup>().blocksRaycasts=false;
		
		sndOn.GetComponent<CanvasGroup>().alpha=1.0f;
		sndOn.GetComponent<CanvasGroup>().interactable=true;
		sndOn.GetComponent<CanvasGroup>().blocksRaycasts=true;
		
		
	}


	public void MusicOn()
	{
		mscOn.GetComponent<CanvasGroup>().alpha=0.0f;
		mscOn.GetComponent<CanvasGroup>().interactable=false;
		mscOn.GetComponent<CanvasGroup>().blocksRaycasts=false;
		
		mscOff.GetComponent<CanvasGroup>().alpha=1.0f;
		mscOff.GetComponent<CanvasGroup>().interactable=true;
		mscOff.GetComponent<CanvasGroup>().blocksRaycasts=true;
		
		
	}

	public void MusicOff()
	{
		mscOff.GetComponent<CanvasGroup>().alpha=0.0f;
		mscOff.GetComponent<CanvasGroup>().interactable=false;
		mscOff.GetComponent<CanvasGroup>().blocksRaycasts=false;
		
		mscOn.GetComponent<CanvasGroup>().alpha=1.0f;
		mscOn.GetComponent<CanvasGroup>().interactable=true;
		mscOn.GetComponent<CanvasGroup>().blocksRaycasts=true;
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
