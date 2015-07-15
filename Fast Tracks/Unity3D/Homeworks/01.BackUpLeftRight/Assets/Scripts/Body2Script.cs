using UnityEngine;
using System.Collections;

public class Body2Script : GeneralScript {

	public GeneralScript aim2;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		speed = aim2.speed * 0.85f;
		
		transform.LookAt (aim2.transform.position);
		
		isMove = false;
		float dist = Vector3.Distance (transform.position, aim2.transform.position);
		if(dist > 1f)
		{
			transform.Translate(0f, 0f, speed * Time.deltaTime);
			isMove = true;
		}
		else if(dist < 1f * 0.8f)
		{
			transform.Translate(0f, 0f, -speed * Time.deltaTime);
			isMove = true;
		}
	}
}
