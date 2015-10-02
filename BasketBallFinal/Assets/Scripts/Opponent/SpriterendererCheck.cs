using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriterendererCheck : MonoBehaviour {

	// Use this for initialization
	public Button Speeding;
	public Button Jumping;
	public Button Growing;
	public Button IcingOppo;

	public GameObject EffectOnSpeeding;
	public GameObject EffectOnJumping;
	public GameObject EffectOnGrowing;
	public GameObject EffectOnIcing;

	public GameObject GunSpeed;
	public GameObject MissileJump;
	public GameObject UZIWeapon;


	public static Vector2 WeaponInstansiatePos;
	public static bool GunActive = false;
//	public static bool MissileActive = false;
	public static bool KillOpponent = false;

	public AudioClip[] EffectsOnOppo;



		public Renderer rend;
		
		void Start() {
			rend = GetComponent<Renderer>();
			rend.enabled = true;

		Speeding.onClick.AddListener (() => {
			WeaponInstansiatePos = GameObject.FindGameObjectWithTag("Player").transform.position;
			WeaponInstansiatePos = WeaponInstansiatePos + new Vector2(0.5f,0);
			Instantiate(GunSpeed,WeaponInstansiatePos,Quaternion.identity);
			GunActive = true;
			rend.enabled = false;
			AudioSource.PlayClipAtPoint(EffectsOnOppo[0],transform.position);
			EffectOnSpeeding.SetActive(true);
			MoveTowardsBall.speed = 0f;
//			StartCoroutine(VanishWeaponGun());
			StartCoroutine(WaitAndEnableForSpeed());
			StartCoroutine(DisableEffectOnSpeeding());
		});


		Jumping.onClick.AddListener (() => {
			WeaponInstansiatePos = GameObject.FindGameObjectWithTag("Player").transform.position;
			WeaponInstansiatePos = WeaponInstansiatePos + new Vector2(0.5f,0);
			Instantiate(MissileJump,WeaponInstansiatePos,Quaternion.identity);
			KillOpponent = true;
//			MissileActive = true;
//			KillOpponent = MissileAction.MissileCollisionSign;


//			if(KillOpponent == true)
//			{
//			rend.enabled = false;
//			EffectOnJumping.SetActive(true);
//			MoveTowardsBall.speed = 0f;
//			StartCoroutine(WaitAndEnableForJump());
//			}
			print("KillOpponent " + KillOpponent );
		});

		IcingOppo.onClick.AddListener (() => {
		
			EffectOnIcing.SetActive(true);
			MoveTowardsBall.speed = 0f;
			StartCoroutine(IcingEffectDisable());
		});


		Growing.onClick.AddListener (() => {

			WeaponInstansiatePos = GameObject.FindGameObjectWithTag("Player").transform.position;
			WeaponInstansiatePos = WeaponInstansiatePos + new Vector2(0.5f,0);
			Instantiate(UZIWeapon,WeaponInstansiatePos,Quaternion.identity);
			GunActive = true;
			rend.enabled = false;
			AudioSource.PlayClipAtPoint(EffectsOnOppo[0],transform.position);
			EffectOnGrowing.SetActive(true);
			MoveTowardsBall.speed = 0f;
			StartCoroutine(WaitAndEnableForGrowing());
	
		});
		}
		
//	IEnumerator VanishWeaponGun()
//	{
//		yield return new WaitForSeconds (1f);
//		Destroy(GunSpeed.gameObject);
//	}

	IEnumerator WaitAndEnableForSpeed()
	{
		yield return new WaitForSeconds(5f);
		rend.enabled = true;
		MoveTowardsBall.speed = 3.0f;

	}

	IEnumerator DisableEffectOnSpeeding()
	{
		yield return new WaitForSeconds (1.0f);
		EffectOnSpeeding.SetActive (false);

	}

	IEnumerator DisableEffectOnJumping()
	{
		yield return new WaitForSeconds (1.0f);
		EffectOnJumping.SetActive (false);

		
	}

	IEnumerator IcingEffectDisable()
	{
		yield return new WaitForSeconds(5f);
		EffectOnIcing.SetActive (false);
	}

	IEnumerator WaitAndEnableForJump(){
		yield return new WaitForSeconds(5f);
		EffectOnJumping.SetActive (false);
		rend.enabled = true;
		MoveTowardsBall.speed = 3.0f;
		KillOpponent = false;

	}

	IEnumerator WaitAndEnableForGrowing(){
	
		yield return new WaitForSeconds(5f);
		EffectOnGrowing.SetActive (false);
		rend.enabled = true;
		MoveTowardsBall.speed = 3.0f;

	}
		// Toggle the Object's visibility each second.
		void Update() {
//		KillOpponent = MissileAction.MissileCollisionSign;

		if(KillOpponent == true)
		{
			rend.enabled = false;
			AudioSource.PlayClipAtPoint(EffectsOnOppo[0],transform.position);
			EffectOnJumping.SetActive(true);
			MoveTowardsBall.speed = 0f;
			MissileAction.MissileCollisionSign = false;
			StartCoroutine(WaitAndEnableForJump());
		}
		}

}
