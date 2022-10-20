using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    Transform _transform;
    float _fallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _fallSpeed = Random.Range(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime);
        if (transform.position.y < -20)
        {
            EnergyGone();
        }
    }
    public void CollectEnergy()
    {
        EnergyContainer.instance.AddEnergy();
    }
    void EnergyGone()
    {
        GetComponent<Animator>().Play("EnergyGone");
    }
    public void DestroyEnergy()
    {
        Destroy(gameObject);
    }
}
