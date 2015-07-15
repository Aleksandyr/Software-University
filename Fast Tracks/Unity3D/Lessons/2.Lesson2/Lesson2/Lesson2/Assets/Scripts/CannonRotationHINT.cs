using UnityEngine;
using System.Collections;

public class CannonRotationHINT : MonoBehaviour {


    Camera mainCamera;


    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


	// Update is called once per frame
	void Update () {


        Vector3 posToFace = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        
        transform.LookAt(posToFace);
        
        transform.eulerAngles = new Vector3(0f, transform.localRotation.eulerAngles.y - 180f, 0f);
        

	}



}
