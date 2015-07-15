using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{
    public float speedKoef = 0.5f;
    public float mouseSpeedX = 1f;
    public float mouseSpeedY = 1f;
    public float jumpForce = 1f;
    public float gravityInAir = 40f;
    public float normalGravity = 9.8f;
    public float maxMovingSpeed = 20;
    public float dampTime = 5;
    public bool isGrounded;
    private float mouseLookVertical;
    private float mouseLookHorizontal;
    private float dampVolumeX;
    private float dampVolumeZ;
    Camera playerCamera;
    private Vector2 movementVector;
    GameObject Bullet;

    private void Start()
    {
        playerCamera = Camera.main;
        Physics.gravity = -Vector3.up * normalGravity;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Input.GetAxis("Horizontal") * speedKoef, 0f, Input.GetAxis("Vertical") * speedKoef);
        movementVector = new Vector2(rigidbody.velocity.x, rigidbody.velocity.z);

        if (movementVector.magnitude > maxMovingSpeed)
        {
            movementVector.Normalize();
            movementVector *= maxMovingSpeed;
        }

        rigidbody.velocity = new Vector3(movementVector.x, rigidbody.velocity.y, movementVector.y);

        rigidbody.AddRelativeForce(Input.GetAxis("Horizontal") * speedKoef, 0f, Input.GetAxis("Vertical") * speedKoef, ForceMode.Force);

        if (Input.GetAxis("Horizontal") == 0f && isGrounded)
        {
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, Mathf.SmoothDamp(rigidbody.velocity.z, 0f, ref dampVolumeZ, dampTime));
        }

		if (Input.GetAxis("Vertical") == 0f && isGrounded)
		{
			rigidbody.velocity = new Vector3(Mathf.SmoothDamp(rigidbody.velocity.x, 0f, ref dampVolumeX, dampTime), rigidbody.velocity.y, rigidbody.velocity.z);
		}

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        mouseLookVertical = playerCamera.transform.localRotation.eulerAngles.x - (Input.GetAxis("Mouse Y") * mouseSpeedX);
        mouseLookHorizontal = transform.rotation.eulerAngles.y + (Input.GetAxis("Mouse X") * mouseSpeedY);

        if (mouseLookVertical <= 300 && mouseLookVertical >= 40)
            return;


        transform.localRotation = Quaternion.Euler(0f, mouseLookHorizontal, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(mouseLookVertical, 0f, 0f);


    }

    private void Jump()
    {
        Debug.Log("Jump");
        if (!isGrounded)
            return;

        rigidbody.AddForce(Vector3.up * jumpForce);
        isGrounded = false;
        SetGravity(2);
    }

    /// <summary>
    /// type = 1 means normal gravity ; type = 2 means gravity in air
    /// </summary>
    /// <param name="type"></param>
    private void SetGravity(int type)
    {
        Physics.gravity = -Vector3.up * (type == 1 ? normalGravity : gravityInAir);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Floor" && !isGrounded)
        {
            isGrounded = true;

            if (Physics.gravity != Vector3.up * normalGravity)
            {
                SetGravity(1);
            }
        }
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Floor" && !isGrounded)
        {
            isGrounded = true;
            SetGravity(1);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Floor" && isGrounded)
        {
            isGrounded = false;
            SetGravity(2);
        }
    }
}
