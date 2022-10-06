using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Team7.Nature.SO;

public class PlantingManager : MonoBehaviour
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
    [SerializeField] public LayerMask[] layerMask;
    public List<GameObject> PlantList;
    public float TotalPlantGrow;

    [Header("Grid Option")]
    public float GridSize;
    bool isGrid = true;

    private void Start()
    {
        cooldownImage.fillAmount = 0.0f;
        PlantList = new List<GameObject>();
    }
    void Update()
    {
        if(PendingPlant != null)
        {
            if (isGrid)
            {
                PendingPlant.transform.position = new Vector3(RoundToNearestGrid(pos.x),
                RoundToNearestGrid(pos.y),
                RoundToNearestGrid(pos.z));
            }
            else
            {
                PendingPlant.transform.position = pos;
            }
            //UpdateMaterials();
            if (Input.GetMouseButtonDown(0) && CheckPlantPlacement.intance.canPlant)
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
    public void PlantCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if(cooldownTimer < 0.0f)
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
       
        PendingPlant = null;
        PlantList.Add(PendingPlant);
        GameManager.Instance.AddPlantGrow(TotalPlantGrow);
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000, layerMask[0]))
        {
            
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
