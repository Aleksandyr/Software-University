using UnityEngine;
using System.Collections;

public class WeaponRotationHINT : MonoBehaviour {


    Camera mainCamera;


    public bool ToShoot;

    public GameObject Rocket;


    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {



            Vector3 posToFace = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 23));

			transform.LookAt(posToFace);
				
			transform.localRotation = Quaternion.Euler(new Vector3(309.65f, 54.02f, transform.eulerAngles.x));


            if (Input.GetMouseButtonDown(0) && ToShoot)
            {
                //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //go.transform.position = posToFace;
                //go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                GameObject go = (GameObject)Instantiate(Rocket);
                go.transform.position = this.transform.position;
                go.transform.LookAt(posToFace);


                go.AddComponent<RocketEngineHINT>();
                

            }

    }
}
