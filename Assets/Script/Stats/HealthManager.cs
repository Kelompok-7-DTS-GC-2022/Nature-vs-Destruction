using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    [SerializeField] private float _maxHealthPlant;
    [SerializeField] private PlayerScriptableObject _playerSO;
    public Animator _anim;
    public bool IsDamaged;
    private float _currentHealthPlant;
    void Start()
    {
        instance = this;
        _anim = GetComponentInChildren<Animator>();
        _maxHealthPlant = _playerSO.MaxHPPlant;
        _currentHealthPlant = _maxHealthPlant;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void TakeDamage(int amount)
    {
        _currentHealthPlant -= amount;
        if(_currentHealthPlant <= 0)
        {
            _anim.SetTrigger("IsDead");
            // do dead animation and destroy
            Debug.Log("Die");
        }
    }
}
