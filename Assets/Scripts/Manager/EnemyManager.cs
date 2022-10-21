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
        // print("ground center" + groundCollider.bounds.center);
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
            yield return new WaitForSeconds(second);
            var enemyObj = Instantiate(enemy.enemyPrefab, transform);
            enemyObj.GetComponent<EnemyController>().enemyDataBiniding(enemy);
            enemyObj.transform.position = new RandomRangePosition()
                                        .generateRandomPosition(groundCollider, 1, avoidanceLayer);
        }

    }

}


// using System.Collections;
// using System.Collections.Generic;
// using System.Data;
// using UnityEngine;
// using UnityEngine.PlayerLoop;

// public class EnemyManager : MonoBehaviour
// {

//     public LayerMask avoidanceLayer;
//     [SerializeField]
//     Collider groundCollider;

//     [SerializeField]
//     List<EnemyStats> enemyPreFabConf;
//     private float delayBetweenWave;
//     private float waveDelay = 15;
//     public TimerManager timer;
//     private Coroutine enemySpawnCoroutine;
//     private bool finalWaveIsStarted = false;

//     private void Start()
//     {
//         // print("ground center" + groundCollider.bounds.center);
//         enemyPreFabConf.ForEach(enemyData =>
//            {
//                //spawn enemy based on thier on spawn time threshold
//                StartCoroutine(enemySpawner(enemyData, (enemyData.thresholdSpawnMax * 0), 120));
//            });
//     }
//     private void LateUpdate()
//     {
//         // if (delayBetweenWave < 0)
//         // {
//         //     spawnEnemy();
//         //     delayBetweenWave = waveDelay;
//         // }
//         // delayBetweenWave -= Time.deltaTime;

//         if (timer._timerEnd >= 120)
//         {
//             if (!finalWaveIsStarted)
//             {
//                 finalWaveIsStarted = true;
//                 enemyPreFabConf.ForEach(enemyData =>
//           {
//               //spawn enemy based on thier on spawn time threshold
//               StartCoroutine(enemySpawner(enemyData, (enemyData.thresholdSpawnMax * 0.2f), 120));
//           });
//             }
//         }


//     }

//     private void spawnEnemy()
//     {
//         enemyPreFabConf.ForEach(enemyData =>
//              {

//              });
//     }

//     IEnumerator enemySpawner(EnemyStats enemy, float discountCoolDown, float minutePoint)
//     {
//         var maxThreshold = enemy.thresholdSpawnMax - discountCoolDown;

//         // infinite loop with random range delay
//         while (timer._timerEnd <= minutePoint)
//         {

//             yield return new WaitForSeconds(maxThreshold);
//             var enemyObj = Instantiate(enemy.enemyPrefab, transform);
//             enemyObj.GetComponent<EnemyController>().enemyDataBiniding(enemy);
//             enemyObj.transform.position = new RandomRangePosition()
//                                         .generateRandomPosition(groundCollider, 1, avoidanceLayer);
//         }
//     }

// }

