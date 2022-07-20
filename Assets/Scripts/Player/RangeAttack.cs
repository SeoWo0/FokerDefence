using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    private Transform target;
    private float damage;

    [SerializeField] private float speed = 100f;

    public void SetUp(Transform target, float damage)
    {
        this.target = target;       // 유닛이 설정해준 target
        this.damage = damage;       // 유닛이 설정해준 공격력
    }

    private void Update() {
        Attack();
    }

    public void Attack()
    {
        if(target != null)  // 타겟이 존재한다면
        {
            transform.LookAt(target);
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if( !collision.CompareTag("Monster") )                  // monster가 아닌 대상이랑 부딪혔을 때
        return;

        if( collision.transform != target)                      // 현재 target인 monster가 아닐 때
        return;

        collision.GetComponent<MonsterHP>().TakeDamage(damage); // 데미지만큼 체력 감소
        Destroy(gameObject);                                    // 발사체 제거
    }
}
