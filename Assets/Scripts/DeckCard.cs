using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeckCard : MonoBehaviour
{
    public Sprite[] cardSprites;
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
        int i = 0;
        foreach (Card.SUIT suit in Enum.GetValues(typeof(Card.SUIT)))     // SUIT 값 넣기
        {
            foreach (Card.RANK rank in Enum.GetValues(typeof(Card.RANK))) // RANK 값 넣기
            {
                deck[i] = new Card {mySuit = suit, myRank = rank};
                Debug.Log(deck[i].sprite);
                i++;
            }
        }
        ShuffleDeck();                                          // 덱 만들고 덱 한번 섞어주기
    }

    public void ShuffleDeck()                                   // 덱 섞는 함수
    {
        System.Random rand = new System.Random();
        Card cardData;
        //Sprite cardFace;


        for (int ShuffleTime = 0; ShuffleTime < 10; ShuffleTime++)
        {
            for (int i=0; i < numOfCards; i++)
        {   
            // cardData 섞기
            int secondCardIndex = rand.Next(13);
            cardData = deck[i];
            deck[i] = deck[secondCardIndex];
            deck[secondCardIndex] = cardData;

            // // cardSprite 섞기
            // cardFace = deck[i];
            // deck[i] = deck[sc]
        }
        }
    }
}
