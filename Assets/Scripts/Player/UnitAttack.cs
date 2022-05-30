using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget }

public class UnitAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponPrefab;    // 유닛 공격 무기 prefab
    [SerializeField]
    private Transform attackPos;             // 무기 발사 위치
    [SerializeField]
    private float attackSpeed;              // 공격 속도
    [SerializeField]
    private float attackRange;              // 공격 범위  
    [SerializeField]
    private int attackDamage;               // 공격력
    private WeaponState weaponState = WeaponState.SearchTarget;     // 공격 무기의 상태
    private Transform attackTarget = null;  // 공격 상대
    private MonsterManager monsterManager;  // 존재하는 몬스터 정보 획득용
    private Animator animator;

    public void SetUp(MonsterManager monsterManager)
    {
        this.monsterManager = monsterManager;

        // 최초 상태틀 WeaponState.SearchTarget으로 설정
        ChangeState(WeaponState.SearchTarget);
    }

    public void ChangeState(WeaponState newState)
    {
        // 이전에 재생중이던 상태 종료
        StopCoroutine(weaponState.ToString());
        // 상태 변경
        weaponState = newState;
        // 새로운 상태 재생
        StartCoroutine(weaponState.ToString());
    }

    private void Update()
    {   
        if (attackTarget != null) // 여기다가 이동중이 아닐때 변수도 포함
        {
            RotateToTarget();
        }
    }

    public void RotateToTarget()
    {
        if (attackTarget != null)
        {
            attackPos.LookAt(attackTarget.transform);
            //transform.LookAt(attackTarget.transform);
        }
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            // 제일 가까이에 있는 적을 찾기 위해 최초 거리를 최대한 크게 설정
            float closeDistance = Mathf.Infinity;
            // MonsterManager의 monsterList 안에 있는 현재 맵의 존재하는 모든 몬스터 검사
            for (int i = 0; i < monsterManager.getMonsterList.Count; ++i)
            {
                float distance = Vector3.Distance(monsterManager.getMonsterList[i].transform.position, transform.position);
                // 현재 검사중인 몬스터와의 거리가 공격 범위내에 있고, 현재까지 검사한 몬스터의 거리보다 가까우면
                if (distance <= attackRange && distance <= closeDistance)
                {
                    closeDistance = distance;
                    attackTarget = monsterManager.getMonsterList[i].transform;
                }
            }

            if (attackTarget != null)
            {
                ChangeState(WeaponState.AttackToTarget);
            }

            yield return null;
        }
    }

    private IEnumerator AttackToTarget()
    {
        while (true)
        {
            // 1. target이 있는지 검사 (다른 발사체에 의해 제거, Goal에 도착해 삭제 등)
            if (attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            // 2. target이 공격 범위에 있는지 검사 (공격 범위를 벗어나면 새로운 몬스터 탐색)
            float distance = Vector3.Distance(attackTarget.position, transform.position);
            if ( distance > attackRange )
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            yield return new WaitForSeconds(attackSpeed);

            WeaponAttack();
        }
    }

    private void WeaponAttack()
    {
        GameObject clone = Instantiate(weaponPrefab, attackPos.position, Quaternion.identity);
        clone.GetComponent<MeleeAttack>().SetUp(attackTarget, attackDamage);
    }
}
