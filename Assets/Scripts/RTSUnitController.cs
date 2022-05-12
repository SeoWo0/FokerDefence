using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnitController : MonoBehaviour
{
    [SerializeField]
    private UnitSpawner unitSpawner;
    private List<UnitController> selectedUnitList;               // 플레이어가 선택한 유닛
    public  List<UnitController> unitList { get; private set;}   // 맵에 존재하는 모든 유닛

    private void Awake() {
        selectedUnitList = new List<UnitController>();
        unitList         = unitSpawner.GetSpawnUnitsList();
    }

    public void ClickSelectUnit(UnitController unit)        // 마우스 클릭으로 유닛 선택
    {
        DeSelectAll();

        SelectUnit(unit);
    }

    public void CtrlClickSelectUnit(UnitController unit)    // 컨트롤 + 마우스 클릭으로 유닛 선택
    {
        if ( selectedUnitList.Contains(unit))               // 이미 선택한 유닛이라면 선택 해제
        DeSelectUnit(unit);                                 

        else                                                // 이미 선택한 유닛이 아니라면 선택
        SelectUnit(unit);                                   
    }

    public void DragSelectUnit(UnitController unit)         // 마우스 드래그로 유닛 선택
    {
        if (!selectedUnitList.Contains(unit))
        {
            SelectUnit(unit);
        }
    }

    public void MoveSelectedUnit(Vector3 targetPos)
    {
        for (int i = 0; i < selectedUnitList.Count; i++)
        {
            selectedUnitList[i].MoveTo(targetPos);
        }
    }

    public void DeSelectAll()                               // 모든 유닛 선택 해제
    {
        for(int i=0; i< selectedUnitList.Count; i++)
        {
            selectedUnitList[i].DeSelectUnit();             // 리스트의 모든 인덱스 삭제
        }

        selectedUnitList.Clear();
    }

    public void SelectUnit(UnitController unit)             // 유닛을 선택
    {
        unit.SelectUnit();                                  // 유닛이 선택되었을 때 호출되는 메소드

        selectedUnitList.Add(unit);                         // 선택한 유닛 정보를 리스트에 저장
    }

    public void DeSelectUnit(UnitController unit)           // 유닛을 선택 해제
    {
        unit.DeSelectUnit();                                // 유닛이 해제되었을 때 호출되는 메소드

        selectedUnitList.Remove(unit);                      // 선택한 유닛 정보를 리스트에 삭제
    }
    
}
