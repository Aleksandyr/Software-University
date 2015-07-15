using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSceneScript : MonoBehaviour 
{
    public void OnPlayGame()
    {
        Application.LoadLevelAsync("GameScene");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
