using UnityEngine;
using System.Collections;

public class Body1Script : GeneralScript {
	
	public GeneralScript aim1;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		speed = aim1.speed * 0.75f;

		transform.LookAt (aim1.transform.position);

		isMove = false;
		float dist = Vector3.Distance (transform.position, aim1.transform.position);
		if(dist > 1.5f)
		{
			transform.Translate(0f, 0f, speed * Time.deltaTime);
			isMove = true;
		}
		else if(dist < 1.5f * 0.8f)
		{
			transform.Translate(0f, 0f, -speed * Time.deltaTime);
			isMove = true;
		}
	}
}
