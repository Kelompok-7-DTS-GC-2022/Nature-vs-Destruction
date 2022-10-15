using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlantPlacement : MonoBehaviour
{
    public bool canPlant;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plant"))
        {
            canPlant = false;
        }
        else
        {
            canPlant = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plant"))
        {
            canPlant = true;
        }
        else
        {
            canPlant = false;
        }

    }
}
