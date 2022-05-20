using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public DealCard dealCard;
    public UnitData[] unitData;
    private int maxUnitCount = 30;
    private Vector2 minSize = new Vector2(-3, -3);
    private Vector2 maxSize = new Vector2(3, 3);

    public void SpawnUnits()
    {   
        Vector3 spawnPos = new Vector3(Random.Range(minSize.x, maxSize.x), 3, Random.Range(minSize.y, maxSize.y));

        if(dealCard.isHigh == true)
        {
           Unit clone = Instantiate(unitData[0].prefab, spawnPos, Quaternion.identity); 
           UnitController unit = clone.GetComponent<UnitController>();
        }

        if(dealCard.isOnePair == true)
        {
           Unit clone = Instantiate(unitData[1].prefab, spawnPos, Quaternion.identity); 
           UnitController unit = clone.GetComponent<UnitController>();
        }

        if(dealCard.isTwoPair == true)
        {
           Unit clone = Instantiate(unitData[2].prefab, spawnPos, Quaternion.identity); 
           UnitController unit = clone.GetComponent<UnitController>();
        }

        if(dealCard.isThree == true)
        {
           Unit clone = Instantiate(unitData[3].prefab, spawnPos, Quaternion.identity); 
           UnitController unit = clone.GetComponent<UnitController>();
        }

        if(dealCard.isFull == true)
        {
           Unit clone = Instantiate(unitData[4].prefab, spawnPos, Quaternion.identity); 
           UnitController unit = clone.GetComponent<UnitController>();
        }

        if(dealCard.isStaright == true)
        {
           Unit clone = Instantiate(unitData[5].prefab, spawnPos, Quaternion.identity); 
           UnitController unit = clone.GetComponent<UnitController>();
        }

        if(dealCard.isFour == true)
        {
           Unit clone = Instantiate(unitData[6].prefab, spawnPos, Quaternion.identity); 
           UnitController unit = clone.GetComponent<UnitController>();
        }

        if(dealCard.isPlush == true)
        {
           Unit clone = Instantiate(unitData[7].prefab, spawnPos, Quaternion.identity); 
           UnitController unit = clone.GetComponent<UnitController>();
        }

        if(dealCard.isStarightP == true)
        {
           Unit clone = Instantiate(unitData[8].prefab, spawnPos, Quaternion.identity); 
           UnitController unit = clone.GetComponent<UnitController>();
        }
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
