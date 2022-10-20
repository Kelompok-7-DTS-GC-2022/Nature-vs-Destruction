using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Toggle _bGM;
    [SerializeField] Toggle _sFX;
    private void Start()
    {

        LoadBGMnSFX();
    }
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
    void LoadBGMnSFX()
    {
        if (PlayerPrefs.HasKey("BGM"))
        {
            int setOn = PlayerPrefs.GetInt("BGM");
            _bGM.isOn = setOn == 1 ? true : false;
        }
        if (PlayerPrefs.HasKey("SFX"))
        {
            int setOn = PlayerPrefs.GetInt("SFX");
            _sFX.isOn = setOn == 1 ? true : false;
        }
    }
}
