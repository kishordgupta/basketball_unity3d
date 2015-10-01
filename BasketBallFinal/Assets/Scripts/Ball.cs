using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using Soomla;


namespace Soomla.Store.Example{
public class Ball : MonoBehaviour
{
	
	
	public float constantSpeed = 10f;
//	public float smoothingFactor = 2f;
	float force = 9.0f;
	float jumpForce = 1f;
		private float maxForce = 30f;
	public static Vector2 ballPosition;
	public static int playerScore;
	public static int oppnentScore;
	public static string str1 = "0";
	public static string str2 = "0";

	public static float xForce = 30f + PurchaseManager.playerHandIncrement;
	public static float yForce = 30f + PurchaseManager.playerHandIncrement;

	public GameObject oppo;


	public Vector2 velocity;
	public Rigidbody2D baskBall;

	public static bool playerHand=true;
	public static bool ownHalf = false;

	public AudioClip[] BallTouch;



	float goalPause;
	
	
	public void GameStart ()
	{
		gameObject.transform.position = ballPosition;
		oppo.transform.position = new Vector2 (5f, -1.8f);

		
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
		baskBall = GetComponent<Rigidbody2D> ();

		//	print(League.tournamentResultList.ElementAt(1).GetHomeName());
		AudioSource.PlayClipAtPoint(BallTouch[3],transform.position);
		ballPosition = gameObject.transform.position;
		print ("oppo: ");
		gameObject.rigidbody2D.velocity = new Vector2 (0f, 1f);

		playerScore=0;
		oppnentScore=0;
		str1 = "0";
		str2 = "0";
		
//			print ("xForce:" + xForce);
//			print ("yForce:" + yForce);
//			print ("speed" + Player.speed);
//			print ("jump" + Player.distanceJump);

	}

	void FixedUpdate() {
		baskBall.MoveRotation(baskBall.rotation + constantSpeed * Time.fixedDeltaTime);
			if (rigidbody2D.velocity.magnitude > maxForce)
				rigidbody2D.velocity = rigidbody2D.velocity.normalized;
		}
		
		// Update is called once per frame
	void Update ()
	{
//		float rotation;
//		rotation *= Time.deltaTime;
	}
	
	void LateUpdate ()
	{
		
	}

	void setBallPosition()
	{
		ballPosition = gameObject.transform.position;
		oppo.transform.position = new Vector2 (5f, -1.8f);
		scorepause();
	}
	
	void scorepause()
	{	
		goalPause = 100.0f;
		while (goalPause > 0 ) {
			goalPause -= Time.deltaTime;
			Time.timeScale = 0;
			ballPosition = new Vector2 (0f,0.63f);
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

						if (ownHalf == true && !playerHand) {
								oppnentScore = oppnentScore + 3;
						} else {
								oppnentScore = oppnentScore + 2;
						}
						AudioSource.PlayClipAtPoint (BallTouch [2], transform.position);
						setBallPosition ();



						//PlayerPrefs.SetInt("str2",oppnentScore);
						//PlayerPrefs.SetInt("roundNumber",roundNumber);
						//print ("Oppo Goal");
						str2 = oppnentScore.ToString ();
						//	gameObject.GetComponent<Text>().text = str2;
//			print (str2);
						//Application.LoadLevel(0);
			gameObject.rigidbody2D.velocity = new Vector2 (0f, 1f);
			
				} else if (other.gameObject.tag == "MidBorder") {
				
			ownHalf = true;
//			print ("Boom");
		}




//		else  if (other.gameObject.tag == "GoalBar" && ownHalf == true) {
//			GameEventManager.TriggerGamePointCalculation ();
//			GameEventManager.TriggerGameStart ();
//			oppnentScore = oppnentScore + 3;
//			print (ownHalf);
//			
//			AudioSource.PlayClipAtPoint(BallTouch[2],transform.position);
//			scorepause();
//			str2 = oppnentScore.ToString();
//			//gameObject.GetComponent<Text>().text = str1;
//			
//			
//			
//		}


		else  if (other.gameObject.tag == "OpponentGoalBar") {
			GameEventManager.TriggerGamePointCalculation ();
			GameEventManager.TriggerGameStart ();
			if(ownHalf == true && playerHand){
			playerScore = playerScore + 3;
			print (ownHalf);
			}
			else
			{
				playerScore = playerScore + 2;
//				print (ownHalf);

			}

			AudioSource.PlayClipAtPoint(BallTouch[2],transform.position);
			scorepause();
			str1 = playerScore.ToString();
			//gameObject.GetComponent<Text>().text = str1;
			
			gameObject.rigidbody2D.velocity = new Vector2 (0f, 1f);
			
		}

//		else  if (other.gameObject.tag == "OpponentGoalBar" && ownHalf == true) {
//			GameEventManager.TriggerGamePointCalculation ();
//			GameEventManager.TriggerGameStart ();
//			playerScore = playerScore + 2;
//			
//			AudioSource.PlayClipAtPoint(BallTouch[2],transform.position);
//			scorepause();
//			str1 = playerScore.ToString();
//			//gameObject.GetComponent<Text>().text = str1;
//			
//			
//			
//		}
		
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
						
						rigidbody2D.AddForce (new Vector2 (-40f, 40f) * force, ForceMode2D.Impulse);
						playerHand = false;
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						ownHalf = false;




				} else if (other.collider.CompareTag ("HandIdle")) {
			
//						rigidbody2D.AddForce (new Vector2 (0, 0.05f) * force, ForceMode2D.Force);
//						rigidbody2D.velocity = new Vector2 (0f, 3.0f);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						ownHalf = false;


				} else if (other.collider.CompareTag ("Player")) {
				rigidbody2D.AddForce (new Vector2 (10, 10) * force, ForceMode2D.Impulse);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector2 (0f, 1f) * force, ForceMode2D.Force);
						playerHand = true;
						ownHalf = false;


			}else if (other.collider.CompareTag ("Head")) {
				rigidbody2D.AddForce (new Vector2 (30, 30) * force, ForceMode2D.Impulse);
				AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
				//						rigidbody2D.AddForce (new Vector2 (0f, 1f) * force, ForceMode2D.Force);
				playerHand = true;
				ownHalf = false;
				
				
			} else if (other.collider.CompareTag ("HeadOpp")) {
				rigidbody2D.AddForce (new Vector2 (-30, 30) * force, ForceMode2D.Impulse);
				AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
				//						rigidbody2D.AddForce (new Vector2 (0f, 1f) * force, ForceMode2D.Force);
				playerHand = true;
				ownHalf = false;
				
				
			}else if (other.collider.CompareTag ("Opponent")) {
						//print ("colliding  " + other.collider.tag);
				rigidbody2D.AddForce (new Vector2 (-10, 10) * force, ForceMode2D.Impulse);

						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector2 (0f, 1f) * force, ForceMode2D.Force);
//						rigidbody2D.velocity = new Vector2 (-3f, 3f);
//						
						playerHand = false;
						ownHalf = false;

				} else if (other.collider.CompareTag ("JumperLeft")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector3 (8.5f, 5, 0) * jumpForce, ForceMode2D.Impulse);
