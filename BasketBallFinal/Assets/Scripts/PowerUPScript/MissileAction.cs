using UnityEngine;
using System.Collections;

public class MissileAction : MonoBehaviour {


	public static Vector2 WeaponTargetPos;

	public float speed = 1.0f;
	public static bool MissileCollisionSign;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float temp = WeaponTargetPos.x - SpriterendererCheck.WeaponInstansiatePos.x;
		float tempx = temp / 10;
		WeaponTargetPos = GameObject.FindGameObjectWithTag("Opponent").transform.position;
		if (tempx > 0) {
			transform.position += new Vector3 (tempx, 0, 0);
		} else {
		
			transform.localScale += new Vector3(-1F, 0, 0);
			transform.position += new Vector3 (tempx, 0, 0);
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Opponent") {
	
			MissileCollisionSign = true;
			Destroy(gameObject);
		}
	}
}
