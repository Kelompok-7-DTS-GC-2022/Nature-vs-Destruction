using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Scripting;

public class PlantManager : MonoBehaviour
{

    private static PlantManager instance = null;
    public static PlantManager Instance;

    [Header("Holder Parameter")]
    public PlayerScriptableObject[] plantSO;
    public int amountHolder;
    public GameObject holderPrefab;
    public Transform holderTransform;

    [Header("Plant Holder")]
    // public GameObject[] holderPlants;
    public int cost;
    public Texture iconPlant;

    [SerializeField]
    public List<GameObject> plants;

    public List<GameObject> getPlantList() => plants;


    private float plusZ = 17f;
    private float plusX = 20f;
    private float xPosleft = -10f;
    private float lastZPos = -60f;
    private float lastXPos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        // amountHolder = plantSO.Length;
        // holderPlants = new GameObject[amountHolder];
        // for (int i = 0; i < amountHolder; i++)
        // {
        //     AddPlantHolder(i);
        // }
    }

    // public void AddPlantHolder(int index)
    // {
    //     GameObject holder = Instantiate(holderPrefab, holderTransform);
    //     PlantingController plantingmanager = holder.GetComponent<PlantingController>();
    //     //Getting Planting Prefab
    //     plantingmanager.PlantSo = plantSO[index];
    //     plantingmanager.PlantPrefab = plantSO[index].prefabPlant;
    //     plantingmanager.CooldownTime = plantSO[index].cooldownPlant;
    //     plantingmanager.growSize = plantSO[index].growPlant;
    //     holderPlants[index] = holder;
    //     iconPlant = plantSO[index].iconPlant;
    //     cost = plantSO[index].costPlant;
    //     holder.GetComponentInChildren<RawImage>().texture = iconPlant;
    //     holder.GetComponentInChildren<TMP_Text>().text = "" + cost;
    // }


    // public void SpawnPlant()
    // {
    //     GameObject _plantBeringin = PlantPrefab[Random.Range(0, PlantPrefab.Count)];
    //     plusX = Random.Range(-3f, 35f);
    //     float zPos = lastZPos + plusZ;
    //     float xPos = lastXPos + plusX;

    //     Instantiate(_plantBeringin, new Vector3(Random.Range(-10f, 20f), 0f, zPos), _plantBeringin.transform.rotation);
    //     lastZPos += plusZ;
    //     lastXPos += plusX;
    // }

}
