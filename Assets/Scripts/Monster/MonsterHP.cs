using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private float maxHP;
    private float currentHP;
    private bool isDie = false;
    private Monster monster;
    private SpriteRenderer spriteRenderer;

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

        // StopCoroutine("HitAnimation");
        // StartCoroutine("HitAnimation");
        if(currentHP <= 0 )
        {
            isDie = true;
            monster.OnDie(EnumDestroyType.kill);
        } 
    }

    // public IEnumerator HitAnimation()
    // {
    //     Color color = spriteRenderer.color;

    //     color.a = 0.4f;
    //     spriteRenderer.color = color;

    //     yield return new WaitForSeconds(0.05f);

    //     color.a = 1.0f;
    //     spriteRenderer.color = color;
    // }
}
