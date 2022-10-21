using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadiEnergy : MonoBehaviour
{
    Animator _animator;
    [SerializeField] GameObject _sawahEnergyImage;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        InvokeRepeating("CollectEnergyPadi", 3, 3);
    }
    // Update is called once per frame
    void Update()
    {
        _sawahEnergyImage.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
    void CollectEnergyPadi()
    {
        EnergyContainer.instance.AddEnergy();
        _animator.Play("CollectEnergy");
    }
}
