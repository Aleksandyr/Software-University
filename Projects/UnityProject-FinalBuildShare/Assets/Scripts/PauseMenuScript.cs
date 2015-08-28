using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

    private int buttonWidth = 200;
    private int buttonHeight = 50;
    private int groupWidth = 200;
    private int groupHeight = 170;

    private bool paused = false;

    private Texture2D image;
    private Texture2D backgroundHoverImage;
    public GUIContent content;
	// Use this for initialization
	void Start () {
        //Screen.showCursor = true;

        image = (Texture2D)Resources.Load("button");
        backgroundHoverImage = (Texture2D)Resources.Load("hover");
        content.image = image;
        content.image = backgroundHoverImage;
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.isPlaying)
        {
            Cursor.visible = false;
        }
      
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            paused = !paused;
            
        }
        if (paused)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
        }
	}
    void OnGUI()
    {

        if (paused)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 26;
            Font myFont = (Font)Resources.Load("Fonts/youmurdererbb_reg", typeof(Font));
            buttonStyle.font = myFont;
            buttonStyle.normal.background = image;
            buttonStyle.hover.background = backgroundHoverImage;
            GUI.backgroundColor = Color.red;

            GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidth, groupHeight));

            if (GUI.Button(new Rect(0, 0, buttonWidth, buttonHeight), "Main Menu", buttonStyle))
            {
                Application.LoadLevel("MenuScene");
            }
            //if (GUI.Button(new Rect(0, 60, buttonWidth, buttonHeight), "New Game", buttonStyle))
            //{
            //    Application.LoadLevel("Level1");
            //}
            if (GUI.Button(new Rect(0, 60, buttonWidth, buttonHeight), "Save Game", buttonStyle))
            {
                //Application.LoadLevel("LoadSaveMenu");
            }
            if (GUI.Button(new Rect(0, 120, buttonWidth, buttonHeight), "Quit Game", buttonStyle))
            {
                //Application.Quit();
            }
            GUI.EndGroup();

        }
    }
}
