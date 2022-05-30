using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance { get; private set;}
    public GameObject monsterprefab;
    public float spawnDelay = 2f;
    public Transform[] wayPoints;
    private List<Monster> monsterList;      // 현재 맵에 존재하는 몬스터들의 정보
    [SerializeField]
    private PlayerHP playerHP;              // 플레이어 체력 Component


    // 적의 생성과 삭제는 MonsterManager가 하기때문에 set은 필요 없음
    public List<Monster> getMonsterList => monsterList;

    private void Awake() {
        instance = this;
        monsterList = new List<Monster>();
    }

    public void StartSpawn()
    {
        StartCoroutine("SpawnMonster");
    }

    private IEnumerator SpawnMonster()
    {   
        while(true)
        {
            GameObject clone = Instantiate(monsterprefab);          // monster 오브젝트 생성
            Monster monster = clone.GetComponent<Monster>();        // 방금 생성된 monster의 monster 컴포넌트

            // this는 나 자신, 자신의 MonsterManager 정보
            monster.SetUp(this, wayPoints);                         // wayPoint 정보를 매겨변수로 SetUp() 호출
            monsterList.Add(monster);                               // 리스트에 생성된 몬스터 저장

            yield return new WaitForSeconds(spawnDelay);            // spawnDelay 동안 대기
        } 
    }

    public void DestoryMonster(EnumDestroyType type, Monster monster)
    {
        if ( type == EnumDestroyType.Arrive)    // 종점에 도착하여 파괴됐을때
        {
            playerHP.TakeDamage(1);
        }
        monsterList.Remove(monster);
        Destroy(monster.gameObject);
    }

}

