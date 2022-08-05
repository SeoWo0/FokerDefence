using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    [SerializeField]
    private Image           healthBar;
    [SerializeField]
    private float           maxHP;
    private float           currentHP;
    private bool            isDie = false;
    private Monster         monster;
    private SpriteRenderer  spriteRenderer;

    private void Awake() {
        currentHP = maxHP;
        monster = GetComponent<Monster>();
    }

    public void TakeDamage(float damage)
    {
        if(isDie == true)
            return;

        currentHP -= damage;
        healthBar.fillAmount = currentHP / maxHP;

        if(currentHP <= 0 )
        {
            isDie = true;
            monster.OnDie(EnumDestroyType.kill);
        } 
    }
}
