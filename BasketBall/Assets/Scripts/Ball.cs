
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	
	
	public float constantSpeed = 100f;
	public float smoothingFactor = 2f;
	float force = 3.0f;
	float jumpForce = 1f;
	public Vector3 ballPosition;
	public static int playerScore;
	public static int oppnentScore;
	public static string str1;
	public static string str2;

	public static float xForce = 1.50f;
	public static float yForce = 1.50f;

	public Vector2 velocity;
	public Rigidbody2D baskBall;

	public static bool playerHand=true;
	public static bool ownHalf = false;

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
		goalPause = 100.0f;
		while (goalPause > 0 ) {
			goalPause -= Time.deltaTime;
			Time.timeScale = 0;
			ballPosition = new Vector3 (0f,4f,0f);
			Player.playerPosition = new Vector2 (-5f, -1.8f);
			Opponent.opponentPosition = new Vector2 (5f, -1.8f);
//			print ("pause");
			
		}
		Time.timeScale = 1;
		
	}

//	IEnumerator BallSlow()
//	{
//		baskBall.drag = 3.0f;
//		yield return new WaitForSeconds(1);
//		baskBall.drag = 0.0f;
//	}
	
	
	
	void OnTriggerEnter2D (Collider2D other)
	{   


		if (other.gameObject.tag == "GoalBar") {
			GameEventManager.TriggerGamePointCalculation ();
			GameEventManager.TriggerGameStart ();
			oppnentScore = oppnentScore + 2;

			AudioSource.PlayClipAtPoint(BallTouch[2],transform.position);
			setBallPosition();

			//PlayerPrefs.SetInt("str2",oppnentScore);
			//PlayerPrefs.SetInt("roundNumber",roundNumber);
			//print ("Oppo Goal");
			str2 = oppnentScore.ToString();
			//	gameObject.GetComponent<Text>().text = str2;
//			print (str2);
			//Application.LoadLevel(0);
			
		} 

		else  if (other.gameObject.tag == "GoalBar" && ownHalf == true) {
			GameEventManager.TriggerGamePointCalculation ();
			GameEventManager.TriggerGameStart ();
			oppnentScore = oppnentScore + 3;
			print (ownHalf);
			
			AudioSource.PlayClipAtPoint(BallTouch[2],transform.position);
			scorepause();
			str2 = oppnentScore.ToString();
			//gameObject.GetComponent<Text>().text = str1;
			
			
			
		}


		else  if (other.gameObject.tag == "OpponentGoalBar" && ownHalf == false) {
			GameEventManager.TriggerGamePointCalculation ();
			GameEventManager.TriggerGameStart ();
			playerScore = playerScore + 2;
			print (ownHalf);
			

			AudioSource.PlayClipAtPoint(BallTouch[2],transform.position);
			scorepause();
			str1 = playerScore.ToString();
			//gameObject.GetComponent<Text>().text = str1;
			

			
		}

		else  if (other.gameObject.tag == "OpponentGoalBar" && ownHalf == true) {
			GameEventManager.TriggerGamePointCalculation ();
			GameEventManager.TriggerGameStart ();
			playerScore = playerScore + 3;
			
			AudioSource.PlayClipAtPoint(BallTouch[2],transform.position);
			scorepause();
			str1 = playerScore.ToString();
			//gameObject.GetComponent<Text>().text = str1;
			
			
			
		}
		
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{




		if (other.collider.CompareTag ("Hand")) {
											
//						print ("colliding hands");
						rigidbody2D.AddForce (new Vector2 (xForce, yForce) * force, ForceMode2D.Impulse);

						playerHand = true;
			ownHalf = false;

						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
			
			
				} else if (other.collider.CompareTag ("OpponentHand")) {
						
						rigidbody2D.AddForce (new Vector2 (-3.50f, 3.00f) * force, ForceMode2D.Impulse);
						playerHand = false;
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
			ownHalf = false;




				} else if (other.collider.CompareTag ("HandIdle")) {
			
						rigidbody2D.AddForce (new Vector2 (0, 0.05f) * force, ForceMode2D.Force);
//						rigidbody2D.velocity = new Vector2 (0f, 3.0f);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
			ownHalf = false;


				} else if (other.collider.CompareTag ("Player")) {
						//print ("colliding  " + other.collider.tag);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);

						rigidbody2D.AddForce (new Vector2 (0f, 1f) * force, ForceMode2D.Force);
						playerHand = true;
			ownHalf = false;


				} else if (other.collider.CompareTag ("Opponent")) {
						//print ("colliding  " + other.collider.tag);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						rigidbody2D.AddForce (new Vector2 (0f, 1f) * force, ForceMode2D.Force);	
//						
						playerHand = false;
			ownHalf = false;

				} else if (other.collider.CompareTag ("JumperLeft")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector3 (8.5f, 5, 0) * jumpForce, ForceMode2D.Impulse);
						rigidbody2D.velocity = new Vector2 (5.0f, 5.0f);
				
				} else if (other.collider.CompareTag ("JumperRight")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector3 (-8.5f, 5, 0) * jumpForce, ForceMode2D.Impulse);
						rigidbody2D.velocity = new Vector2 (-5.0f, 5.0f);


				} else if (other.collider.CompareTag ("jumperwall")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
				} else if (other.collider.CompareTag ("net")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						rigidbody2D.AddTorque (3.0f, ForceMode2D.Force);
				} else if (other.collider.CompareTag ("Hoop")) {

//			StartCoroutine(BallSlow());
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//			print("at last");
						rigidbody2D.velocity = new Vector2 (0.0f, -1.0f);

//			rigidbody2D.AddForce (new Vector2 (0.0f, 0f) * 0, ForceMode2D.Force); 
//			baskBall.drag = 3.0f;

				} else if (other.collider.CompareTag ("Wall")) {
						
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);

				} else if (other.collider.CompareTag ("Floor")) {
			
						//			rigidbody2D.AddTorque (0.05f, ForceMode2D.Force);	
						rigidbody2D.AddForce (new Vector2 (0f, 5.5f) * force, ForceMode2D.Force);
//						rigidbody2D.velocity = new Vector2 (0.0f, 5.0f);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						ownHalf = false;
		} else if (other.collider.CompareTag ("Player") && other.collider.CompareTag ("Opponent") ) {
				
			rigidbody2D.velocity = new Vector2 (0.0f, 5.0f);
			print ("like this");
			ownHalf = false;
		}
		else if (other.collider.CompareTag ("Border")) {
			
			ownHalf = true;
		}

		else if (other.collider.CompareTag ("MidBorder")) {
			
			ownHalf = true;
		}

		
	}

	void MidBorder()
	{

	}
	
	
	
	
}
