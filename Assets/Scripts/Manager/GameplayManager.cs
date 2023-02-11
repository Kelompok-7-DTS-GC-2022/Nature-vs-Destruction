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
    public static GameplayManager Instance;
    [Header("Area Manager")]

    [SerializeField] private float _startAreaGrow;
    public float PlantAreaGrow;
    public BoxCollider terrainReference;
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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        terrainSize = terrainReference.size.x * terrainReference.size.z;
        sliderProgress.maxValue = terrainSize;
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
        sliderProgress.value = PlantAreaGrow;
    }
}
