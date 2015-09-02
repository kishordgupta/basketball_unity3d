using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour {

	public Button SoundOn;
	public Button SoundOff;
	public Button MusicOn;
	public Button MusicOff;

	// Use this for initialization
	void Start () {
		SoundOn.onClick.AddListener (() => {
			AudioListener.pause = false;
		});

		SoundOff.onClick.AddListener (() => {
			AudioListener.pause = true;
		});

		MusicOn.onClick.AddListener (() => {
			AudioListener.pause = false;
		});
		
		MusicOff.onClick.AddListener (() => {
			AudioListener.pause = true;
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
