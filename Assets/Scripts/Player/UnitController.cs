using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private GameObject      unitMarker;
    private NavMeshAgent    navMeshAgent;

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SelectUnit()
    {
        unitMarker.SetActive(true);
    }

    public void DeSelectUnit()
    {
        unitMarker.SetActive(false);
    }

    public void MoveTo(Vector3 targetPos)
    {
        navMeshAgent.SetDestination(targetPos);

        float distance = Vector3.Distance(gameObject.transform.position, targetPos);
        float moveNeedTime = distance / navMeshAgent.velocity.magnitude;
    }

    
}
