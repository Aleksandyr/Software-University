using UnityEngine;
using System.Collections;

public class RaycastShootingScript : MonoBehaviour
{
    public Transform Effect;
    public int BulletDammage = 100;
    public int Bullets = 50;
    public AudioClip Shoot;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
        if (Bullets > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Bullets--;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
                    hit.transform.SendMessage("ApplyDammage", BulletDammage, SendMessageOptions.DontRequireReceiver);
                }
            }   
        }
        else
        {
            audio.volume = 0;
        }
    }
}
