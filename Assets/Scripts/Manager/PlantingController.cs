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

    public float growSize;

    [Header("Grid Option")]
    public float GridSize;
    bool isGrid = true;
    private CheckPlantPlacement checker;

    private void Start()
    {

        cooldownImage.fillAmount = 0.0f;
    }
    void Update()
    {

        if (PendingPlant != null)
        {
            checker = PendingPlant.GetComponent<CheckPlantPlacement>();
            // if (isGrid)
            // {
            //     PendingPlant.transform.position = new Vector3(RoundToNearestGrid(pos.x),
            //     RoundToNearestGrid(pos.y),
            //     RoundToNearestGrid(pos.z));
            // }
            // else
            // {
            PendingPlant.transform.position = pos;
            // }
            //UpdateMaterials();
            if (Input.GetMouseButtonDown(0) && checker.canPlant)
            {
                PlacePlant();
                //HealthManager.instance._anim.SetTrigger("IsGrow");
            }
        }
        if (isCooldown)
        {
            PlantCooldown();
        }
    }

    private void plantDataBinding()
    {
        growSize = PlantSo.growPlant;

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

    public void PlacePlant()
    {
        PlantManager.Instance.plants.Add(PendingPlant);
        PendingPlant.transform.parent = PlantManager.Instance.gameObject.transform;
        GameManager.Instance.AddPlantGrow(growSize);
        GameEventManager.Instance.plantUpdateEventInvoker(PlantManager.Instance.plants);
        PendingPlant = null;
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            pos = hit.point;
        }

    }
    public void SelectPlant()
    {
        if (isCooldown)
        {
            //return
        }
        else
        {
            PendingPlant = Instantiate(PlantPrefab, pos, transform.rotation);
            isCooldown = true;
            cooldownTimer = CooldownTime;
        }
    }
    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % GridSize;
        pos -= xDiff;
        if (xDiff > (GridSize / 2))
        {
            pos += GridSize;
        }
        return pos;
    }
}
