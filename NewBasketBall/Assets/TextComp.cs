using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextComp : MonoBehaviour {


	//public GameObject Devicelist;
	Text device;
	public static string name;


	// Use this for initialization
	void Start () {
		name = "device one";
		device = GetComponent<Text> ();
		device.text = name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
