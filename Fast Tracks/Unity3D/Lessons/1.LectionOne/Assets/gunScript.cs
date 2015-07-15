using UnityEngine;
using System.Collections;

public class gunScript : MonoBehaviour {

	public Transform target;
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (target.position);
		Quaternion rotation = Quaternion.Euler (transform.localRotation.eulerAngles.x, 0f, 0f);
		transform.localRotation = rotation;

        Debug.Log(Input.touchCount);

	}
}
