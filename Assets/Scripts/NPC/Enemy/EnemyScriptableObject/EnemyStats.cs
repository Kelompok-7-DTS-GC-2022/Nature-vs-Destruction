using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "NPC/Enemy")]
public class EnemyStats : ScriptableObject
{
    public float healthPoint;
    public float damagePoint;
    public float damagePerSecond;
    public float movementSpeed;
    public float thresholdSpawnMin;
    public float thresholdSpawnMax;
}
