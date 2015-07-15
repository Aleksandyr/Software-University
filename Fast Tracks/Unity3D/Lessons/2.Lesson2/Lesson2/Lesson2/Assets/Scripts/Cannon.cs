using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {


	Camera MainCam;



	// Use this for initialization
	void Start () {
		MainCam = (Camera) GameObject.Find ("Main Camera").GetComponent<Camera>();


	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = MainCam.ScreenToWorldPoint ( new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

		transform.LookAt (pos);

		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y - 180f, 0);

	
	}
}
 