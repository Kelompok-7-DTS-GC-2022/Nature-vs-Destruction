using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum GameState
{
    Ready,
    Start,
    GameOver,
    Win
}
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance { get { if (instance == null) instance = FindObjectOfType<GameManager>(); return instance; } }
    [Header("Area Manager")]
    public float PlantArea;
    [SerializeField] private float _startAreaGrow;
    public float PlantAreaGrow;
    [SerializeField] private float _startEnemyArea;
    public float EnemyArea;
    public float TotalPlantArea;



    [Header("GameState")]
    [SerializeField]
    private GameState gameState;
    public GameState GameState
    {
        get => gameState;
        set => gameState = value;
    }
    void Start()
    {

        instance = this;
        PlantAreaGrow = _startAreaGrow;
        EnemyArea = _startEnemyArea;

    }
    void Update()
    {

    }

    public void AddPlantGrow(float _plantarea)
    {
        PlantAreaGrow += _plantarea;
        EnemyArea -= _plantarea;
    }
    public void RemoveGrowPlant(float _plantarea)
    {
        PlantAreaGrow -= _plantarea;
        EnemyArea += _plantarea;
    }
}
