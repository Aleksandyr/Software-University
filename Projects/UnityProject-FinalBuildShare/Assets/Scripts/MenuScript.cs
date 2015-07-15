using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuScript : MonoBehaviour {


	public Button playButton;
	public Button quiteButton;
    public Button loadButton;

	// Use this for initialization
	void Start () {

        Screen.showCursor = true;

		if (playButton == null || quiteButton == null || loadButton == null)
		{
			return;
		}
		
		
		playButton.onClick.AddListener(CallPlayButton);
		quiteButton.onClick.AddListener(CallQuitButton);
        loadButton.onClick.AddListener(LoadButton);
	
	    
	}
	
	// Update is called once per frame
	void Update () {


	}
    public void CallPlayButton()
	{
        
		Application.LoadLevel ("Level1");
	}
    public void LoadButton()
    {
        //Application.LoadLevel("LoadSaveMenu");
    }
	public void CallQuitButton()
	{
        //Application.Quit();
	}
}
