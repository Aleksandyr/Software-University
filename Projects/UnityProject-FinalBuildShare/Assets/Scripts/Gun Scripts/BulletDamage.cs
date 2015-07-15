using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour
{
    public float Dammage = 100;

    void OnCollisionEnter(Collision info)
    {
        info.transform.SendMessage("ApplyDammage", Dammage, SendMessageOptions.DontRequireReceiver);
    }
}
