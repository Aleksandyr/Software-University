using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Target : MonoBehaviour {

	public Text ScoresTxt;
	Vector3 startPos;
	Vector3 endPos;
	float timer = 0;
	int Score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position =  Vector3.Lerp (startPos, endPos, timer);

		timer += Time.deltaTime;

		if (timer >= 1f) {
			NewCoords();

		}

	}


	void NewCoords() {
		startPos = transform.position;
		endPos = new Vector3 (Random.Range (-10f, 10), Random.Range (3, 10), -10);
		timer = 0;
	}

	void OnTriggerEnter(Collider other)
	{
		NewCoords();
		Score++;

		ScoresTxt.text = "Score: " + Score.ToString ();
	}


}
