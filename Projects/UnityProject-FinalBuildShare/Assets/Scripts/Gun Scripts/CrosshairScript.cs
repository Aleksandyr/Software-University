using UnityEngine;
using System.Collections;

public class CrosshairScript : MonoBehaviour
{
    public Texture2D crossHair;

    void Start()
    {

    }

    void OnGUI()
    {
        float w = crossHair.width / 6;
        float h = crossHair.width / 6;
        Rect position = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);

        if (!Input.GetButton("Fire2"))
        {
            GUI.DrawTexture(position, crossHair);
        }
    }

    void Update()
    {

    }
}
