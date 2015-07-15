﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiManager : MonoBehaviour 
{
    public GameObject playerDeadLbl;
    public Text scoreLbl;

    public void OnHomeClicked()
    {
        Application.LoadLevelAsync("MenuScene");
    }

    public void OnResetLevelClicked()
    {
        Application.LoadLevelAsync(Application.loadedLevelName);
    }

    public void ShowDeadText()
    {
        playerDeadLbl.SetActive(true);
    }

    public void OnClearScoreClicked()
    {
        PlayerPrefs.DeleteAll();
        GameObject.FindObjectOfType<AirPlaneScript>().score = 0;
        scoreLbl.text = string.Format("Score : {0}", 0);
    }
}
