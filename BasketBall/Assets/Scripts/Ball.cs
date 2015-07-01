
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	
	
	public float constantSpeed = 100f;
	public float smoothingFactor = 2f;
	float force = 5.0f;
	float jumpForce = 2f;
	public Vector3 ballPosition;
	public static int playerScore;
	public static int oppnentScore;
	public static string str1;
	public static string str2;

	public static bool playerHand=true;

	public AudioClip[] BallTouch;



	float goalPause;
	
	
	public void GameStart ()
	{
		gameObject.transform.position = ballPosition;
		
	}
	
	public void GameOver ()
	{
		
	}


	
	public void PointCalculation ()
	{
		
	}
	
	void OnDisable ()
	{
		GameEventManager.GameStart -= GameStart;
		//GameEventManager.GameOver -= GameOver;
		//GameEventManager.GamePointCalculation -= PointCalculation;
	}
	
	void OnEnable ()
	{
		
		GameEventManager.GameStart += GameStart;
		//GameEventManager.GameOver += GameOver;
		//GameEventManager.GamePointCalculation += PointCalculation;
	}
	
	void Start ()
	{
		//	print(League.tournamentResultList.ElementAt(1).GetHomeName());
		AudioSource.PlayClipAtPoint(BallTouch[3],transform.position);
		ballPosition = gameObject.transform.position;
		
		playerScore=0;
		oppnentScore=0;
		str1 = "0";
		str2 = "0";



		
		
		//		gameObject.transform.position = new Vector3(Screen.width/2,gameObject.transform.position.y);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void LateUpdate ()
	{
		
	}

	void setBallPosition()
	{
		ballPosition = gameObject.transform.position;
		scorepause();
	}
	
	void scorepause()
	{	
		goalPause = 10.0f;
		while (goalPause > 0 ) {
			goalPause -= Time.deltaTime;
			Time.timeScale = 0;
			print ("pause");
			
		}
		Time.timeScale = 1;
		
	}


	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "GoalBar") {
			GameEventManager.TriggerGamePointCalculation ();
			GameEventManager.TriggerGameStart ();
			oppnentScore++;
			AudioSource.PlayClipAtPoint(BallTouch[2],transform.position);
			setBallPosition();

			//PlayerPrefs.SetInt("str2",oppnentScore);
			//PlayerPrefs.SetInt("roundNumber",roundNumber);
			//print ("Oppo Goal");
			str2 = oppnentScore.ToString();
			//	gameObject.GetComponent<Text>().text = str2;
			print (str2);
			//Application.LoadLevel(0);
			
		} else  if (other.gameObject.tag == "OpponentGoalBar") {
			GameEventManager.TriggerGamePointCalculation ();
			GameEventManager.TriggerGameStart ();
			playerScore++;
			AudioSource.PlayClipAtPoint(BallTouch[2],transform.position);
			scorepause();
			str1 = playerScore.ToString();
			//gameObject.GetComponent<Text>().text = str1;
			

			
		}
		
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		//				if (other.collider.CompareTag ("Player")) {//&& other.collider.CompareTag ("Opponent") && other.collider.CompareTag ("Wall")) {
		//						print ("working");
		//						rigidbody2D.AddForce (Vector3.up * 100);
		//				} else 
		if (other.collider.CompareTag ("Hand")) {
						//						
						print ("colliding hands");
						rigidbody2D.AddForce (new Vector3 (3.00f, 3.00f, 0) * force, ForceMode2D.Impulse);
						playerHand = true;

						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);


						//	rigidbody2D.AddTorque (5.05f, ForceMode2D.Impulse); 
			
			
				} else if (other.collider.CompareTag ("OpponentHand")) {
						rigidbody2D.AddForce (new Vector3 (-5.00f, -5.00f, 0) * force, ForceMode2D.Impulse);
						playerHand = false;
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						//rigidbody2D.AddTorque (-5.05f, ForceMode2D.Impulse); 
				} else if (other.collider.CompareTag ("HandIdle")) {
			
						rigidbody2D.AddForce (new Vector3 (0.25f, 0.25f, 0) * force, ForceMode2D.Force);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
			
				} else if (other.collider.CompareTag ("Player")) {
						//print ("colliding  " + other.collider.tag);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector3 (1, 1.5f, 0) * force, ForceMode2D.Impulse);
//						rigidbody2D.AddTorque (1.0f, ForceMode2D.Force);
						playerHand = true;
			
						//						Vector2 forceVec = rigidbody.velocity.normalized * force;
						//			
						//			
						//			
						//						rigidbody.AddForce (forceVec, ForceMode.VelocityChange);
						//						rigidbody2D.AddForce (-Vector3.up * 100);
			
				} else if (other.collider.CompareTag ("Opponent")) {
						//print ("colliding  " + other.collider.tag);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector3 (-1, -1.5f, 0) * force, ForceMode2D.Force);
//						rigidbody2D.AddTorque (1.0f, ForceMode2D.Force);
						playerHand = false;
				} else if (other.collider.CompareTag ("JumperLeft")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector3 (8.5f, 5, 0) * jumpForce, ForceMode2D.Force);
				} else if (other.collider.CompareTag ("JumperRight")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector3 (-8.5f, 5, 0) * jumpForce, ForceMode2D.Force);
				} else if (other.collider.CompareTag ("jumperwall")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector3 (-5.5f, 5, 0) * jumpForce, ForceMode2D.Impulse);
				} else if (other.collider.CompareTag ("net")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						rigidbody2D.AddTorque (3.0f, ForceMode2D.Force);
				} else if (other.collider.CompareTag ("Hoop")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
		

//						rigidbody2D.AddForce (new Vector3 (0.00f, 0.0000005f, 0f) * 0.000000001f, ForceMode2D.Force);
				} else if (other.collider.CompareTag ("Wall")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
				
		}

		
	}
	
	
	
	
}
