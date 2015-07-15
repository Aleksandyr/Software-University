using UnityEngine;
using System.Collections;

public class AirPlaneScript : MonoBehaviour 
{
    public GuiManager guiManager;
    float moveSpeed = 0.05f;
    float zMax = 5f;
    float zMin = -1.8f;
    float xMin = 0.88f;
    float xMax = 7.77f;
    float yCoordinate = 4.43f;
    Camera planeCamera;
    float planeRotateTime = 1f;
    float planeReturnRotationSpeed = 0f;
    float planeReturnDampTime = 0.2f;
    public int score;
    public bool isAlive;
    public Transform rotor;
    float rotorSpeed = 1000f;
    float gameTime;

	// Use this for initialization
	void Start ()
    {
        isAlive = true;
        score = PlayerPrefs.GetInt("Score", 0);
        guiManager.scoreLbl.text = string.Format("Score : {0}", score.ToString());
        planeCamera = Camera.main;
        rotor = transform.FindChild("Rotor");
        gameTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isAlive)
        {
            ManageInput();
            ManageLimitations();
            rotor.Rotate(0f, rotorSpeed * Time.deltaTime, 0f);
            ManageSensitivity();
        }
	}

    void ManageInput()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalAxis * moveSpeed, 0f, verticalAxis * moveSpeed);

        if (horizontalAxis > 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, -90f, ref planeReturnRotationSpeed, planeRotateTime));
        }
        else if (horizontalAxis < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, 90f, ref planeReturnRotationSpeed, planeRotateTime));
        }
        else if (transform.rotation.eulerAngles != Vector3.zero)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, 0f, ref planeReturnRotationSpeed, planeReturnDampTime));
        }

    }

    void ManageLimitations()
    {
        float planeToViewPort_Y = planeCamera.WorldToViewportPoint(transform.position).y;
        float zDistance = Mathf.Abs((planeCamera.transform.position - transform.position).z);
        xMin = planeCamera.ViewportToWorldPoint(new Vector3(0f, planeToViewPort_Y, zDistance)).x;
        xMax = planeCamera.ViewportToWorldPoint(new Vector3(1f, planeToViewPort_Y, zDistance)).x;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), yCoordinate, Mathf.Clamp(transform.position.z, zMin, zMax));
    }

    void ManageSensitivity()
    {
        if (Time.timeSinceLevelLoad > (gameTime + 15))
        {
            gameTime += 15;
            moveSpeed += 0.01f;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            CrashPlane();
        }
        else if (col.tag == "Coin")
        {
            audio.Play();
            col.gameObject.SetActive(false);
            score++;
            guiManager.scoreLbl.text = string.Format("Score : {0}", score.ToString());
            PlayerPrefs.SetInt("Score", score);
        }
    }

    void CrashPlane()
    {
        isAlive = false;
        rigidbody.isKinematic = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).rigidbody.isKinematic = false;
        }

        guiManager.ShowDeadText();
    }
}
