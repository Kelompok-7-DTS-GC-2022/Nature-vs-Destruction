using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public static PlantController instance;
    [SerializeField] private float _maxHealthPlant;
    [SerializeField] private PlayerScriptableObject _playerSO;
    public Animator _anim;
    public bool IsDamaged;
    [SerializeField]
    private float _currentHealthPlant;
    void Start()
    {
        instance = this;
        _anim = GetComponentInChildren<Animator>();
        _maxHealthPlant = _playerSO.MaxHPPlant;
        _currentHealthPlant = _maxHealthPlant;
    }

    // Update is called once per frame
    public float getPlantHP() => _currentHealthPlant;
    public float getGrowArea() => _playerSO.growPlant;
    public void TakeDamage(int amount)
    {
        _currentHealthPlant -= amount;
        if (_currentHealthPlant <= 0)
        {
            // _anim.SetTrigger("IsDead");
            // do dead animation and destroy
            Debug.Log("Die");
            Destroy(this.gameObject);
        }
    }
}
