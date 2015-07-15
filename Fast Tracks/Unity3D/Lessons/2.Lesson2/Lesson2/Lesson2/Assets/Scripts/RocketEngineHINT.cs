using UnityEngine;
using System.Collections;

public class RocketEngineHINT : MonoBehaviour {


    float TimeOut = 3;
    float Speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += this.transform.forward * (Time.deltaTime * Speed);
        
        TimeOut -= Time.deltaTime;
        if (TimeOut <= 0f)
        {
            Destroy(this.gameObject);
        }
	}



}
