using UnityEngine;
using System.Collections;

public class PlayerControlMultiPlayer : MonoBehaviour
{

	public Transform target;
	public static float speed = 3f;
	public static float distanceJump = 2f;
	public static float speedJump = 2f;

	public Opponent opponentTeam;
	public static	Vector2 playerPosition;
	public AudioClip playerJump;

	
	public void GameStart ()
	{
		playerPosition = new Vector2 (-5f, -1.8f);
		
		gameObject.transform.position = playerPosition;
		Opponent.opponentPosition = new Vector2 (-5f, 1.8f);
		
		
	}

	
	void OnDisable ()
	{
		GameEventManager.GameStart -= GameStart;
		
	}
	
	void OnEnable ()
	{
		
		GameEventManager.GameStart += GameStart;
	}
	
	void Start ()
	{

	}
	
	void Jump ()
	{
		iTween.MoveBy (this.gameObject, iTween.Hash ("y", distanceJump, "speed", speedJump));
		AudioSource.PlayClipAtPoint (playerJump, transform.position);
	}
	
	void Update ()
	{
		if (networkView.isMine) {
		
			#if UNITY_EDITOR || UNITY_WEBPLAYER
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			Jump();
			
		}
		
		
		
		if (Input.GetButtonDown ("Jump")) {
			Jump();
		}
			#endif
		
			#if UNITY_ANDROID || UNITY_IPHONE
		
		
		
		
		var h = CFInput.GetAxis("Horizontal");
		var v = CFInput.GetAxis("Vertical");
		
		
		if (Mathf.Abs(h) > Quaternion.kEpsilon )//|| Mathf.Abs(v) > Quaternion.kEpsilon)
		{
			Vector3 direction =  new Vector3(h, 0, 0).normalized;
			transform.position += direction * speed * Time.deltaTime;
			
		}
		
		
		if (CFInput.GetButtonDown ("Jump") && transform.position.y<-2) {
			Jump();
		}
			#endif
		
		}		
	}
}
