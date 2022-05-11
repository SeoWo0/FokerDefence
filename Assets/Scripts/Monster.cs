using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    public Transform nextTargetPoint;

    private int index = 0;

    private void Start() {
        nextTargetPoint = WayManager.instance.wayPoints[0];    
    }

    private void Update() {
        Move();
    }

    private void Move()
    {
        Vector3 dir = nextTargetPoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(nextTargetPoint.position, transform.position) <= 0.5f)
        {
            GetNextPoint();
        }
    }

    private void GetNextPoint()
    {
        if(index >= WayManager.instance.wayPoints.Length -1)
        {
            Destroy(gameObject);
            Debug.Log("목숨 --"); 
            return;
        }

        index++;
        nextTargetPoint = WayManager.instance.wayPoints[index];
    }
}
