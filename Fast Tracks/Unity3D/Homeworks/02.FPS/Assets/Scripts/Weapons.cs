using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour
{
    GameObject Rocket;
    GameObject Player;
    float Timer = 1;

    void Start()
    {
        Player = GameObject.Find("Player");
        Rocket = (GameObject)Resources.Load("Rocket");
    }

    void Update()
    {
        transform.LookAt(Player.transform.position);
        transform.eulerAngles = (new Vector3(0f, transform.eulerAngles.y - 180f, 0f));

        float dist = Vector3.Distance(transform.position, Player.transform.position);
        if (dist <= 25)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Instantiate(Rocket);
                Rocket.transform.position = transform.position;
                Rocket.transform.LookAt(Player.transform.position);
                Timer = 1;
            }
        }
    }
}
