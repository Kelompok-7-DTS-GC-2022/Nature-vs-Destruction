using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Team7.Nature.Plant.Controller;

public class HealthManager : MonoBehaviour
{
    [SerializeField] PlantController plantController;
    public void TakeDamage(int amount)
    {
        plantController.currentHealthPlant -= amount;
        if(plantController.currentHealthPlant <= 0)
        {
            plantController.anim.SetTrigger("IsDead");
            // do dead animation and destroy
            Debug.Log("Die");
        }
    }
}
