using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class TimerManager : MonoBehaviour
{
    private GameplayManager gameplayManager;
    [Header("Timer Manager")]
    private float _timerEnd;
    [SerializeField] private TextMeshProUGUI _timerDisplay;
    [SerializeField] private float _timerStart;
    public GameObject winPanel;
    public GameObject losePanel;
    void Start()
    {
        gameplayManager = GameplayManager.Instance;

        _timerEnd = _timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerEnd > 0)
        {
            _timerEnd -= Time.deltaTime;
            TimeSpan span = TimeSpan.FromSeconds(_timerEnd);
            _timerDisplay.text = span.ToString(@"mm\:ss");
            // return;
        }

        if (_timerEnd > 0 && gameplayManager.PlantAreaGrow >= gameplayManager.terrainSize)
        {
            // Debug.Log("WIN");
            //Todo : Game State Win & Pop Up
            winPanel.SetActive(true);
        }
        else
        {
            if (gameplayManager.PlantAreaGrow >= (gameplayManager.terrainSize * 0.6) || gameplayManager.PlantAreaGrow == gameplayManager.terrainSize)
            {
                // Debug.Log("WIN");
                //Todo : Game State Win & Pop Up
                winPanel.SetActive(true);
            }
            else
            {
                Debug.Log("Lose");
                //Todo : Game State Lose & Pop Up
                losePanel.SetActive(true);
            }
        }
    }
}
