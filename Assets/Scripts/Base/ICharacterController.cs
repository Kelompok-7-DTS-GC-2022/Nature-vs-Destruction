using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class ICharacterController : MonoBehaviour
{
    public abstract void activateAttackArea();
    public abstract void deactivateAttackArea();
    public abstract void takeTheDamage(float damage);
    public abstract void characterStateRule();
}
