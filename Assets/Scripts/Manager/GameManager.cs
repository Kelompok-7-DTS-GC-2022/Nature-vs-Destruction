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
    public List<GameObject> PlantPrefab;
    private float plusZ = 17f; 
    private float plusX = 20f;
    private float xPosleft = -10f;
    private float lastZPos = -60f;
    private float lastXPos;


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
        //if (_startAreaGrow >= 30)
        //{
            //for (int i = 0; i < 4 ; i++)
            //{
               // SpawnPlant();
            //}
        //}

    }
    void Update()
    {

    }
    public void SpawnPlant()
    {
        GameObject _plantBeringin = PlantPrefab[Random.Range(0, PlantPrefab.Count)];
        plusX = Random.Range(-3f, 35f);
        float zPos = lastZPos + plusZ;
        float xPos = lastXPos + plusX;

        Instantiate(_plantBeringin, new Vector3(Random.Range(-10f, 20f), 0f, zPos), _plantBeringin.transform.rotation);
        lastZPos += plusZ;
        lastXPos += plusX;
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
