using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawn : MonoBehaviour
{
    [SerializeField] GameObject _energyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnergy", 0, 8);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnergy()
    {
        Instantiate(_energyPrefab, new Vector3(Random.Range(-6, 6), 3.3f, transform.position.z), Quaternion.identity, transform);
    }
}
