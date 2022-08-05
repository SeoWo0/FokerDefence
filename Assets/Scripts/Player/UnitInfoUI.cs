using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI     textUnitName;       // Unit 이름
    [SerializeField] private TextMeshProUGUI     textUnitAttDamage;  // Unit 공격력
    [SerializeField] private TextMeshProUGUI     textUnitAttRange;   // Unit 공격거리
    [SerializeField] private TextMeshProUGUI     textUnitAttSpeed;   // Unit 공격속도
    [SerializeField] private PlayerGold          m_playerGold;
    [SerializeField] private Button              upgradeButton;
    private UnitAttack                           m_selectUnit;       // 선택한 유닛

    private void Update() {
        if(m_playerGold.CurrentGold >= m_selectUnit.unitData.upCost)
        {
            upgradeButton.interactable = true;
        }

        else
        {
            upgradeButton.interactable = false;
        }

        UpdateUnitData();
    }

    public void OnPanel(Transform unit)
    {
        m_selectUnit = unit.GetComponent<UnitAttack>();

        gameObject.SetActive(true);

        UpdateUnitData();
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
    }
    
    public void DamageUpgrade()
    {
            m_selectUnit.AttDamage++;
            m_playerGold.CurrentGold -= m_selectUnit.unitData.upCost;
    }

    public void UpdateUnitData()
    {   
        textUnitName.text = "Name : " + m_selectUnit.name;
        textUnitAttDamage.text = "Attack Damage : " + m_selectUnit.AttDamage;
        textUnitAttRange.text = "Attack Range : " + m_selectUnit.AttRange;
        textUnitAttSpeed.text = "Attack Speed : " + m_selectUnit.AttSpeed;

    }
    
}
