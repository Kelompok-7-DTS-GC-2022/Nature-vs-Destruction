using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyStats enemyStats;
    private EnemyStats enemyStatsData;
    [SerializeField]
    private Animator enemyAnimator;
    [SerializeField]
    GameObject closestPlant;
    EnemyMovement movementController;
    List<GameObject> plantDataContainer;


    private void Start()
    {
        enemyStatsData = enemyStats;//binding data from scriptable object
        movementController = GetComponent<EnemyMovement>();
        // plantDataContainer = GameManager.Instance.gameObject.GetComponent<PlantManager>().getPlantList();
        GameEventManager.Instance.onPlantListUpdate += onPlantListUpdate;
    }
    private void OnDisable() => GameEventManager.Instance.onPlantListUpdate -= onPlantListUpdate;

    private void LateUpdate()
    {
        enemyStateRules();
    }
    void onPlantListUpdate(List<GameObject> plants)
    {
        plantDataContainer = plants;
        calculateClosestTarget();
    }
    void calculateClosestTarget()
    {
        if (plantDataContainer == null || plantDataContainer.Count < 1) return;
        var distance = float.MaxValue;
        plantDataContainer.RemoveAll(data => data == null);
        plantDataContainer?.ForEach(plant =>
        {
            if (distanceCounter(plant.transform.position, transform.position) < distance)
            {
                distance = Vector3.Distance(plant.transform.position, transform.position);
                closestPlant = plant;
            }
        });
    }

    void enemyStateRules()//bruteforce enemy rules
    {
        if (enemyStatsData.healthPoint > 0)
        {
            if (closestPlant != null)
            {
                var plantHealth = closestPlant.GetComponent<HealthManager>();
                // just wanted to get the value of plant grow area, but yeah it is....
                var growPlantArea = closestPlant.GetComponent<HealthManager>().getGrowArea();

                //Attack on target range
                if (distanceCounter(closestPlant.transform.position, this.transform.position) < growPlantArea)
                {
                    enemyAttack();
                    print(closestPlant);
                    if (plantHealth.getPlantHP() <= 0 || closestPlant.gameObject == null)
                    {
                        //set new target and move
                        calculateClosestTarget();
                        enemyMove();
                    }
                }
                //Move
                else
                {
                    enemyMove();
                }
            }
            else
            {
                //set new target
                calculateClosestTarget();
                enemyAnimator.Play("Idle");

            }
        }
        else
        {
            //do dead
            movementController.onDying();
            enemyAnimator.Play("Dead");
        }
    }


    void enemyAttack()
    {
        print("Attacking");
        movementController.onAttack();
        enemyAnimator.Play("Attack");
    }
    void enemyMove()
    {
        print("Moving");
        movementController.setTargetDestination(closestPlant.transform.position);
        enemyAnimator.Play("Movement");
    }
    float distanceCounter(Vector3 pointOne, Vector3 pointTwo) => Vector3.Distance(pointOne, pointTwo);
}

