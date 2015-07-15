using UnityEngine;
using System.Collections;

public class HeadScript : GeneralScript {
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.UpArrow)) 
		{
			transform.Translate(0f, 0f, speed * Time.deltaTime);
			isMove = true;
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(0f, 0f, -speed * Time.deltaTime);
			isMove = true;
		}
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-speed * Time.deltaTime, 0f, 0f);
			isMove = true;
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(speed * Time.deltaTime, 0f, 0f);
			isMove = true;
		}
		else if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(0f, speed * Time.deltaTime, 0f);
			isMove = true;
		}
		else if(Input.GetKey(KeyCode.Z))
		{
			transform.Translate(0f, -speed * Time.deltaTime, 0f);
			isMove = true;
		}
		else 
		{
			isMove = false;			
		}
	}
}
