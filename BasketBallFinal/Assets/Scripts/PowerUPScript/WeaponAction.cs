using UnityEngine;
using System.Collections;

public class WeaponAction : MonoBehaviour {
//	public GameObject target;
//	public float speed = 0.001f;
	public static Vector2 WeaponTargetPos;
//	public static bool MissileDisable = false;
	// Use this for initialization
	void Start () {
	
//		WeaponTargetPos = new Vector2 (3.5f, 4.5f);
//		transform.position = Vector2.MoveTowards(SpriterendererCheck.WeaponInstansiatePos, WeaponTargetPos, 0.01f*Time.deltaTime);
//		StartCoroutine (VanishWeapon ());
	}
	
	// Update is called once per frame
	void Update () {
	
		if (SpriterendererCheck.GunActive == true) {
		
			StartCoroutine (VanishWeapon ());

		}  
//		if (SpriterendererCheck.MissileActive == true) {
		
//			WeaponTargetPos = GameObject.FindGameObjectWithTag("Opponent").transform.position;
//		WeaponTargetPos = new Vector2 (3.5f, 4.5f);
//			transform.position = Vector2.MoveTowards(SpriterendererCheck.WeaponInstansiatePos, WeaponTargetPos, speed*Time.deltaTime);
//		StartCoroutine (VanishWeapon ());
//			if(MissileDisable = true)
//			{
//				Destroy(gameObject);
//			}
//		}
//		WeaponTargetPos = GameObject.FindGameObjectWithTag("Opponent").transform.position;
//		print (WeaponTargetPos + " WeaponTarget");
//		print ("Missile Position" + gameObject.transform.position + "weaponInstantiatePos: "+ SpriterendererCheck.WeaponInstansiatePos);
//	}
	}
	IEnumerator VanishWeapon()
	{
		yield return new WaitForSeconds (1.0f);
//		MissileDisable = true;
		Destroy (gameObject);
	}

//	void OnCollisionEnter2D (Collision2D other)
//	{
//		if (other.collider.CompareTag ("Opponent")) {
//		
//			MissileDisable = true;
//			print ("MissileDisable " + MissileDisable);
//		}
//	}

}
