using UnityEngine;
using System.Collections;

public class BulletEngine : MonoBehaviour
{
    float timeOut = 5;
    float speed = 10;

    void Start()
    {

    }


    void Update()
    {
        transform.position += this.transform.forward * (Time.deltaTime * speed);
   
        timeOut -= Time.deltaTime;
        if (timeOut <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
