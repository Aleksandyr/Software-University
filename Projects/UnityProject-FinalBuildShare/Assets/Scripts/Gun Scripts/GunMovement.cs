using UnityEngine;
using System.Collections;

public class GunMovement : MonoBehaviour
{
    public float moveAmount = 1;
    public float moveSpeed = 2;
    public GameObject gun;
    public float moveOnX;
    public float moveOnY;
    public Vector3 defaultPos;
    public Vector3 newGunPos;

    void Start()
    {
        defaultPos = transform.localPosition;
    }


    void Update()
    {
        moveOnX = Input.GetAxis("Mouse X") * Time.deltaTime * moveAmount;
        moveOnY = Input.GetAxis("Mouse Y") * Time.deltaTime * moveAmount;

        newGunPos = new Vector3(defaultPos.x + moveOnX, defaultPos.y + moveOnY, defaultPos.z);

        gun.transform.localPosition = Vector3.Lerp(gun.transform.localPosition, newGunPos, moveSpeed * Time.deltaTime);
    }
}
