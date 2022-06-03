using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitDataViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI     textUnitName;       // Unit 이름
    [SerializeField]
    private TextMeshProUGUI     textUnitAttDamage;  // Unit 공격력
    [SerializeField]
    private TextMeshProUGUI     textUnitAttRange;   // Unit 공격거리
    [SerializeField]
    private TextMeshProUGUI     textUnitAttSpeed;   // Unit 공격속도
    private UnitAttack          selectUnit;         // 선택한 유닛

    public void OnPanel(Transform unit)
    {
        selectUnit = unit.GetComponent<UnitAttack>();

        gameObject.SetActive(true);

        UpdateUnitData();
    }

    public void UpdateUnitData()
    {   
        textUnitName.text = "Name : " + selectUnit.name;
        textUnitAttDamage.text = "Attack Damage : " + selectUnit.AttDamage;
        textUnitAttRange.text = "Attack Range : " + selectUnit.AttRange;
        textUnitAttSpeed.text = "Attack Speed : " + selectUnit.AttSpeed;

    }
    
}
