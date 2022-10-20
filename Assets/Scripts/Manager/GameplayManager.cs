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
public class GameplayManager : MonoBehaviour
{
    private static GameplayManager instance = null;
    public static GameplayManager Instance { get { if (instance == null) instance = FindObjectOfType<GameplayManager>(); return instance; } }
    [Header("Area Manager")]

    [SerializeField] private float _startAreaGrow;
    public float PlantAreaGrow;
    public float plantAreaPercentage;
    [SerializeField] private float _startEnemyArea;
    public Collider terrainReference;
    public Slider sliderProgress;
    public float terrainSize;




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
        terrainSize = terrainReference.bounds.size.x * terrainReference.bounds.size.x;
    }
    void Update()
    {
        calculateArea();
    }

    public void AddPlantGrow(float _plantarea)
    {
        PlantAreaGrow += _plantarea;
    }
    public void RemoveGrowPlant(float _plantarea)
    {
        PlantAreaGrow -= _plantarea;
    }

    void calculateArea()
    {
        plantAreaPercentage = (PlantAreaGrow / terrainSize) * 100;
        sliderProgress.value = plantAreaPercentage;
    }
}
