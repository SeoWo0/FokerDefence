using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 20;   // 플레이어 체력
    private float currentHP;    // 현재 체력

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake() {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if(currentHP <= 0 )
        {
            Debug.Log("GameOver");
        }
    }
}
