using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NPCData", menuName = "Data/Game Data/Plant Data")]
public class PlayerScriptableObject : ScriptableObject
{
    public Texture iconPlant;
    public Sprite spritePlant;
    public int costPlant;
    public GameObject prefabPlant;
    public float MaxHPPlant;
    public float growPlant;
    public float cooldownPlant;
}
