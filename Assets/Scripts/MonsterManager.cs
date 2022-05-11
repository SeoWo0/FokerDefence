using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [Header("Monster Setting")]

    public Monster monsterprefab;
    public float spawnDelay = 2f;
    public float lastSpawnTime = 0f;
    public Transform spawnPos;

    private void Update() {
        SpawnMonster();
    }

    private void SpawnMonster()
    {
        if(Time.time < lastSpawnTime + spawnDelay)
            return;

        lastSpawnTime = Time.time;
        Instantiate(monsterprefab, spawnPos.position, Quaternion.identity);
    }
}
