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
    public InitialConditionConf initialPlantData;

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
        SpawnPlantInitialData();
    }


    public void SpawnPlantInitialData()
    {
        initialPlantData.plants.ForEach(plantss =>
        {
            var plantData = Instantiate(plantss, plantss.transform.position, plantss.transform.rotation);
            plantData.transform.parent = transform;
            plants.Add(plantData);
            print(plantData.GetComponent<PlantController>().getGrowArea());
            GameplayManager.Instance.AddPlantGrow(plantData.GetComponent<PlantController>().getGrowArea());
        });
    }

}
