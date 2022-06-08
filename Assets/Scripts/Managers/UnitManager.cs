using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private RTSUnitController           rTSUnitController;                                  // RTS 유닛 컴포넌트

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

    private void Update() {
        CanCombine();
    }

    public void SpawnUnits()        // 유닛 생성 함수
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

    public void UnitCombine()       // 유닛 조합 함수
    {
        Vector3 spawnPos = new Vector3(Random.Range(minSize.x, maxSize.x), 4, Random.Range(minSize.y, maxSize.y));

        if(highCount >= 2)          // HighQ 유닛 조합
        {   
            int removeCount = 0;
            UnitController highQueen = Instantiate(unitData[9].prefab, spawnPos, Quaternion.identity);
            unitList.Add(highQueen);
            highQueen.GetComponent<UnitAttack>().SetUp(monsterManager);

            int i = 0;
            while(true)
            {
                if(unitList[i].gameObject.name != "High(Clone)")
                {
                    i++;
                    continue;
                }

                GameObject obj = unitList[i].gameObject;
                UnitController target = unitList[i];

                unitList.Remove(target);
                Destroy(obj);

                removeCount++;
                GameManager.instance.GetComponent<UnitManager>().highCount--;
                            

                if(removeCount == 2)
                {   
                    rTSUnitController.unitList.Clear();

                    for( int j =0; j<unitList.Count; j++)
                    {
                        rTSUnitController.unitList.Add(unitList[j]);
                    }

                    return;
                }
            }            
        }
    }

    public void CanCombine()        // 조합 버튼 활성화 함수
    {
        if(highCount >= 2 )
        {
            UIActiveManager.instance.highQButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            UIActiveManager.instance.highQButton.GetComponent<Button>().interactable = false;
        }

        if((oneCount >=1 && twoCount >=1) && (oneCount >=1 && threeCount >= 1))
        {
            UIActiveManager.instance.oneTwoThreeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            UIActiveManager.instance.oneTwoThreeButton.GetComponent<Button>().interactable = false;
        }

    } 
    
    public void GetRankCount()      // 필드의 종류별 유닛의 수 저장용 함수
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
        GameManager.instance.GetComponent<UnitManager>().highCount = 0;
        GameManager.instance.GetComponent<UnitManager>().oneCount = 0;
        GameManager.instance.GetComponent<UnitManager>().twoCount = 0;
        GameManager.instance.GetComponent<UnitManager>().threeCount  = 0;
        GameManager.instance.GetComponent<UnitManager>().fourCount = 0;
        GameManager.instance.GetComponent<UnitManager>().fullCount = 0;
        GameManager.instance.GetComponent<UnitManager>().straightCount = 0;
        GameManager.instance.GetComponent<UnitManager>().straightPCount = 0;
        GameManager.instance.GetComponent<UnitManager>().plushCount = 0;
    }

    public List<UnitController> GetSpawnUnitsRTSList()
    {
        UnitController[] units = FindObjectsOfType<UnitController>();
        unitRTSList.Clear();

        foreach (UnitController unit in units)
        {
            unitRTSList.Add(unit);
        }   
        return unitRTSList;
    }
}
