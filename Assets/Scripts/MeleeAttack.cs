using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private float speed = 500f;

    public void SetUp(Transform target)
    {
        this.target = target;
    }

    private void Update() {
        Attack();
    }

    public void Attack()
    {
        if(target != null)  // 타겟이 존재한다면
        {
            Vector3 direction = (target.position - transform.position).normalized;
            gameObject.transform.Translate(direction * speed * Time.deltaTime);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if( !collision.CompareTag("Monster") )
        return;

        if( collision.transform != target)
        return;

        collision.GetComponent<Monster>().OnDie();
        Destroy(gameObject);
    }
}
