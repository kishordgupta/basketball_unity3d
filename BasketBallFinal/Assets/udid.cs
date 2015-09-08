using UnityEngine;
using System.Collections;


public class udid : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	public static string deviceUniqueIdentifier; 

		string abc = SystemInfo.deviceUniqueIdentifier;
		print (abc);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
