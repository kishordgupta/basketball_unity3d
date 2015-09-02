using UnityEngine;
using System.Collections;

public class PowerGeneratorScript : MonoBehaviour {


	public GameObject[] powerUpObject;
	public bool powerGeneratorBool=true;
	private GameObject powerSingleObject;
	void Start () {
		StartCoroutine(powerGeneratorWait());
	}
	

	void Update () {
	

	}


	IEnumerator powerGeneratorWait()
	{
		yield return new WaitForSeconds(15f);
		int randomNumber=Random.Range(0,powerUpObject.Length);
		powerSingleObject=(GameObject)Instantiate(powerUpObject[randomNumber]);
		StartCoroutine(powerDegeneratorWait());
		StartCoroutine(powerGeneratorWait());

	
	}
	IEnumerator powerDegeneratorWait()
	{
		yield return new WaitForSeconds(10f);
		Destroy(powerSingleObject.gameObject);
	}


}
