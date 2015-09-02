using UnityEngine;
using System.Collections;

public class OpponentPlayerControl : MonoBehaviour {
	public static float speed = 3f;
	
	public static float distanceJump = 2f;
	public static float speedJump = 2f;
//	public Opponent opponentTeam;
	public static	Vector3 playerPosition;
	public AudioClip playerJump;
	
	private Vector2 lastPosition;
	//	public Vector2 newPosition;
	
	
	public void GameStart ()
	{
		playerPosition = new Vector3 (5f, -1.8f, 0f);
		
		gameObject.transform.position= playerPosition;
		
		
	}
	
	void OnDisable ()
	{
		GameEventManager.GameStart -= GameStart;
		
	}
	
	void OnEnable ()
	{
		
		GameEventManager.GameStart += GameStart;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Jump ()
	{
		iTween.MoveBy (this.gameObject, iTween.Hash ("y", distanceJump, "speed", speedJump));
		AudioSource.PlayClipAtPoint (playerJump, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (networkView.isMine) {
			
			Movement();
		}
	}
	public void Movement(){
		
		#if UNITY_EDITOR || UNITY_WEBPLAYER
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			Jump ();
			
		}
		
		
		
		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}
		#endif
		
		#if UNITY_ANDROID || UNITY_IPHONE
		
		
		
		
		var h = CFInput.GetAxis ("Horizontal");
		var v = CFInput.GetAxis ("Vertical");
		
		
		if (Mathf.Abs (h) > Quaternion.kEpsilon) {//|| Mathf.Abs(v) > Quaternion.kEpsilon)
			Vector3 direction = new Vector3 (h, 0, 0).normalized;
			transform.position += direction * speed * Time.deltaTime;
			
		}
		
		
		if (CFInput.GetButtonDown ("Jump") && transform.position.y < -2) {
			Jump ();
		}
		#endif
		
		//		if (Vector2.Distance (transform.position, lastPosition) >= 0.005f) {
		//		
		//			lastPosition = transform.position;
		//			networkView.RPC("SetPosition", RPCMode.All, transform.position);
		//		
		//		}
		
	}
	
	//	[RPC] void SetPosition(Vector2 newPosition)
	//	{
	//		transform.position = newPosition;
	//		}
	
	private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		// Serialize the position and color
		if (stream.isWriting) {
			Vector3 positionOppo = transform.position;
			stream.Serialize(ref positionOppo);
		} else {
			Vector3 positioOppo = new Vector3(5f, -1.8f, 0f);
			
			stream.Serialize(ref positioOppo);
			transform.position = positioOppo;
		}
	}
}
