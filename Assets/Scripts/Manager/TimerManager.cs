using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class TimerManager : MonoBehaviour
{
    [Header("Timer Manager")]
    private float _timerEnd;
    [SerializeField] private TextMeshProUGUI _timerDisplay;
    [SerializeField] private float _timerStart;
    // Start is called before the first frame update
    void Start()
    {
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
            return;
        }
        else
        {
            if (GameManager.Instance.PlantAreaGrow > GameManager.Instance.EnemyArea || GameManager.Instance.PlantAreaGrow == 100)
            {
                // Debug.Log("WIN");
                //Todo : Game State Win & Pop Up
            }
            else
            {
                Debug.Log("Lose");
                //Todo : Game State Lose & Pop Up
            }
        }
    }
}
