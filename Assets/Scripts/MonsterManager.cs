using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager    instance { get; private set;}
    public Transform[]              wayPoints;
    private List<Monster>           monsterList;            // 현재 맵에 존재하는 몬스터들의 정보
    private Wave                    currentWave;            // 현재 웨이브 정보
    [SerializeField]
    private PlayerHP                playerHP;               // 플레이어 체력 Component
    [SerializeField]
    private PlayerGold              playerGold;             // 플레이어 골드 Component         


    // 적의 생성과 삭제는 MonsterManager가 하기때문에 set은 필요 없음
    public List<Monster> getMonsterList => monsterList;

    private void Awake() {
        instance = this;
        monsterList = new List<Monster>();
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;
        StartCoroutine("SpawnMonster");
    }

    private IEnumerator SpawnMonster()
    {   
        int spawnMonsterCount = 0;

        while(spawnMonsterCount < currentWave.maxMonsterCount)
        {
            int         monsterIndex = Random.Range(0, currentWave.monsterPrefabs.Length);
            GameObject  clone = Instantiate(currentWave.monsterPrefabs[monsterIndex]);         // monster 오브젝트 생성
            Monster     monster = clone.GetComponent<Monster>();                               // 방금 생성된 monster의 monster 컴포넌트

            // this는 나 자신, 자신의 MonsterManager 정보
            monster.SetUp(this, wayPoints);                                                     // wayPoint 정보를 매겨변수로 SetUp() 호출
            monsterList.Add(monster);                                                           // 리스트에 생성된 몬스터 저장

            spawnMonsterCount++;                                                                // 현재 웨이브 몬스터 생성 숫자 +1
            yield return new WaitForSeconds(currentWave.spawnTime);                             // spawnDelay 동안 대기
        } 
    }

    public void DestoryMonster(EnumDestroyType type, Monster monster, int gold)
    {
        if ( type == EnumDestroyType.Arrive)    // 종점에 도착하여 파괴됐을때
        {
            playerHP.TakeDamage(1);
        }

        else if ( type == EnumDestroyType.kill) // 플레이어에 의해 파괴됐을때
        {
            playerGold.CurrentGold += gold;
        }
        
        monsterList.Remove(monster);
        Destroy(monster.gameObject);
    }

}

