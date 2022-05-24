using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private GameObject unitMarker;
    private NavMeshAgent navMeshAgent;

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        DontDestroyOnLoad(gameObject);                      // 이 컴포넌트를 가지고 있으면 DontDestroy
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
    }

    
}
