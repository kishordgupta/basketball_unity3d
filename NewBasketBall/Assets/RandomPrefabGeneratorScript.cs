using UnityEngine;
using System.Collections;

public class RandomPrefabGeneratorScript : MonoBehaviour {

	public GameObject[] Shapes;
	private GameObject SoloShape;

	// Use this for initialization
	void Start () {

		SoloShape = getBuilding();	
		GameObject DrawShape = Instantiate(SoloShape, new Vector2 (0f, 3.5f), SoloShape.transform.rotation) as GameObject;
		print (Shapes.Length);
	}
	private GameObject getBuilding() {
		return Shapes[Random.Range(0, Shapes.Length - 1)];
	}
	// Update is called once per frame
	void Update () {


	
	}
}
