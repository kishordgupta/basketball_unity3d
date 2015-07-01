using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Player : MonoBehaviour
{
		public Transform target;
		
		public static float speed = 3f;
		
		public static float distanceJump = 2f;
		public static float speedJump = 2f;
		//public Country playerSprite;
		//public Sprite[] faceCountryList; 
		//public Country[] countryArray;
		public Opponent opponentTeam;
		public	Vector3 playerPosition;
	    public AudioClip playerJump;
	//	public static List<TournamentResult> roundTournamentResultList= new List<TournamentResult>();
		
		
	public void GameStart ()
	{
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

		void Start()
		{
//		roundTournamentResultList=new List<TournamentResult>();
//
//		//countryArray = new Country[19];
//
//		for(int i=0;i<League.tournamentResultList.Count;i++)
//		{
//			if(League.tournamentResultList.ElementAt(i).GetRoundNumber()==PlayerPrefs.GetInt("roundNumber"))
//			{
//				roundTournamentResultList.Add (League.tournamentResultList.ElementAt(i));
//				print (PlayerPrefs.GetInt("roundNumber"));
//			}
//
//		}
//
//
//		for(int i=0;i<roundTournamentResultList.Count;i++)
//		{
//			if(CountrySelect.selectedCountry.getCountryName()==roundTournamentResultList.ElementAt(i).GetHomeName())
//			{
//				gameObject.GetComponent<SpriteRenderer>().sprite=roundTournamentResultList.ElementAt(i).GetFaceHomeSprite();
//				opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=roundTournamentResultList.ElementAt(i).GetFaceAwaySprite();
//				print(roundTournamentResultList.ElementAt(i).GetHomeName()+roundTournamentResultList.ElementAt(i).GetAwayName());
//			}
//			else if(CountrySelect.selectedCountry.getCountryName()==roundTournamentResultList.ElementAt(i).GetAwayName())
//			{
//				gameObject.GetComponent<SpriteRenderer>().sprite=roundTournamentResultList.ElementAt(i).GetFaceAwaySprite();
//				opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=roundTournamentResultList.ElementAt(i).GetFaceHomeSprite();
//			}
//		}


//		for(int i=0;i<countryArray.Length;i++)
//		{
//			countryArray[i]= new Country(faceCountryList[i],i,Constants.countryName[i]);
//		}
//				for(int i=0;i<countryArray.Length;i++)
//					{
//						
//						if(countryArray[i].getCountryName()==PlayerPrefs.GetString("playerCountry"))
//						{
//							gameObject.GetComponent<SpriteRenderer>().sprite=countryArray[i].getFaceForCountry();
//							
//					
//						}
//						if(countryArray[i].getCountryName()==PlayerPrefs.GetString("opponentName"))
//							{
//								opponentTeam.gameObject.GetComponent<SpriteRenderer>().sprite=	countryArray[i].getFaceForCountry();
//							}
//
//					}


		}
		
		void Jump ()
		{
				iTween.MoveBy (this.gameObject, iTween.Hash ("y", distanceJump, "speed", speedJump));
				AudioSource.PlayClipAtPoint (playerJump, transform.position);
		}

		void Update ()
		{

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
