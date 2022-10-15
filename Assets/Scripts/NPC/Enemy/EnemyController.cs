using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyController : MonoBehaviour
{
    public GameObject attackArea;
    [SerializeField]
    private Animator enemyAnimator;
    [SerializeField]
    private GameObject closestPlant;
    [SerializeField]
    private float healthPoint;
    private float damagePerSecond;
    private float movementSpeed;
    private EnemyMovement movementController;
    private List<GameObject> plantDataContainer;

    private void Awake()
    {
        movementController = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        GameEventManager.Instance.onPlantListUpdate += onPlantListUpdate;
        plantDataContainer = GameManager.Instance.gameObject.GetComponent<PlantManager>().getPlantList();
    }

    private void LateUpdate()
    {
        enemyStateRules();
    }
    //binding data from scriptable object
    public void enemyDataBiniding(EnemyStats enemyStats)
    {
        healthPoint = enemyStats.healthPoint;
        damagePerSecond = enemyStats.damagePerSecond;
        movementSpeed = enemyStats.movementSpeed;
        movementController.enemyMovementStatsDataBinding(movementSpeed);
    }
    private void onPlantListUpdate(List<GameObject> plants)
    {
        plantDataContainer = plants;
        calculateClosestTarget();
    }
    private void calculateClosestTarget()
    {
        if (plantDataContainer == null || plantDataContainer.Count < 1)
        {
            enemyIdle();
            return;
        }
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
    //bruteforce enemy rules
    private void enemyStateRules()
    {
        // print(healthPoint);
        if (healthPoint > 0)
        {
            if (closestPlant != null)
            {
                var plantHealth = closestPlant.GetComponent<HealthManager>();

                var growPlantArea = closestPlant.GetComponent<HealthManager>().getGrowArea();

                //Attack on target range
                if (distanceCounter(closestPlant.transform.position, this.transform.position) < growPlantArea * 0.5f)
                {
                    enemyAttack();
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
                enemyIdle();
            }
        }
        else
        {
            //do dead
            movementController.navmeshStop();
            enemyAnimator.Play("Dead");
        }
    }

    private void enemyIdle()
    {
        enemyAnimator.Play("Idle");
        movementController.navmeshStop();
    }
    //set animation and movement controll for attack state
    private void enemyAttack()
    {
        transform.LookAt(closestPlant.transform);
        movementController.navmeshStop();
        enemyAnimator.Play("Attack");
        enemyAnimator.speed *= (damagePerSecond / 10);
    }
    //activate animation event attack area game object
    void activateAttackArea() => attackArea.SetActive(true);
    void deactivateAttackArea() => attackArea.SetActive(false);
    //set animation and movement controll for movement state
    private void enemyMove()
    {
        movementController.setTargetDestination(closestPlant.transform.position);
        enemyAnimator.Play("Movement");
    }
    //use this to damage this enemy
    public void takeTheDamage(float damage) => healthPoint -= damage;
    // count distance between this enemy and some plant
    private float distanceCounter(Vector3 pointOne, Vector3 pointTwo) => Vector3.Distance(pointOne, pointTwo);
    //unsubscribing game event on disable or before destroyed
    private void OnDisable() => GameEventManager.Instance.onPlantListUpdate -= onPlantListUpdate;
}

