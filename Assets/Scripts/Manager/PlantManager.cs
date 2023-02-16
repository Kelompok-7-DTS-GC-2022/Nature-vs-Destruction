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
            var plantInitController = plantData.GetComponent<PlantController>();
            var checkIfNeighbour = plantData.GetComponent<CheckPlantPlacement>();
            checkIfNeighbour.hasNeighbour = true;
            checkIfNeighbour.canPlant = true;
            checkIfNeighbour.planted = true;
            checkIfNeighbour.tanahNormal();
            plantData.transform.parent = transform;
            plantData.gameObject.layer = LayerMask.NameToLayer("Plant");
            plantInitController.enabled = true;
            plantInitController.isPlanted = true;
            plantData.GetComponent<Collider>().isTrigger = false;
            plants.Add(plantData);
            GameplayManager.Instance.AddPlantGrow(plantInitController.getGrowArea());
        });
    }

}
