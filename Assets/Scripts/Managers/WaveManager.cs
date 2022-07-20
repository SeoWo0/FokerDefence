using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{   
    [SerializeField]
    private Wave[]          waves;                  // 현재 스테이지의 모든 웨이브 정보
    [SerializeField]
    private MonsterManager  monsterManager;
    private int             currentWaveIndex = -1;  // 현재 웨이브 인덱스
    [SerializeField] GameObject gameClearWindow;
    public PlayerHP         playerHP;
     
    public int              CurrentWave => currentWaveIndex + 1;    // 시작이 0이기 때문에 +1
    public int              MaxWave => waves.Length;

    public void StartWave()
    {   
        // 현재 맵에 적이 없고, 실행할 Wave가 남아있으면
        if ( monsterManager.getMonsterList.Count == 0 && currentWaveIndex < waves.Length - 1)
        {
            // 인덱스 시작이 -1 이기 때문에, 웨이브 인덱스 증가를 가장 먼저 함
            currentWaveIndex ++;
            // MonsterManager의 StartWave() 함수 호출, 현재 웨이브 정보 제공
            monsterManager.StartWave(waves[currentWaveIndex]);
        }

        else
        {
            if (playerHP.CurrentHP <= 0)
                return;
            Time.timeScale = 0f;
            gameClearWindow.SetActive(true);
            UnitManager.unitList.Clear();
        }
    }
}

[System.Serializable]
public struct Wave
{
    public float            spawnTime;          // 현재 웨이브 몬스터 생성 주기
    public int              maxMonsterCount;    // 현재 웨이브 몬스터 생성 갯수
    public GameObject[]     monsterPrefabs;     // 현재 웨이브 몬스터 prefab
}

