using UnityEngine;
using System.Collections;

public class MuzzleFlashScript : MonoBehaviour
{
    ParticleEmitter muzzleFlash;
    float muzzleFlashTimer = 0.0f;
    float muzlleClone = 0.01f;
    GameObject MainCam;

    void Start()
    {
        muzzleFlash = GetComponent<ParticleEmitter>();
        muzzleFlash.emit = false;
    }

    void Update()
    {
        MainCam = GameObject.Find("Main Camera");
        RaycastShootingScript raycastScript = MainCam.GetComponent<RaycastShootingScript>();

        if (Input.GetMouseButtonDown(0))
        {
            muzzleFlashTimer = muzlleClone;
        }
        if (muzzleFlashTimer > 0 && raycastScript.Bullets > 0)
        {
            muzzleFlash.Emit();
        }
        else 
        {
            muzzleFlash.emit = false;
        }
        muzzleFlashTimer -= Time.deltaTime;
    }
}
