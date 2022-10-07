using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyManager : MonoBehaviour
{

    public LayerMask avoidanceLayer;
    [SerializeField]
    Collider groundCollider;

    [SerializeField]
    List<EnemyStats> enemyPreFabConf;


    private void Start()
    {
        print("ground center" + groundCollider.bounds.center);
        enemyPreFabConf.ForEach(enemyData =>
           {
               //spawn enemy based on thier on spawn time threshold
               StartCoroutine(enemySpawner(enemyData));
           });
    }
    private void LateUpdate()
    {

    }
    IEnumerator enemySpawner(EnemyStats enemy)
    {
        var maxThreshold = enemy.thresholdSpawnMax;
        var minThreshold = enemy.thresholdSpawnMin;
        // infinite loop with random range delay
        while (true)
        {
            var second = Random.Range(minThreshold, maxThreshold);
            print(second);
            yield return new WaitForSeconds(second);
            var enemyObj = Instantiate(enemy.enemyPrefab, transform);
            enemyObj.GetComponent<EnemyController>().enemyDataBiniding(enemy);
            enemyObj.transform.position = new RandomRangePosition()
                                        .generateRandomPosition(groundCollider, 1, avoidanceLayer);
        }

    }

}
