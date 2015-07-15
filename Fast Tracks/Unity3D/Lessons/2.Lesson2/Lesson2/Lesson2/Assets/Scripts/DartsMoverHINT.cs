using UnityEngine;
using System.Collections;

public class DartsMoverHINT : MonoBehaviour {


    int Score = 0;

    Vector3 NewPos;
    Vector3 StartPos;
    float progress = 0f;

	// Use this for initialization
	void Start () {
        NewCoords();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(StartPos, NewPos, progress);

        progress += Time.deltaTime * (0.5f + (Score / 10));

        if (progress >= 1f)
        {
            NewCoords();
        }

	}


    void NewCoords()
    {
        StartPos = transform.position;
        NewPos = new Vector3(Random.Range(-6.5f, 6f), Random.Range(4f, 16f), 11f);
        progress = 0f;
    }


    void OnTriggerEnter(Collider other)
    {
        NewCoords();
        Score++;
        Debug.Log("Score: " + Score.ToString());
    }


}
