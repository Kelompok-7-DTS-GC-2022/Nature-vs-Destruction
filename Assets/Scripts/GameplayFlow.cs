using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayFlow : MonoBehaviour
{
    [SerializeField] Toggle _bGM;
    [SerializeField] Toggle _sFX;
    private void Start()
    {
        LoadBGMnSFX();
        Time.timeScale = 1;
    }
    private void Update()
    {
        print(PlayerPrefs.GetInt("BGM"));
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioManager.instance.PlayClick();
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        AudioManager.instance.PlayClick();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.PlayClick();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.PlayClick();
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
