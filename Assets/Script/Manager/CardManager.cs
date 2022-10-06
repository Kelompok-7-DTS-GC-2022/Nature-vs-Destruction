using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Team7.Nature.SO;

public class CardManager : MonoBehaviour
{
    [Header("Holder Parameter")]
    public PlayerScriptableObject[] plantSO;
    public int amountHolder;
    public GameObject holderPrefab;
    public Transform holderTransform;

    [Header("Plant Holder")]
    public GameObject[] holderPlants;
    public int cost;
    public Texture iconPlant;

    private void Start()
    {
        
        amountHolder = plantSO.Length;
        holderPlants = new GameObject[amountHolder];
        for (int i = 0; i < amountHolder; i++)
        {
            AddPlantHolder(i);
        }
    }

    public void AddPlantHolder(int index)
    {
        GameObject holder = Instantiate(holderPrefab, holderTransform);
        PlantingManager plantingmanager = holder.GetComponent<PlantingManager>();
        //Getting Planting Prefab
        plantingmanager.PlantSo = plantSO[index];
        plantingmanager.PlantPrefab = plantSO[index].prefabPlant;
        plantingmanager.CooldownTime = plantSO[index].cooldownPlant;
        plantingmanager.TotalPlantGrow = plantSO[index].growPlant;
        holderPlants[index] = holder;
        iconPlant = plantSO[index].iconPlant;
        cost = plantSO[index].costPlant;
        holder.GetComponentInChildren<RawImage>().texture = iconPlant;
        holder.GetComponentInChildren<TMP_Text>().text = "" + cost;
    }
}
