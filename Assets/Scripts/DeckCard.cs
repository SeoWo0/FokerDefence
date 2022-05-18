using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeckCard : MonoBehaviour
{
    public CardData[] cardData;
    const int numOfCards = 52;                      // 전체 카드의 수
    private Card[] deck;                            // 플레이에 사용할 덱
    

    public void DeckofCards()                       // deck에 전체카드수 = 52장만큼의 배열 생성
    {
        deck = new Card[numOfCards];
    }

    public Card[] getDecK { get { return deck; } }  // 현재 덱을 가져오기

    public void SetUpDeck()                         // 덱 생성하기 
    {
        DeckofCards();
        
        for (int i = 0; i < cardData.Length; i++)
        {
            deck[i] = new Card();
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
            for (int i=0; i < numOfCards; i++)
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

