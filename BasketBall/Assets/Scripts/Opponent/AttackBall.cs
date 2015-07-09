using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class AttackBall : Conditional
{

		public SharedTransform target;
		public Transform opponentHand;
		
//		public SharedTransform target;
//
		public override TaskStatus OnUpdate ()
		{
			
				if (Vector3.SqrMagnitude (transform.position - target.Value.position) < 4f) {
	
						Attack ();
						return TaskStatus.Success;
						
				}
//
				return TaskStatus.Running;
		}

		public void Attack ()
		{
		iTween.RotateTo (opponentHand.gameObject, iTween.Hash ("z", -180, "time", 0.5f, "oncomplete", "RotateBack","oncompletetarget",opponentHand.gameObject));
		}
	
		public void RotateBack ()
		{
				iTween.RotateTo (opponentHand.gameObject, iTween.Hash ("z", -1, "time", 1f));
		}
		
}
