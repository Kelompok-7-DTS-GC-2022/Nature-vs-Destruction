using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InitialPlant", menuName = "Data/Game Data/InitialPlant")]
public class InitialConditionConf : ScriptableObject
{
    public List<GameObject> plants;
}
