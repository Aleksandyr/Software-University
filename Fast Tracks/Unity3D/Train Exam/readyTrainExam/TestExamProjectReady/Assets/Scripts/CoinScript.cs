using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour
{

    float resetCoordinate_Z = -20.44f;
    float speed = -5f;
    float rotateSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.InverseTransformDirection(Vector3.forward) * speed * Time.deltaTime);

        if (transform.position.z < resetCoordinate_Z)
        {
            gameObject.SetActive(false);
        }

        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
