using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    private int             wayPointCount;      // 이동 경로 개수
    private int             currentIndex = 0;   // 현재 목표지점인덱스
    private Transform[]     wayPoints;          // 이동 경로 정보

    public void SetUp(Transform[] wayPoints)
    {
        // 몬스터 이동 경로 wayPoint 정보 설정
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // 몬스터의 시작위치를 첫번째 wayPoint 위치로 설정
        transform.position = this.wayPoints[currentIndex].position;

        // 적 이동 / 목표지점 설정 코루틴 함수 시작
        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {   
        // 다음 이동 방향 설정
        GetNextPoint();

        while(true)
        {   
            Vector3 dir = wayPoints[currentIndex].position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);

            if(Vector3.Distance(wayPoints[currentIndex].position, transform.position) <= 0.5f)
            {
                // 다음 이동 방향 설정
                GetNextPoint();
            }  

            yield  return null;          
        }
    }

    private void GetNextPoint()
    {   
        // 아직 이동할 wayPoint 가 남아있다면
        if( currentIndex < wayPointCount - 1)
        {   
            // 몬스터의 위치를 다음 wayPoint 위치로
            transform.position = wayPoints[currentIndex].position;
            currentIndex++;
        }

        else
        {
            Destroy(gameObject);
            Debug.Log("목숨-");
        }
    }
}
