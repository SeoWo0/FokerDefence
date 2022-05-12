using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public Unit[] unitPrefab;
    private UnitData unitData;
    private int maxUnitCount = 30;
    private Vector2 minSize = new Vector2(-3, -3);
    private Vector2 maxSize = new Vector2(3, 3);

    public void SpawnUnits(UnitData data)
    {
        Vector3 spawnPos = new Vector3(Random.Range(minSize.x, maxSize.x), 3, Random.Range(minSize.y, maxSize.y));
        
        // if ( PokerScene에서 Apply 버튼을 눌렀을때(= 유닛생성을 했을 때) )
        Unit clone = Instantiate(data.prefab, spawnPos, Quaternion.identity);
        UnitController unit = clone.GetComponent<UnitController>();
    }

    public List<UnitController> GetSpawnUnitsList()
    {
        List<UnitController> unitList = new List<UnitController>(maxUnitCount);

        UnitController[] units = FindObjectsOfType<UnitController>();
        foreach(UnitController unit in units)
        {
            unitList.Add(unit);
        }
        
        return unitList;
    }

}
