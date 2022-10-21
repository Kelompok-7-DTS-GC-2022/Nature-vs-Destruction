using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxController : MonoBehaviour
{
    [SerializeField] ParticleSystem _plantDamaged;
    [SerializeField] ParticleSystem _enemyDamaged;
    [SerializeField] GameObject _enemyDeath;
    [SerializeField] ParticleSystem _enemyAttack;
    private void Start()
    {

    }
    private void Update()
    {
    }
    // Start is called before the first frame update
    public void PlantDamaged()
    {
        _plantDamaged.Play();
    }
    public void EnemyAttack()
    {
        _enemyAttack.Play();
    }
    public void EnemyDeath()
    {
        _enemyDeath.SetActive(true);
    }
    public void EnemyDamaged()
    {
        _enemyDamaged.Play();
    }
    public void StopVfx()
    {
        _plantDamaged.Stop();
    }
}
