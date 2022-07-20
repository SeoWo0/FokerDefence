using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class UnitController : MonoBehaviour
{
    [SerializeField] private GameObject unitMarker;
    private NavMeshAgent navMeshAgent;
    private bool m_isMoveStart;
    private float m_moveStartTime;
    private Animator animator;
    
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        
        if(m_isMoveStart)
        {
            m_moveStartTime += Time.deltaTime;
        }

        if(animator.GetFloat("Move") > 0)
        {
            animator.SetBool("isMove", true);
            animator.SetBool("isAttack", false);
        }

        else
        {
            animator.SetBool("isMove", false);
        }
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
        if(navMeshAgent.hasPath)
        {
            m_moveStartTime = 0;
        }
        navMeshAgent.SetDestination(targetPos);
        
        m_isMoveStart = true;
        StartCoroutine("CheckMoveTime");
    }

    public IEnumerator CheckMoveTime()
    {
        float distance = Vector3.Distance(gameObject.transform.position, navMeshAgent.destination);
        float moveNeedTime = distance / navMeshAgent.speed;
        yield return new WaitUntil(() => m_moveStartTime >= moveNeedTime);

        navMeshAgent.isStopped = true;
        navMeshAgent.ResetPath();
        navMeshAgent.isStopped = false;
        m_moveStartTime = 0;
        m_isMoveStart = false;
    }
}
