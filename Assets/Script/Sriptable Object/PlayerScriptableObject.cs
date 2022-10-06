using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team7.Nature.SO
{
    [CreateAssetMenu(fileName = "NPCData", menuName = "Data/Game Data/Plant Data")]

    public class PlayerScriptableObject : ScriptableObject
    {
        public Texture iconPlant;
        public Sprite spritePlant;
        public int costPlant;
        public GameObject prefabPlant;
        public float MaxHPPlant;
        public float growPlant;
        public float damagePlant;
        public float cooldownPlant;
        public float GetHpPlant() => MaxHPPlant;
        public float GetGrowPlant() => growPlant;


    }
}

