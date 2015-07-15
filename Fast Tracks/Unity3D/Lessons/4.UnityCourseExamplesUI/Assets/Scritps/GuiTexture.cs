using UnityEngine;
using System.Collections;

public class GuiTexture : MonoBehaviour 
{
    GUITexture attachedTexture;
    void Start()
    {
        attachedTexture = guiTexture;//GetComponent<GUITexture>();
    }
	// Update is called once per frame
	void Update () 
    {
        if (attachedTexture.HitTest(Input.mousePosition))
        {
            Debug.Log("Mouse over texture");
        }
	}
}
