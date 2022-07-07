using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealCard : DeckCard
{
    List<Card> cardList = new List<Card>();         // DeckList 
    public Card[] playerHand;                       // 플레이어가 실제로 가지고있는 다섯장의 카드
    public int heartSum;                            
    public int spadeSum;
    public int clubSum;
    public int diamondSum;
    public bool isHigh = false;
    public bool isOnePair = false;
    public bool isTwoPair = false;
    public bool isThree = false;
    public bool isFull = false;
    public bool isStaright = false;
    public bool isFour = false;
    public bool isPlush = false;
    public bool isStarightP = false;


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
        }
    }

    public void ResetDeck()
    {
        for(int i=0; i<getDecK.Count; i++)
        {
            getDecK.Clear();
        }
    }

    public void ChangeOne()         // 첫번째 패 교환
    {   
        int randomCardNum = Random.Range(0, cardList.Count);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeOne();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[0] = card;                           // 플레이어 핸드 첫번째 패에 (= 가장 왼쪽) 새로운 카드로 교체
        cardList.Remove(playerHand[0]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)

        GameManager.instance.handCardObjects[0].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        UIActiveManager.instance.pokerChangeButtons[0].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        UIActiveManager.instance.pokerChangeButtons[0].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색

        getDecK.Clear();
        
        for(int i=0; i<cardList.Count; i++)
        {
            getDecK.Add(cardList[i]);
        }

        ShuffleDeck();
    }

    public void ChangeTwo()         // 두번째 패 교환
    {   
        int randomCardNum = Random.Range(0, cardList.Count);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeTwo();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[1] = card;                           
        cardList.Remove(playerHand[1]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)

        GameManager.instance.handCardObjects[1].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        UIActiveManager.instance.pokerChangeButtons[1].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        UIActiveManager.instance.pokerChangeButtons[1].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색

        getDecK.Clear();
        
        for(int i=0; i<cardList.Count; i++)
        {
            getDecK.Add(cardList[i]);
        }

        ShuffleDeck();
    }

    public void ChangeThree()       // 세번째 패 교환
    {   
        int randomCardNum = Random.Range(0, cardList.Count);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeThree();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[2] = card;                           
        cardList.Remove(playerHand[2]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)
        GameManager.instance.handCardObjects[2].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        UIActiveManager.instance.pokerChangeButtons[2].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        UIActiveManager.instance.pokerChangeButtons[2].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색

        getDecK.Clear();
        
        for(int i=0; i<cardList.Count; i++)
        {
            getDecK.Add(cardList[i]);
        }

        ShuffleDeck();
    }

    public void ChangeFour()        // 네번째 패 교환
    {   
        int randomCardNum = Random.Range(0, cardList.Count);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeFour();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[3] = card;                           
        cardList.Remove(playerHand[3]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)
        GameManager.instance.handCardObjects[3].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        UIActiveManager.instance.pokerChangeButtons[3].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        UIActiveManager.instance.pokerChangeButtons[3].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색

        getDecK.Clear();
        
        for(int i=0; i<cardList.Count; i++)
        {
            getDecK.Add(cardList[i]);
        }

        ShuffleDeck(); 
    }

    public void ChangeFive()        // 다섯번째 패 교환
    {   
        int randomCardNum = Random.Range(0, cardList.Count);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeFive();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[4] = card;
        cardList.Remove(card);                         // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)

        GameManager.instance.handCardObjects[4].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        UIActiveManager.instance.pokerChangeButtons[4].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        UIActiveManager.instance.pokerChangeButtons[4].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색
        
        getDecK.Clear();
        
        for(int i=0; i<cardList.Count; i++)
        {
            getDecK.Add(cardList[i]);
        }

        ShuffleDeck();
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

        if(HighCard())
        {
            spriteRenderer.sprite = rankSprites[2];
            isHigh = true;
            isOnePair = false;
            isTwoPair = false;
            isThree = false;
            isFull = false;
            isFour = false;
            isStaright = false;
            isPlush = false;
            isStarightP = false;
        }

        if(OnePair())
        {
            spriteRenderer.sprite = rankSprites[3];
            isHigh = false;
            isOnePair = true;
            isTwoPair = false;
            isThree = false;
            isFull = false;
            isFour = false;
            isStaright = false;
            isPlush = false;
            isStarightP = false;
        }

        if(TwoPair())
        {
            spriteRenderer.sprite = rankSprites[8];
            isHigh = false;
            isOnePair = false;
            isTwoPair = true;
            isThree = false;
            isFull = false;
            isFour = false;
            isStaright = false;
            isPlush = false;
            isStarightP = false;
        }

        if(ThreeOfKind())
        {
            spriteRenderer.sprite = rankSprites[7];
            isHigh = false;
            isOnePair = false;
            isTwoPair = false;
            isThree = true;
            isFull = false;
            isFour = false;
            isStaright = false;
            isPlush = false;
            isStarightP = false;
        }

        if(FullHouse())
        {
            spriteRenderer.sprite = rankSprites[1];
            isHigh = false;
            isOnePair = false;
            isTwoPair = false;
            isThree = false;
            isFull = true;
            isFour = false;
            isStaright = false;
            isPlush = false;
            isStarightP = false;
        }

        if(Straight())
        {
            spriteRenderer.sprite = rankSprites[5];
            isHigh = false;
            isOnePair = false;
            isTwoPair = false;
            isThree = false;
            isFull = false;
            isFour = false;
            isStaright = true;
            isPlush = false;
            isStarightP = false;
        }

        if(FourOfKind())
        {
            spriteRenderer.sprite = rankSprites[0];
            isHigh = false;
            isOnePair = false;
            isTwoPair = false;
            isThree = false;
            isFull = false;
            isFour = true;
            isStaright = false;
            isPlush = false;
            isStarightP = false;
        }
        
        if(Plush())
        {
            spriteRenderer.sprite = rankSprites[4];
            isHigh = false;
            isOnePair = false;
            isTwoPair = false;
            isThree = false;
            isFull = false;
            isFour = false;
            isStaright = false;
            isPlush = true;
            isStarightP = false;
        }

        if(StraightPlush())
        {
            spriteRenderer.sprite = rankSprites[6];
            isHigh = false;
            isOnePair = false;
            isTwoPair = false;
            isThree = false;
            isFull = false;
            isFour = false;
            isStaright = false;
            isPlush = false;
            isStarightP = true;
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
            !ThreeOfKind()       &&
            !FullHouse()    &&
            !FourOfKind()     &&
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