//						rigidbody2D.velocity = new Vector2 (5.0f, 5.0f);
				
				} else if (other.collider.CompareTag ("JumperRight")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
//						rigidbody2D.AddForce (new Vector3 (-8.5f, 5, 0) * jumpForce, ForceMode2D.Impulse);
//						rigidbody2D.velocity = new Vector2 (-5.0f, 5.0f);


				} else if (other.collider.CompareTag ("jumperwall")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
				} else if (other.collider.CompareTag ("net")) {
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						rigidbody2D.AddTorque (3.0f, ForceMode2D.Force);
				} else if (other.collider.CompareTag ("Hoop")) {
				AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
				print("yes,force up beforez" + rigidbody2D.velocity.magnitude);

				if(rigidbody2D.velocity.magnitude > 0){
					float xvel = rigidbody2D.velocity.x/2;
					float yvel = rigidbody2D.velocity.y/2;
					rigidbody2D.velocity = new Vector2(xvel,yvel);
					print("yes,force up" + rigidbody2D.velocity.magnitude);
				}

//						rigidbody2D.velocity = new Vector2 (1.5f, -1.0f);
				rigidbody2D.AddForce (new Vector2 (-0, 0) * 0, ForceMode2D.Force);
			
				} else if (other.collider.CompareTag ("Wall")) {
						
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						ownHalf = false;

				} else if (other.collider.CompareTag ("Floor")) {
						ownHalf = false;
						//			rigidbody2D.AddTorque (0.05f, ForceMode2D.Force);	
//						rigidbody2D.AddForce (new Vector2 (0f, 3.5f) * force, ForceMode2D.Force);
//						rigidbody2D.velocity = new Vector2 (0.0f, 5.0f);
						AudioSource.PlayClipAtPoint (BallTouch [0], transform.position);
						
				} else if (other.collider.CompareTag ("BallFloor")) {
						ownHalf = false;
			rigidbody2D.AddForce (new Vector2 (0f, 3.5f) * force, ForceMode2D.Force);
		}
			
//			else if (other.collider.CompareTag ("Player") && other.collider.CompareTag ("Opponent") ) {
//				
////			rigidbody2D.velocity = new Vector2 (0.0f, 5.0f);
//
//			print ("like this");
//			ownHalf = false;
//		}
		else if (other.collider.CompareTag ("PballLeave")) {
			
			rigidbody2D.AddForce (new Vector2 (10f, 10f) * force, ForceMode2D.Force);
		}

		else if (other.collider.CompareTag ("OpBallLeave")) {
			
			rigidbody2D.AddForce (new Vector2 (-10f, 10f) * force, ForceMode2D.Force);
		}

		else if (other.gameObject.tag == "Border") {
			rigidbody2D.AddTorque (3.0f, ForceMode2D.Force);
		}

		
	}



	
	
	}	
	
}
