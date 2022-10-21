using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Scripting;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance;

    [Header("Holder Parameter")]
    public InitialConditionConf initialPlantData;

    [SerializeField]
    public List<GameObject> plants;

    public List<GameObject> getPlantList() => plants;

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
            GameplayManager.Instance.AddPlantGrow(plantData.GetComponent<PlantController>().getGrowArea());
        });
    }

}
