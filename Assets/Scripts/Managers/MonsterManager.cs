using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager    instance { get; private set;}
    public Transform[]              wayPoints;
    private List<Monster>           monsterList;            // 현재 맵에 존재하는 몬스터들의 정보
    private Wave                    currentWave;            // 현재 웨이브 정보
    private int                     currentMonsterCount;    // 현재 웨이브에 남아있는 몬스터의 숫자 
    [SerializeField] private PlayerHP   playerHP;           // 플레이어 체력 Component
    [SerializeField] private PlayerGold playerGold;         // 플레이어 골드 Component  
    [SerializeField] private CameraManager cameraManager;   // 카메라 매니저      
    [SerializeField] private DealCard dealCard;               // 카드 관련 클래스  
    [SerializeField] private UIActiveManager uIActiveManager;        // UI 매니저



    // 적의 생성과 삭제는 MonsterManager가 하기때문에 set은 필요 없음
    public List<Monster> getMonsterList => monsterList;

    public int          CurrentMonsterCount => currentMonsterCount;
    public int          MaxMonsterCount => currentWave.maxMonsterCount;

    private void Awake() {
        instance = this;
        monsterList = new List<Monster>();
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;
        currentMonsterCount = currentWave.maxMonsterCount;
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
        
        currentMonsterCount--;
        monsterList.Remove(monster);
        Destroy(monster.gameObject);

        if(monsterList.Count == 0 && currentMonsterCount == 0) // 몬스터가 어떤 경위로든 모두 파괴되었을때 다시 포커로 돌아가기위함
        {
            if (playerHP.CurrentHP <= 0)
                return;
            ResetNext();
        }
    }

    public void ResetNext()                     // 웨이브가 끝났을때, 다시 한번 Reset하여 다음 라운드 시작하기위한 함수
    {
            cameraManager.ChangePokerCam();     // 카메라를 다시 포커쪽으로
            uIActiveManager.PokerUIOn();        // 포커 UI 켜주기
            uIActiveManager.GameUIOff();        // 게임쪽 UI 꺼주기
            uIActiveManager.UnitInfoOff();      // 켜져있던 유닛 정보창 꺼주기
            uIActiveManager.CombineUIOff();     // 켜져있던 유닛 조합창 꺼주기
            dealCard.ResetDeck();               // 덱을 다시 만들기 전 초기화
            dealCard.Deal();                    // 덱을 다시 만들고, 섞어주고, 플레이어 핸드 분배
            dealCard.ResetChangeButton();       // 패 교체를 위한 버튼 초기화

    }

}

