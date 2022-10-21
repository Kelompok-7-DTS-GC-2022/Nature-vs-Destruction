using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawn : MonoBehaviour
{
    [SerializeField] GameObject _energyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnergy", 7, 7);
    }
    void SpawnEnergy()
    {
        Instantiate(_energyPrefab, new Vector3(Random.Range(transform.position.x - 6, transform.position.x + 6), 3, transform.position.z), Quaternion.identity, transform);
    }
}
