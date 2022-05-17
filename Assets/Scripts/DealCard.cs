using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCard : DeckCard
{
    public GameObject[] cardObj;
    public Card[] playerHand;
    public DealCard()
    {
        playerHand = new Card[5];
    }

    private void Start() {
        Deal();
    }

    public void Deal()
    {
        SetUpDeck();    // 덱을 만들고 카드를 섞음
        GetHand();
    }

    public void GetHand()
    {
        for (int i = 0; i < 5; i++)
        {
            playerHand[i] = getDecK[i];

            cardObj[i].GetComponent<SpriteRenderer>().sprite = playerHand[i].sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
            cardObj[i].GetComponent<SpriteRenderer>().flipX = true;                     // X 축 뒤집기
        }
    }

    public void EvaluateHand()
    {

    }
}