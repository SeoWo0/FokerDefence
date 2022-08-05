using System.Collections.Generic;
using UnityEngine;

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

        ShuffleDeck(deck);                                          // 덱 만들고 덱 한번 섞어주기
    }

    public void ShuffleDeck<T>(List<T> list)                // 덱 섞는 함수
    {
        System.Random _random = new System.Random();
        int length = list.Count;
        for(int shuffleTime = 0; shuffleTime<2; shuffleTime++)
        {
            for (int i = 0; i < length; i++)
            {
                int r = i + (int)(_random.NextDouble() * (length - i));
                T temp = list[r];
                list[r] = list[i];
                list[i] = temp;
            }
        }
    }
}

