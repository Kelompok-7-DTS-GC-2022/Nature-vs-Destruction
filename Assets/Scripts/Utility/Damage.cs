using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damagePoint = 5;
    public LayerMask layer;

    private void OnTriggerEnter(Collider other)
    {

        if ((layer.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            print(other.gameObject.layer.ToString());
            other?.gameObject.GetComponent<ICharacterController>().takeTheDamage(damagePoint);
        }
    }
}
