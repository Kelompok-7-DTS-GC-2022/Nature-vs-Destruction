using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int DamageTester = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            other.gameObject.GetComponent<HealthManager>().TakeDamage(10);
        }
    }
}
