using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : ICharacterController
{
    public bool isPlanted = false;
    public float damage = 20;
    public Animator animator;
    public GameObject attackArea;
    [SerializeField]
    private float _maxHealthPlant;
    [SerializeField]
    private PlayerScriptableObject plantSO;
    [SerializeField]
    private float _currentHealthPlant;
    public LayerMask layerMask;
    private CheckPlantPlacement checkPlantPlacement;
    private IEnumerator selfDieCoroutine;

    void Start()
    {
        checkPlantPlacement = GetComponent<CheckPlantPlacement>();
        animator = GetComponentInChildren<Animator>();
        _maxHealthPlant = plantSO.MaxHPPlant;
        _currentHealthPlant = _maxHealthPlant;
    }
    private void Update()
    {
        characterStateRule();
        if (!checkPlantPlacement.hasNeighbour && isPlanted)
        {
            selfDieCoroutine = selfDie();
            StartCoroutine(selfDieCoroutine);
            // Invoke("selfDie", 5);

        }
        else
        {
            if (selfDieCoroutine != null)
            {
                StopCoroutine(selfDieCoroutine);
                // CancelInvoke("selfDie");
            }
        }
    }

    private IEnumerator selfDie()
    {
        yield return new WaitForSeconds(10);
        if (!checkPlantPlacement.hasNeighbour && isPlanted)
        {
            takeTheDamage(5);
        }
    }
    // void selfDie() => takeTheDamage(5);
    public float getPlantHP() => _currentHealthPlant;
    public float getGrowArea() => plantSO.growPlant;


    public override void activateAttackArea() => attackArea.SetActive(true);

    public override void deactivateAttackArea() => attackArea.SetActive(false);

    public override void takeTheDamage(float damage) => _currentHealthPlant -= damage;

    public override void characterStateRule()
    {
        if (_currentHealthPlant <= 0)
        {
            animator.Play("Dead");
            // do dead animation and destroy
            StartCoroutine(destroyAfterAnimation());
            // if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dead") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.1f)
            // {
            //     Debug.Log("Yieeellllddd");
            //     Destroy(this.gameObject);
            // }
        }
        else
        {
            if (isPlanted)
            {
                var enemyOverlap = Physics.OverlapSphere(transform.position, 3, layerMask);
                if (enemyOverlap.Length > 0)
                {
                    if (attackArea != null)
                    {
                        attackArea.GetComponent<Damage>().damagePoint = damage;
                        animator.Play("Attack");
                    }
                }
                else
                {
                    animator.Play("Idle");
                }
            }
        }
    }
    IEnumerator destroyAfterAnimation()
    {
        var animationToDestroy = new AnimationUtilities();
        // start VFX
        yield return StartCoroutine(animationToDestroy.waitAnimationToDestroy(animator, "Dead"));
        //stop VFX
        //destroy
        Destroy(this.gameObject);
    }
}
