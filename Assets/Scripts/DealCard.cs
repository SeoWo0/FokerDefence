using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCard : DeckCard
{
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
            //Debug.Log(playerHand[i] + " , " + playerHand[i].mySuit + " , " + playerHand[i].myRank);
        }
    }

    public void EvaluateHand()
    {

    }
}