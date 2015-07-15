using UnityEngine;
using System.Collections;

public class MainLogic : MonoBehaviour {



	GameObject Cannon;
	GameObject[] Weapons;

	GameObject Rocket;


	GameObject Darts;

	// Use this for initialization
	void Start () {
		Cannon = GameObject.Find ("Cannon");
		Darts = GameObject.Find ("Darts");

		Rocket = (GameObject) Resources.Load ("Rocket");

		Weapons = GameObject.FindGameObjectsWithTag ("Weapons");
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mouse = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 30);

		Vector3 pos = camera.ScreenToWorldPoint (mouse);


		Cannon.transform.LookAt (pos);
		Cannon.transform.eulerAngles = new Vector3 (0, Cannon.transform.eulerAngles.y - 180f, 0);


		foreach (GameObject go in Weapons) {

			go.transform.LookAt (pos);
			
			go.transform.localRotation = Quaternion.Euler(new Vector3(309.65f, 54.02f, go.transform.eulerAngles.x));

		}

		if (Input.GetMouseButtonDown(0)) {

			//GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
			//go.transform.position = pos;
			//go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);


			Instantiate(Rocket);
			Rocket.transform.position = Cannon.transform.position;
			Rocket.transform.LookAt(Darts.transform.position);
		}


	}
}
