using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text LivesTxt;
    float speed = 2f;
    Camera MainCam;
    int Lives = 5;
    // Use this for initialization
    void Start()
    {
        MainCam = (Camera)GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard move
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, -speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }

        //Mose move
        float horizontal = 3.0f * Input.GetAxis("Mouse X");
        float vertical = 3.0f * Input.GetAxis("Mouse Y");
        transform.Rotate(0f, horizontal, 0f);
        MainCam.transform.Rotate(-vertical, 0f, 0f);

        if (Lives == 0)
        {
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Lives--;
        LivesTxt.text = "Lives: " + Lives.ToString();
    }
}
