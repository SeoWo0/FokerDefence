using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeckCard : MonoBehaviour
{
    public List<CardData> cardData = new List<CardData>();
    private List<Card> deck = new List<Card>();                            // 플레이에 사용할 덱
    

    public List<Card> getDecK { get { return deck; } }  // 현재 덱을 가져오기

    public void SetUpDeck()                         // 덱 생성하기 
    {
        for (int i = 0; i < cardData.Count; i++)
        {
            deck.Add(new Card());
            deck[i].sprite = cardData[i].sprite;
            deck[i].mySuit = cardData[i].cardSuit;
            deck[i].myRank = cardData[i].cardRank;
        }
        
        ShuffleDeck();                                          // 덱 만들고 덱 한번 섞어주기
    }

    public void ShuffleDeck()                                   // 덱 섞는 함수
    {
        System.Random rand = new System.Random();
        Card cardData;

        for (int ShuffleTime = 0; ShuffleTime < 10; ShuffleTime++)
        {
            for (int i=0; i < deck.Count; i++)
        {   
            // cardData 섞기
            int secondCardIndex = rand.Next(13);
            cardData = deck[i];
            deck[i] = deck[secondCardIndex];
            deck[secondCardIndex] = cardData;

        }
        }
    }

}

