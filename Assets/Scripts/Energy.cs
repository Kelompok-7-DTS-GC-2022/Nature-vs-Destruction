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
        _fallSpeed = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        print(_transform.position);
        transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime);
        if (transform.position.y < -1.4f)
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
