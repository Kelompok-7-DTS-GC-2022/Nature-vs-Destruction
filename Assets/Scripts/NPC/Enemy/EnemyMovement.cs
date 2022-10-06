using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent navMesh;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    public void enemyMovementStatsDataBinding(float speed)
    {
        navMesh.speed = speed;
    }
    public void setTargetDestination(Vector3 destination)
    {
        navMesh.isStopped = false;
        navMesh.SetDestination(destination);
    }

    public void onAttack()
    {
        navMesh.isStopped = true;
    }

    public void onDying()
    {
        navMesh.isStopped = true;
        navMesh.enabled = false;
    }
}
