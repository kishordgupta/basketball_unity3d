using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour
{
		
//		public Transform target;
	public GameObject rotateObject;

		
		
		void Start ()
		{
			
				//iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", -180, "time", 2f, "oncomplete", "RotateBack"));
		}

		void RotateBack ()
		{

					iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z",-1,"time",0.25f));
					

		}
	
		public static Vector3 RotatePointAroundPivot (Vector3 point, Vector3 pivot, Quaternion angle)
		{

				return angle * (point - pivot) + pivot;

		}
		// Update is called once per frame
		void Update ()
		{
	
				#if UNITY_EDITOR || UNITY_WEBPLAYER
						if (Input.GetButtonDown ("Fire1")) {
							
				//iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", -180, "time", 0.5f, "oncomplete", "RotateBack"));
				//iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", 0, "time", 0.5f, "oncomplete", "RotateBack"));
								

						
						}
				#endif

				#if UNITY_ANDROID || UNITY_IPHONE
						if (CFInput.GetButtonDown ("Fire1")) {
								this.gameObject.tag="Hand";
								iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z",- 180, "time", 0.5f));
								StartCoroutine(coRoutine());
							
							
						}
				#endif
		}

	IEnumerator coRoutine()
	{
		yield return new WaitForSeconds(0.1f);
		this.gameObject.collider2D.enabled = false;
		iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", -1, "time", 1.5f, "oncomplete","BackHandRotationComplete","oncompletetarget",this.gameObject));

	}
	void BackHandRotationComplete()
	{
		this.gameObject.collider2D.enabled = true;
		this.gameObject.tag="HandIdle";
		print("bAckHand");
	}
}

public static class RotateAroundPivotExtensions
{
		//Returns the rotated Vector3 using a Quaterion
		public static Vector3 RotateAroundPivot (this Vector3 Point, Vector3 Pivot, Quaternion Angle)
		{
				return Angle * (Point - Pivot) + Pivot;
		}
		//Returns the rotated Vector3 using Euler
		public static Vector3 RotateAroundPivot (this Vector3 Point, Vector3 Pivot, Vector3 Euler)
		{
				return RotateAroundPivot (Point, Pivot, Quaternion.Euler (Euler));
		}
		//Rotates the Transform's position using a Quaterion
		public static void RotateAroundPivot (this Transform Me, Vector3 Pivot, Quaternion Angle)
		{
				Me.position = Me.position.RotateAroundPivot (Pivot, Angle);
		}
		//Rotates the Transform's position using Euler
		public static void RotateAroundPivot (this Transform Me, Vector3 Pivot, Vector3 Euler)
		{
				Me.position = Me.position.RotateAroundPivot (Pivot, Quaternion.Euler (Euler));
		}
}



/*USAGE:
 *
 * myGameObject.transform.RotateAroundPivot(CenterAsVector3, AngleAsVector3); //Modifies the Transform (immediate rotation)
 * myGameObject.transform.position.RotateAroundPivot(CenterAsVector3, AngleAsVector3); //Returns the rotated position (preview rotation)
 *
 */