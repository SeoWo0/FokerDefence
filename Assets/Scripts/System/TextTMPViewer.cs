using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI     textPlayerHP;       // Text - TextMeshPro UI [ 플레이어의 체력 ]
    [SerializeField]
    private PlayerHP            playerHP;           // 플레이어의 체력 정보
    [SerializeField]
    private TextMeshProUGUI     textPlayerGold;     // Text - TextMeshPro UI [ 플레이어의 골드 ]
    [SerializeField]
    private PlayerGold          playerGold;         // 플레이어의 골드 정보
    [SerializeField]
    private WaveManager         playerWave;         // Wave 정보
    [SerializeField]
    private TextMeshProUGUI     textPlayerWave;     // Text - TextMeshPro UI [ 현재 Wave / 전체 Wave ]
    [SerializeField]
    private MonsterManager      monsterManager;     // Monster 정보
    [SerializeField]
    private TextMeshProUGUI     textMonsterCount;   // Text - TextMeshPro UI [ 현재 Monster 수 / 전체 Monster 수 ]

    private void Update() {
        
        textPlayerHP.text = playerHP.CurrentHP + "/" + playerHP.MaxHP;
        textPlayerGold.text = playerGold.CurrentGold.ToString();
        textPlayerWave.text = playerWave.CurrentWave + "/" + playerWave.MaxWave;
        textMonsterCount.text = monsterManager.CurrentMonsterCount + "/" + monsterManager.MaxMonsterCount;
    }
}
