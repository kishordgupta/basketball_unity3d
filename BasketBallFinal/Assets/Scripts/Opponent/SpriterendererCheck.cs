using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriterendererCheck : MonoBehaviour {

	// Use this for initialization
	public Button Speeding;
	public Button Jumping;
	public Button Growing;

	public GameObject EffectOnSpeeding;
	public GameObject EffectOnJumping;
	public GameObject EffectOnGrowing;


		public Renderer rend;
		
		void Start() {
			rend = GetComponent<Renderer>();
			rend.enabled = true;

		Speeding.onClick.AddListener (() => {
			rend.enabled = false;
			EffectOnSpeeding.SetActive(true);
			MoveTowardsBall.speed = 0f;
			StartCoroutine(WaitAndEnableForSpeed());

		});


		Jumping.onClick.AddListener (() => {
			rend.enabled = false;
			EffectOnJumping.SetActive(true);
			MoveTowardsBall.speed = 0f;
			StartCoroutine(WaitAndEnableForJump());
			print ("jumpclicked");
			
		});


		Growing.onClick.AddListener (() => {
			rend.enabled = false;
			EffectOnGrowing.SetActive(true);
			MoveTowardsBall.speed = 0f;
			StartCoroutine(WaitAndEnableForGrowing());
	
		});
		}
		

	IEnumerator WaitAndEnableForSpeed()
	{
		yield return new WaitForSeconds(1f);
		EffectOnSpeeding.SetActive (false);
		rend.enabled = true;
		MoveTowardsBall.speed = 3.0f;
	}

	IEnumerator WaitAndEnableForJump(){
		yield return new WaitForSeconds(2f);
		EffectOnJumping.SetActive (false);
		rend.enabled = true;
		MoveTowardsBall.speed = 3.0f;

	}

	IEnumerator WaitAndEnableForGrowing(){
	
		yield return new WaitForSeconds(2f);
		EffectOnGrowing.SetActive (false);
		rend.enabled = true;
		MoveTowardsBall.speed = 3.0f;

	}
		// Toggle the Object's visibility each second.
		void Update() {
			// Find out whether current second is odd or even
			
		}

}
