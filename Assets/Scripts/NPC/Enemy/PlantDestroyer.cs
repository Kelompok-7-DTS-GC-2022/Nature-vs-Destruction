using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            Destroy(this.gameObject);
        }
    }
}
