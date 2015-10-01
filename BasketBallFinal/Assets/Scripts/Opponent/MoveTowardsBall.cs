using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class MoveTowardsBall : Action
{

		public static float speed = 3.0f;
		public SharedTransform target;
		public Transform opponentHand;
		public GameObject rotateObject;

		public override TaskStatus OnUpdate ()
		{

				if (Vector3.SqrMagnitude (transform.position - target.Value.position) < 2f) {
						Attack ();
//						//						return TaskStatus.Running;
						return TaskStatus.Running;
				}
				transform.position = Vector3.MoveTowards (transform.position, target.Value.position, speed * Time.deltaTime);
				return TaskStatus.Running;
		}

		public void Attack ()
		{
				iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", -180, "time", 0.5f));
				StartCoroutine (coRoutine ());
		}
	
		public void RotateBackAgain ()
		{
				MonoBehaviour.print ("working in rotation back");
				iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", -1, "time", 0.25f));
				
		}

		IEnumerator coRoutine ()
		{
				yield return new WaitForSeconds (0.1f);
				iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", -1, "time", 0.1f));
				//this.gameObject.collider2D.enabled = false;
				//iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", -1, "time", 0.5f, "oncomplete","BackHandRotationComplete","oncompletetarget",this.gameObject));
		
		}



		
}
