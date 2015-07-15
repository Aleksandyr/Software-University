using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour 
{
    float resetDistance = 202f;
    float resetCoordinate_Z = -20.44f;
    public float speed = -5f;
    AirPlaneScript airPlaneScript;

    void Awake()
    {
        airPlaneScript = GameObject.Find("AirPlane").GetComponent<AirPlaneScript>();
    }

	// Update is called once per frame
	void Update () 
    {
        if (airPlaneScript.isAlive)
        {
            transform.Translate(transform.InverseTransformDirection(Vector3.forward) * speed * Time.deltaTime);
            if (transform.position.z <= resetCoordinate_Z)
            {
                transform.Translate(transform.InverseTransformDirection(Vector3.forward) * resetDistance);
            }
        }
	}
}
