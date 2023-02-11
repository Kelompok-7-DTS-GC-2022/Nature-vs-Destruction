using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlantingController : MonoBehaviour
{
    [Header("Cooldown Controller")]
    private bool isCooldown = false;
    public float CooldownTime;
    private float cooldownTimer;
    [SerializeField] private Image cooldownImage;

    [Header("Planting Controller")]
    public GameObject PlantPrefab;
    public GameObject PendingPlant;
    public PlayerScriptableObject PlantSo;
    private Vector3 pos;
    private RaycastHit hit;
    [SerializeField] public LayerMask layerMask;
    [Header("Grid Option")]
    private CheckPlantPlacement checker;
    private EnergyContainer energyContainer;

    private void Start()
    {
        cooldownImage.fillAmount = 0.0f;
        energyContainer = EnergyContainer.instance;
    }
    void Update()
    {
        if (PendingPlant != null)
        {
            var intX = Mathf.RoundToInt(pos.x);
            var intZ = Mathf.RoundToInt(pos.z);
            PendingPlant.transform.position = new Vector3(intX, pos.y, intZ);
            //UpdateMaterials();
            // print(checker.canPlant);
            if (Input.GetMouseButtonDown(0) && checker.canPlant)
            {
                PlacePlant();
            }
        }
        if (isCooldown)
        {
            PlantCooldown();
        }
    }
    public void PlantCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            cooldownImage.fillAmount = 0.0f;
        }
        else
        {
            cooldownImage.fillAmount = cooldownTimer / CooldownTime;
        }
    }

    void UpdateMaterials()
    {
        //Todo : ChangeMaterial
    }

    //ran on click plant
    public void PlacePlant()
    {
        var plantController = PendingPlant.GetComponent<PlantController>();
        plantController.animator.Play("Grow");
        checker.planted = true;
        PendingPlant.transform.parent = PlantManager.Instance.gameObject.transform;
        PendingPlant.gameObject.layer = LayerMask.NameToLayer("Plant");
        plantController.enabled = true;
        plantController.isPlanted = true;
        PendingPlant.GetComponent<Collider>().isTrigger = false;
        PlantManager.Instance.plants.Add(PendingPlant);
        GameplayManager.Instance.AddPlantGrow(PlantSo.growPlant);
        GameEventManager.Instance.plantUpdateEventInvoker(PlantManager.Instance.plants);
        EnergyContainer.instance.SpentEnergy(PlantSo.costPlant);
        PendingPlant = null;
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }
    public void SelectPlant()
    {
        if (!isCooldown && energyContainer.energyCount >= PlantSo.costPlant && PendingPlant == null)
        {
            PendingPlant = Instantiate(PlantPrefab, pos, transform.rotation);
            checker = PendingPlant.GetComponent<CheckPlantPlacement>();
            isCooldown = true;
            cooldownTimer = CooldownTime;
        }
    }
}
