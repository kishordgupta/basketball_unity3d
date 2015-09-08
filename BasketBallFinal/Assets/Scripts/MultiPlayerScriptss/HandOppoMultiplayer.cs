using UnityEngine;
using System.Collections;

public class HandOppoMultiplayer : MonoBehaviour {

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
			if (networkView.isMine) {
			#if UNITY_EDITOR || UNITY_WEBPLAYER
			if (Input.GetButtonDown ("Fire1")) {
			
				//iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", -180, "time", 0.5f, "oncomplete", "RotateBack"));
				//iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", 0, "time", 0.5f, "oncomplete", "RotateBack"));
			
			
			
			}
			#endif
		
			#if UNITY_ANDROID || UNITY_IPHONE
			if (CFInput.GetButtonDown ("Fire1")) {
				this.gameObject.tag = "Hand";
				iTween.RotateTo (rotateObject.gameObject, iTween.Hash ("z", - 180, "time", 0.5f));
				StartCoroutine (coRoutine ());
			
			
			}
			#endif
		}
				
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
		//		print("bAckHand");
	}


	private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		// Serialize the position and color
		if (stream.isWriting) {
			Vector3 position = transform.position;
			stream.Serialize(ref position);
		} else {
			Vector3 position = Vector3.zero;
			
			stream.Serialize(ref position);
			transform.position = position;
		}
	}


}





public static class RotateAroundPivotExtensionsOppo
{
	//Returns the rotated Vector3 using a Quaterion
	public static Vector3 RotateAroundPivotOppo (this Vector3 Point, Vector3 Pivot, Quaternion Angle)
	{
		return Angle * (Point - Pivot) + Pivot;
	}
	//Returns the rotated Vector3 using Euler
	public static Vector3 RotateAroundPivotOppo (this Vector3 Point, Vector3 Pivot, Vector3 Euler)
	{
		return RotateAroundPivotOppo (Point, Pivot, Quaternion.Euler (Euler));
	}
	//Rotates the Transform's position using a Quaterion
	public static void RotateAroundPivotOppo (this Transform Me, Vector3 Pivot, Quaternion Angle)
	{
		Me.position = Me.position.RotateAroundPivotOppo (Pivot, Angle);
	}
	//Rotates the Transform's position using Euler
	public static void RotateAroundPivotOppo (this Transform Me, Vector3 Pivot, Vector3 Euler)
	{
		Me.position = Me.position.RotateAroundPivotOppo (Pivot, Quaternion.Euler (Euler));
	}
}
