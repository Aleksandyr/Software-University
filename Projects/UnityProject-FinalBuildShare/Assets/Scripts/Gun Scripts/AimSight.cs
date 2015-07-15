using UnityEngine;
using System.Collections;

public class AimSight : MonoBehaviour
{
    public bool aim = false;
    public GameObject cam;

    void Start()
    {
        cam.active = false;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aim = true;
            if (aim == true)
            {
                cam.active = true;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            aim = true;
            if (aim)
            {
                cam.active = false;
            }
        }
    }
}
