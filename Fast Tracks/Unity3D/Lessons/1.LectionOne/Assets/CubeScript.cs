using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour 
{
	float timer = 2f;
	bool isMoving;
	public Transform camera;
	public Transform sphere;


	void Awake () 
	{
		Debug.Log ("Awake");
	}
	
	// Update is called once per frame
	void Update () 
	{	
		transform.LookAt (sphere.position);
		Quaternion rotation = Quaternion.Euler (0f, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
		transform.localRotation = rotation;
	}




}
