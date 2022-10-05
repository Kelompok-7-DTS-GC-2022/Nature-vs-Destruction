using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawn : MonoBehaviour
{
    [SerializeField] GameObject _energyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnergy", 0, Random.Range(7, 13));
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnergy()
    {
        Instantiate(_energyPrefab, new Vector3(Random.Range(transform.position.x - 70, transform.position.x + 70), transform.position.y - 10, transform.position.z), Quaternion.identity, transform.parent.IsChildOf(gameObject.transform) ? transform.parent : transform);
    }
}
