using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlantPlacement : MonoBehaviour
{
    public static CheckPlantPlacement intance;
    public bool canPlant;
    void Start()
    {
        intance = this;
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlantGround"))
        {
            canPlant = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlantGround"))
        {
            canPlant = true;
        }
    }
}
