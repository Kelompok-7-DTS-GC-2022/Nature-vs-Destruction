using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ToggleSFX(bool isOn)
    {
        PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
    }
    public void ToggleBGM(bool isOn)
    {
        PlayerPrefs.SetInt("BGM", isOn ? 1 : 0);
    }
}
