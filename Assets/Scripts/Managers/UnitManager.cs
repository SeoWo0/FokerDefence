using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager           instance { get; private set; }
    [SerializeField]
    private MonsterManager              monsterManager;                                     // 현재 맵의 몬스터 정보를 얻기 위해
    public DealCard                     dealCard;
    [SerializeField]
    private List<UnitController>        unitRTSList = new List<UnitController>();           // RTS controller 이동, 선택에서 사용할 유닛 리스트
    public static List<UnitController>  unitList = new List<UnitController>();              // 유닛의 생성, 제거를 관리할 유닛 리스트
    [SerializeField]
    private UnitData[]                  unitData;                                           // 유닛 데이터 배열
    private Vector2                     minSize = new Vector2(-6, -6);                      // 유닛 스폰 랜덤 위치 min
    private Vector2                     maxSize = new Vector2(6, 6);                        // 유닛 스폰 랜덤 위치 max

    [SerializeField]
    private int highCount;
    [SerializeField]
    private int oneCount;
    [SerializeField]
    private int twoCount;
    [SerializeField]
    private int threeCount;
    [SerializeField]
    private int fullCount;
    [SerializeField]
    private int straightCount;
    [SerializeField]
    private int fourCount;
    [SerializeField]
    private int plushCount;
    [SerializeField]
    private int straightPCount;

    private void Awake()
    {
        instance = this;
    }


    public void SpawnUnits()                                                        // 유닛을 생성하는 함수
    {   
        Vector3 spawnPos = new Vector3(Random.Range(minSize.x, maxSize.x), 4, Random.Range(minSize.y, maxSize.y)); 
        ResetRankCount();

        if(dealCard.isHigh == true)
        {   
            UnitController high = Instantiate(unitData[0].prefab, spawnPos, Quaternion.identity);
            high.GetComponent<UnitAttack>().SetUp(monsterManager);
            unitList.Add(high);
        }

        if(dealCard.isOnePair == true)
        {
            UnitController onepair = Instantiate(unitData[1].prefab, spawnPos, Quaternion.identity);  
            unitList.Add(onepair);
            onepair.GetComponent<UnitAttack>().SetUp(monsterManager);            
        }

        if(dealCard.isTwoPair == true)
        {
            UnitController twopair = Instantiate(unitData[2].prefab, spawnPos, Quaternion.identity); 
            unitList.Add(twopair);
            twopair.GetComponent<UnitAttack>().SetUp(monsterManager);
        }

        if(dealCard.isThree == true)
        {
            UnitController three = Instantiate(unitData[3].prefab, spawnPos, Quaternion.identity); 
            unitList.Add(three);
            three.GetComponent<UnitAttack>().SetUp(monsterManager);
        }

        if(dealCard.isFull == true)
        {
            UnitController fullH = Instantiate(unitData[4].prefab, spawnPos, Quaternion.identity);
            unitList.Add(fullH); 
            fullH.GetComponent<UnitAttack>().SetUp(monsterManager);
        }

        if(dealCard.isStaright == true)
        {
            UnitController straight = Instantiate(unitData[5].prefab, spawnPos, Quaternion.identity);
            unitList.Add(straight);
            straight.GetComponent<UnitAttack>().SetUp(monsterManager); 
        }

        if(dealCard.isFour == true)
        {
            UnitController four = Instantiate(unitData[6].prefab, spawnPos, Quaternion.identity); 
            unitList.Add(four);
            four.GetComponent<UnitAttack>().SetUp(monsterManager);
        }

        if(dealCard.isPlush == true)
        {
            UnitController plush = Instantiate(unitData[7].prefab, spawnPos, Quaternion.identity); 
            unitList.Add(plush);
            plush.GetComponent<UnitAttack>().SetUp(monsterManager);
        }

        if(dealCard.isStarightP == true)
        {
            UnitController straightP = Instantiate(unitData[8].prefab, spawnPos, Quaternion.identity); 
            unitList.Add(straightP);
            straightP.GetComponent<UnitAttack>().SetUp(monsterManager);
        }        

        GetSpawnUnitsRTSList();
        GetRankCount();
    }

    public void UnitCombine()
    {
        Vector3 spawnPos = new Vector3(Random.Range(minSize.x, maxSize.x), 4, Random.Range(minSize.y, maxSize.y));


        if(highCount <= 3)
        {
            int removeCount = 0;
            UnitController highQueen = Instantiate(unitData[9].prefab, spawnPos, Quaternion.identity);
            unitList.Add(highQueen);
            highQueen.GetComponent<UnitAttack>().SetUp(monsterManager);
            highCount = 0;

            for(int i=0; i<unitList.Count; i++)
            {
                UnitController target = GameObject.Find("High(Clone)").GetComponent<UnitController>();
                unitList.Remove(target);
                Destroy(target);
                removeCount++;

                if(removeCount == 3)
                return;
            }
        }
    }

    public void GetRankCount()                                                          // 필드의 종류별 유닛의 수 저장용 함수
    {   
        for(int i=0; i<unitList.Count; i++)
        {       
            if(unitList[i].name == "High(Clone)")
            {
                GameManager.instance.GetComponent<UnitManager>().highCount++;
            }

            if(unitList[i].name == "One(Clone)")
            {
                GameManager.instance.GetComponent<UnitManager>().oneCount++;
            }

            if(unitList[i].name == "Two(Clone)")
            {
                GameManager.instance.GetComponent<UnitManager>().twoCount++;
            }

            if(unitList[i].name == "Three(Clone)")
            {
                GameManager.instance.GetComponent<UnitManager>().threeCount++;
            }

            if(unitList[i].name == "FullH(Clone)")
            {
                GameManager.instance.GetComponent<UnitManager>().fullCount++;
            }

            if(unitList[i].name == "Straight(Clone)")
            {
                GameManager.instance.GetComponent<UnitManager>().straightCount++;
            }

            if(unitList[i].name == "Four(Clone)")
            {
                GameManager.instance.GetComponent<UnitManager>().fourCount++;
            }

            if(unitList[i].name == "Plush(Clone)")
            {
                GameManager.instance.GetComponent<UnitManager>().plushCount++;
            }

            if(unitList[i].name == "StraightP(Clone)")
            {
                GameManager.instance.GetComponent<UnitManager>().straightPCount++;
            }
        }

    }
    
    public void ResetRankCount()
    {
        highCount = 0;
        oneCount = 0;
        twoCount = 0;
        threeCount  = 0;
        fourCount = 0;
        fullCount = 0;
        straightCount = 0;
        straightPCount = 0;
        plushCount = 0;
    }

    public List<UnitController> GetSpawnUnitsRTSList()
    {
        UnitController[] units = FindObjectsOfType<UnitController>();
        foreach (UnitController unit in units)
        {
            unitRTSList.Add(unit);
        }   
        return unitRTSList;
    }
}
