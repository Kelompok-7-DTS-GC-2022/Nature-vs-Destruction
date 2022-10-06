using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Team7.Nature.SO;
namespace Team7.Nature.Plant.Controller
{
    public class PlantController : MonoBehaviour
    {
        [SerializeField] PlayerScriptableObject plantSO;
        [SerializeField] public float currentHealthPlant;
        [SerializeField] public Animator anim;
        [SerializeField] public float areaGrow;
        public bool isDamaged;

        void Start()
        {
            anim = GetComponent<Animator>();
            currentHealthPlant = plantSO.GetHpPlant();
            areaGrow = plantSO.GetGrowPlant();
        }

        void Update()
        {
            if (isDamaged)
            {
                currentHealthPlant -= Time.deltaTime;
            }
            if (currentHealthPlant <= 0)
            {
                anim.SetTrigger("IsDead");
                // do dead animation and destroy
                Debug.Log("Die");
            }
        }


    }
}


