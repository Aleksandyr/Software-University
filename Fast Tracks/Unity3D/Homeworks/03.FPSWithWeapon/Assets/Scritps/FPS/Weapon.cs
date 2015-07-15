using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    GameObject Bullet;

    void Start()
    {
        Bullet = (GameObject)Resources.Load("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Alpha1))
       // {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Bullet);
                Bullet.transform.position = transform.position;
            }
        //}
    }
}
