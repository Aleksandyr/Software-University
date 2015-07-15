using UnityEngine;
using System.Collections;

public class RocketEngine : MonoBehaviour
{
    float TimeOut = 3;
    float Speed = 10;

    void Start()
    {

    }

    void Update()
    {
        transform.position += this.transform.forward * (Time.deltaTime * Speed);

        TimeOut -= Time.deltaTime;
        if (TimeOut <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
