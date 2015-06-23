using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {


	public GameObject playerObject;
	public GameObject opponentObject;

	void Start () {
	
	}
	

	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.CompareTag("greenIce"))
		{
		SetGreenIceCondition(other);
		}
		else if(other.gameObject.CompareTag("greenSpeed"))
		{
			SetGreenSpeedCondition(other);
		}
		else if(other.gameObject.CompareTag("greenJump"))
		{
			SetGreenJumpCondition(other);
		}

		else if(other.gameObject.CompareTag("greenGrow"))
		{
			SetRedGrowCondition(other);
		}

		else if(other.gameObject.CompareTag("redIce"))
		{
			SetRedIceCondition(other);
		}
		else if(other.gameObject.CompareTag("redSpeed"))
		{
			SetRedSpeedCondition(other);
		}
		else if(other.gameObject.CompareTag("redJump"))
		{
			SetRedJumpCondition(other);
		}
		
		else if(other.gameObject.CompareTag("redGrow"))
		{
			SetRedGrowCondition(other);
		}

		else if(other.gameObject.CompareTag("yellowBig"))
		{
			SetYellowBallBigCondition(other);
		}
		
		else if(other.gameObject.CompareTag("yellowSmall"))
		{
			SetBallSmallCondition(other);
		}





	}


	void SetGreenIceCondition(Collider2D ice)
	{
		if(Ball.playerHand)
		{
			MoveTowardsBall.speed=0.0f;
			StartCoroutine(GreenIceWait());
		}
		
		else if(!Ball.playerHand)
		{

			Player.speed=0.0f;
			Player.distanceJump=0.0f;
			Player.speedJump=0.0f;
			StartCoroutine(GreenIceWait());
		}
		Destroy(ice.gameObject);

	}

	IEnumerator GreenIceWait()
	{
		yield return new WaitForSeconds(5f);
		Player.speed=3.0f;
		Player.distanceJump=2.0f;
		Player.speedJump=2.0f;
		MoveTowardsBall.speed=3.0f;

		playerObject.transform.localScale=new Vector3(1f,1f,1);
		opponentObject.transform.localScale=new Vector3(1f,1f,1);

		this.gameObject.transform.localScale=new Vector3(0.1209f,0.1202f,1);

	}

	void SetGreenSpeedCondition(Collider2D speed)
	{
		if(Ball.playerHand)
		{
			Player.speed=6.0f;
			Player.distanceJump=2.0f;
			Player.speedJump=2.0f;
			StartCoroutine(GreenIceWait());
		}
		
		else if(!Ball.playerHand)
		{
			MoveTowardsBall.speed=6.0f;
			StartCoroutine(GreenIceWait());
		}
		Destroy(speed.gameObject);

	}

	void SetGreenJumpCondition(Collider2D jump)
	{
		if(Ball.playerHand)
		{
			Player.speed=3.0f;
			Player.distanceJump=4.0f;
			Player.speedJump=4.0f;
			StartCoroutine(GreenIceWait());
		}
		
		else if(!Ball.playerHand)
		{
			MoveTowardsBall.speed=8.0f;
			StartCoroutine(GreenIceWait());
		}
		Destroy(jump.gameObject);
		
	}

	void SetGreenGrowCondition(Collider2D grow)
	{
		if(Ball.playerHand)
		{
			playerObject.transform.localScale=new Vector3(1.5f,1.5f,1);
			StartCoroutine(GreenIceWait());
		}
		
		else if(!Ball.playerHand)
		{
			opponentObject.transform.localScale= new Vector3(1.5f,1.5f,1f);
			StartCoroutine(GreenIceWait());
		}
		Destroy(grow.gameObject);
		
	}

	void SetRedSpeedCondition(Collider2D speedRed)
	{
		if(Ball.playerHand)
		{
			Player.speed=1.0f;
			Player.distanceJump=2.0f;
			Player.speedJump=2.0f;
			StartCoroutine(GreenIceWait());
		}
		
		else if(!Ball.playerHand)
		{
			MoveTowardsBall.speed=2.0f;
			StartCoroutine(GreenIceWait());
		}
		Destroy(speedRed.gameObject);
		
	}
	void SetRedGrowCondition(Collider2D shrinkRed)
	{
		if(Ball.playerHand)
		{
			playerObject.transform.localScale=new Vector3(0.5f,0.5f,1);
			StartCoroutine(GreenIceWait());
		}
		
		else if(!Ball.playerHand)
		{
			opponentObject.transform.localScale= new Vector3(0.5f,0.5f,1f);
			StartCoroutine(GreenIceWait());
		}
		Destroy(shrinkRed.gameObject);
		
	}
	void SetRedJumpCondition(Collider2D jumpRed)
	{
		if(Ball.playerHand)
		{
			Player.speed=3.0f;
			Player.distanceJump=1.0f;
			Player.speedJump=1.0f;
			StartCoroutine(GreenIceWait());
		}
		
		else if(!Ball.playerHand)
		{
			MoveTowardsBall.speed=1.0f;
			StartCoroutine(GreenIceWait());
		}
		Destroy(jumpRed.gameObject);
		
	}

	void SetRedIceCondition(Collider2D iceRed)
	{
		if(Ball.playerHand)
		{
			Player.speed=0.0f;
			Player.distanceJump=0.0f;
			Player.speedJump=0.0f;
			StartCoroutine(GreenIceWait());
		}
		
		else if(!Ball.playerHand)
		{
			MoveTowardsBall.speed=0.0f;
			StartCoroutine(GreenIceWait());
		}
		Destroy(iceRed.gameObject);
		
	}

	void SetYellowBallBigCondition(Collider2D ballBig)
	{
	

			this.gameObject.transform.localScale=new Vector3(0.18135f,0.1803f,1);
			StartCoroutine(GreenIceWait());
			Destroy(ballBig.gameObject);
		
	}
	void SetBallSmallCondition(Collider2D ballSmall)
	{


			this.gameObject.transform.localScale=new Vector3(0.06045f,0.0601f,1);
			StartCoroutine(GreenIceWait());
			Destroy(ballSmall.gameObject);
		
	}
}
