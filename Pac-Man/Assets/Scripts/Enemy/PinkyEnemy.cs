using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PinkyEnemy : MonoBehaviour
{
    [SerializeField]
    Transform destination;

    NavMeshAgent navMeshA;

    void Start()
    {
        navMeshA = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshA.SetDestination(targetVector);
        }
    }
}
