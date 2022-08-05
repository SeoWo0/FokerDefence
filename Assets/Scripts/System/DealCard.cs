using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealCard : DeckCard
{
    List<Card> cardList = new List<Card>();         // DeckList 
    public Card[] playerHand;                       // 플레이어가 실제로 가지고있는 다섯장의 카드

    public int heartSum, spadeSum, clubSum, diamondSum;

    public bool isHigh, isOnePair, isTwoPair, isThree, isFull, isStraight, isFour, isPlush, isStraightP;

    private void Start() {
        Deal();
    }

    private void Update() {
        EvaluateHand();
    }

    public void Deal()
    {   
        playerHand = new Card[5];
        SetUpDeck();    // 덱을 만들고 카드를 섞음
        ResetCardList();
        GetHand();
        GetNumberOfSuit();
    }

    public void ResetCardList()
    {      
        cardList.Clear();

        for(int i=0; i<getDecK.Count; i++)
        {  
            cardList.Add(getDecK[i]);
        }
    }

    public void GetHand()
    {
        for (int i = 0; i < 5; i++)
        {
            playerHand[i] = getDecK[i];

            GameManager.instance.handCardObjects[i].GetComponent<SpriteRenderer>().sprite = playerHand[i].sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용           
            cardList.Remove(playerHand[i]);
            //Debug.Log(playerHand[i].myRank.ToString() + playerHand[i].mySuit.ToString());
        }
    }

    public void ResetDeck()
    {
        for(int i=0; i<getDecK.Count; i++)
        {
            getDecK.Clear();
        }
    }

    public void ChangeCard(int index)         //패 교환
    {   
        int randomCardNum = Random.Range(0, cardList.Count);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeCard(index);

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[index] = card;                           // 플레이어 핸드 첫번째 패에 (= 가장 왼쪽) 새로운 카드로 교체
        cardList.Remove(playerHand[index]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)

        GameManager.instance.handCardObjects[index].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        UIActiveManager.instance.pokerChangeButtons[index].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        UIActiveManager.instance.pokerChangeButtons[index].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색

        getDecK.Clear();
        
        for(int i=0; i<cardList.Count; i++)
        {
            getDecK.Add(cardList[i]);
        }

        ShuffleDeck(getDecK);
    }

    public void ResetChangeButton() // Change 버튼들 초기화
    {
        for(int i=0; i< UIActiveManager.instance.pokerChangeButtons.Length; i++)
        {
            UIActiveManager.instance.pokerChangeButtons[i].GetComponent<Button>().interactable = true;
            UIActiveManager.instance.pokerChangeButtons[i].GetComponent<Image>().color = Color.green;
        }
    }

    public void EvaluateHand()      // 플레이어 핸드 값 결과
    {
        SpriteRenderer spriteRenderer = GameManager.instance.handRanking.GetComponent<SpriteRenderer>();
        Sprite[] rankSprites = Resources.LoadAll<Sprite>("Sprites/Rank");

        isHigh = false;
        isOnePair = false;
        isTwoPair = false;
        isThree = false;
        isFull = false;
        isFour = false;
        isStraight = false;
        isPlush = false;
        isStraightP = false;

        if (HighCard())
        {
            spriteRenderer.sprite = rankSprites[2];
            isHigh = true;
        }

        if(OnePair())
        {
            spriteRenderer.sprite = rankSprites[3];
            isOnePair = true;
        }

        if(TwoPair())
        {
            spriteRenderer.sprite = rankSprites[8];
            isTwoPair = true;
        }

        if(ThreeOfKind())
        {
            spriteRenderer.sprite = rankSprites[7];
            isThree = true;
        }

        if(FullHouse())
        {
            spriteRenderer.sprite = rankSprites[1];
            isFull = true;
        }

        if(Straight())
        {
            spriteRenderer.sprite = rankSprites[5];
            isStraight = true;
        }

        if(FourOfKind())
        {
            spriteRenderer.sprite = rankSprites[0];
            isFour = true;
        }
        
        if(Plush())
        {
            spriteRenderer.sprite = rankSprites[4];
            isPlush = true;
        }

        if(StraightPlush())
        {
            spriteRenderer.sprite = rankSprites[6];
            isStraightP = true;
        }
    }

    public void GetNumberOfSuit()   // 플레이어 핸드 카드들의 문양 갯수 확인 함수
    {   
        heartSum = 0;
        spadeSum = 0;
        diamondSum = 0;
        clubSum = 0;

        for(int i = 0; i<5; i++)
        {
            if(playerHand[i].mySuit == Card.SUIT.HEARTS)
            heartSum++;

            if(playerHand[i].mySuit == Card.SUIT.SPADES)
            spadeSum++;

            if(playerHand[i].mySuit == Card.SUIT.DIAMONDS)
            diamondSum++;

            if(playerHand[i].mySuit == Card.SUIT.CLUBS)
            clubSum++;
        }
    }

    private bool HighCard()         // 하이 인가? (= 아무런 족보도 충족하지 못하였을 때)
    {
        if( !OnePair()      &&  
            !TwoPair()      &&
            !ThreeOfKind()  &&
            !FullHouse()    &&
            !FourOfKind()   &&
            !Straight()     &&
            !Plush()        &&
            !StraightPlush()
        )
        return true;

        else
        {
            return false;
        }
    }

    private bool OnePair()          // 원 페어인가?
    {
        if(playerHand[0].myRank == playerHand[1].myRank || playerHand[0].myRank == playerHand[2].myRank || playerHand[0].myRank == playerHand[3].myRank || playerHand[0].myRank == playerHand[4].myRank)
            return true;
        else if(playerHand[1].myRank == playerHand[2].myRank || playerHand[1].myRank == playerHand[3].myRank || playerHand[1].myRank == playerHand[4].myRank)
            return true;
        else if(playerHand[2].myRank == playerHand[3].myRank || playerHand[2].myRank == playerHand[4].myRank)
            return true;
        else if(playerHand[3].myRank == playerHand[4].myRank)
            return true;

        else
        {
            return false;
        }
    }

    private bool TwoPair()          // 투 페어인가?
    {   
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[2].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[2].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[3].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[2].myRank && playerHand[3].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[3].myRank && playerHand[1].myRank == playerHand[2].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[3].myRank && playerHand[1].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[3].myRank && playerHand[2].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[4].myRank && playerHand[1].myRank == playerHand[2].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[4].myRank && playerHand[1].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[4].myRank && playerHand[2].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[1].myRank == playerHand[2].myRank && playerHand[3].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[1].myRank == playerHand[3].myRank && playerHand[2].myRank == playerHand[4].myRank)
            return true;    
        if(playerHand[1].myRank == playerHand[4].myRank && playerHand[2].myRank == playerHand[3].myRank)
            return true;
        
        else
        {
            return false;
        }
    }

    private bool ThreeOfKind()      // 트리플인가?
    {   
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[2].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[2].myRank && playerHand[0].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[2].myRank && playerHand[0].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[3].myRank && playerHand[0].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[1].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[1].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[1].myRank == playerHand[3].myRank && playerHand[1].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[2].myRank == playerHand[3].myRank && playerHand[2].myRank == playerHand[4].myRank)
            return true;

        else
        {
            return false;
        }
    }

    private bool FullHouse()        // 풀 하우스인가?
    {
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[2].myRank == playerHand[3].myRank && playerHand[2].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[3].myRank && playerHand[1].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[3].myRank && playerHand[1].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[0].myRank == playerHand[4].myRank && playerHand[1].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[1].myRank == playerHand[2].myRank && playerHand[0].myRank == playerHand[3].myRank && playerHand[0].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[1].myRank == playerHand[3].myRank && playerHand[0].myRank == playerHand[2].myRank && playerHand[0].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[1].myRank == playerHand[4].myRank && playerHand[0].myRank == playerHand[2].myRank && playerHand[0].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[2].myRank == playerHand[3].myRank && playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[4].myRank)
            return true;
        if(playerHand[2].myRank == playerHand[4].myRank && playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[3].myRank)
            return true;
        if(playerHand[3].myRank == playerHand[4].myRank && playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[2].myRank)
            return true;

        else
        {
            return false;
        }
    }

    private bool Straight()         // 스트레이트인가?
    {
        if( playerHand[0].myRank + 1 == playerHand[1].myRank &&
            playerHand[1].myRank + 1 == playerHand[2].myRank &&
            playerHand[2].myRank + 1 == playerHand[3].myRank &&
            playerHand[3].myRank + 1 == playerHand[4].myRank
        )   return true;

        else
        {
            return false;
        }
    }

    private bool FourOfKind()       // 포 카드인가?
    {
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[2].myRank && playerHand[0].myRank == playerHand[3].myRank)
            return true;

        else if(playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[2].myRank && playerHand[0].myRank == playerHand[4].myRank)
            return true;

        else if(playerHand[1].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[3].myRank && playerHand[1].myRank == playerHand[4].myRank)
            return true;

        else
            return false;
    }

    private bool Plush()            // 플러쉬인가?
    {
        if(heartSum == 5 || spadeSum == 5 || diamondSum == 5 || clubSum == 5)
            return true;

        else
        {
            return false;
        }
    }

    private bool StraightPlush()    // 로얄 스트레이트 플러쉬인가?
    {
       if(Plush() && Straight())
        return true;

        else
        {
            return false;
        }

    }
}