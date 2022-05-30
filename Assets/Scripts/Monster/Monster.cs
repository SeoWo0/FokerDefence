using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumDestroyType { kill = 0, Arrive }
public class Monster : MonoBehaviour
{
    public float speed;
    private int             wayPointCount;      // 이동 경로 개수
    private int             currentIndex = 0;   // 현재 목표지점인덱스
    private Transform[]     wayPoints;          // 이동 경로 정보
    private MonsterManager  monsterManager;     // 몬스터의 삭제를 본인이 하지않고 monsterManager에 알려서 삭제

    public void SetUp(MonsterManager monsterManager, Transform[] wayPoints)
    {
        this.monsterManager = monsterManager;
        
        // 몬스터 이동 경로 wayPoint 정보 설정
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // 몬스터의 시작위치를 첫번째 wayPoint 위치로 설정
        transform.position = wayPoints[currentIndex].position;

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
            OnDie(EnumDestroyType.Arrive);
            Debug.Log("목숨-");
        }
    }

    public void OnDie(EnumDestroyType type)
    {
        // MonsterManager에서 리스트로 몬스터 정보를 관리하기 때문에 Destroy()를 직접하지않고 
        // 삭제될때 필요한 처리를 하기위해 DestroyMonster 함수 호출
        monsterManager.DestoryMonster(type, this);
    }
}
