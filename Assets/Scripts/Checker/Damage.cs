using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int DamageTester = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            other.gameObject.GetComponent<PlantController>().TakeDamage(DamageTester);
        }
    }
}
