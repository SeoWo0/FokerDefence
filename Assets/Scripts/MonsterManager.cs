using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [Header("Monster Setting")]

    public Monster monsterprefab;
    public float spawnDelay = 2f;
    public Transform[] wayPoints;

    private void Awake() {
        StartCoroutine(SpawnMonster());
    }

    private IEnumerator SpawnMonster()
    {   
        while(true)
        {
            Monster clone = Instantiate(monsterprefab);
            Monster monster = clone.GetComponent<Monster>();

            monster.SetUp(wayPoints);

            yield return new WaitForSeconds(spawnDelay);
        }
}
}

