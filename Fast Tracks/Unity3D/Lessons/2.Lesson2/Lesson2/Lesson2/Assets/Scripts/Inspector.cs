using UnityEngine;
using System.Collections;

public class Inspector : MonoBehaviour {



    GameObject[] Player;
    GameObject[] Enemy;


	// Use this for initialization
	void Start () {
        //Player = GameObject.FindGameObjectsWithTag("Player");
        //Enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //Debug.Log("Player.Length: " + Player.Length.ToString());
        //Debug.Log("Enemy.Length: " + Enemy.Length.ToString());


		GameObject go = Resources.Load ("Sphere") as GameObject;

		Instantiate (go);
		go.transform.position = Vector3.zero;



	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject go in Enemy)
        {
            go.transform.Translate(Vector3.forward * Time.deltaTime);
        }
	}
}
