using UnityEngine;
using System.Collections;

public class Body3Script : GeneralScript {

	public GeneralScript aim3;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		speed = aim3.speed * 0.95f;

		transform.LookAt (aim3.transform.position);

		float dist = Vector3.Distance (transform.position, aim3.transform.position);
		isMove = false;
		if(dist > 1f)
		{
			transform.Translate  (0f, 0f, speed * Time.deltaTime);
			isMove = true;
		}
		else if(dist < 1f * 0.8f)
		{
			transform.Translate(0f, 0f, -speed * Time.deltaTime);
            isMove = true;
		}
	}
}
