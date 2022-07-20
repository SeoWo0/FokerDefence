using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 20;   // 플레이어 체력
    private float   currentHP;    // 현재 체력
    [SerializeField]
    private Image   imageScreen;  // 화면 덮는 이미지 변수
    [SerializeField] private GameObject gameOverWindow;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake() {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        StopCoroutine("HitAnimation");
        StartCoroutine("HitAnimation");

        if(currentHP <= 0 )
        {
            gameOverWindow.SetActive(true);
            Time.timeScale = 0f;
            UnitManager.unitList.Clear();
        }
    }

    private IEnumerator HitAnimation()
    {
        // 전체화면의 크기로 배치된 imageScreen의 색상을 color 변수에 저장
        // imageScreen의 투명도를 40%로 설정
        Color color = imageScreen.color;
        color.a = 0.4f;
        imageScreen.color = color;

        // 투명도가 0이 될때까지 감소
        while( color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            imageScreen.color = color;

            yield return null;
        }
    }
}
