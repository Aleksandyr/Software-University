using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class LoadSave : MonoBehaviour {
    public Button backButton;
	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        if (backButton == null)
        {
            return;
        }


        backButton.onClick.AddListener(CallBackButton);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void CallBackButton()
    {

        //Application.LoadLevel("MenuScene");
    }
}
