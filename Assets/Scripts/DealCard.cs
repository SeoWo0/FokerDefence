using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealCard : DeckCard
{
    List<Card> cardList = new List<Card>();         // DeckList 
    public Card[] playerHand;                       // 플레이어가 실제로 가지고있는 다섯장의 카드
    public enum HANDRESULT                          // 플레이어의 카드 결과 
    {
        HIGH,
        ONEPAIR,
        TWOPAIR,
        THREEOFKIND,
        FULLHOUSE,
        STRAIGHT,
        FOUROFKIND,
        PLUSH,
        STRAIGHTPLUSH
    }

    public int heartSum;                            
    public int spadeSum;
    public int clubSum;
    public int diamondSum;

    public DealCard()                               // PlayerHand에 5장의 배열 생성
    {
        playerHand = new Card[5];
    }

    private void Start() {
        Deal();
    }

    private void Update() {
        EvaluateHand();
    }

    public void Deal()
    {   
        SetUpDeck();    // 덱을 만들고 카드를 섞음
        ResetCardList();
        GetHand();
    }

    public void ResetCardList()
    {      
        cardList.Clear();

        for(int i=0; i<getDecK.Length; i++)
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
            GameManager.instance.handCardObjects[i].GetComponent<SpriteRenderer>().flipX = true;                    // X 축 뒤집기        

            cardList.Remove(playerHand[i]);
        }
    }

    public void ChangeOne()
    {   
        int randomCardNum = Random.Range(0, 52);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeOne();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[0] = card;                           // 플레이어 핸드 첫번째 패에 (= 가장 왼쪽) 새로운 카드로 교체
        cardList.Remove(playerHand[0]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)

        GameManager.instance.handCardObjects[0].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        GameManager.instance.handCardObjects[0].GetComponent<SpriteRenderer>().flipX = true;            // 카드의 Sprite X 축 뒤집기
        //GameManager.instance.changeButtons[0].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        GameManager.instance.changeButtons[0].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색
    }

    public void ChangeTwo()
    {   
        int randomCardNum = Random.Range(0, 52);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeTwo();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[1] = card;                           
        cardList.Remove(playerHand[1]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)

        GameManager.instance.handCardObjects[1].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        GameManager.instance.handCardObjects[1].GetComponent<SpriteRenderer>().flipX = true;            // 카드의 Sprite X 축 뒤집기
        //GameManager.instance.changeButtons[1].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        GameManager.instance.changeButtons[1].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색
    }

    public void ChangeThree()
    {   
        int randomCardNum = Random.Range(0, 52);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeThree();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[2] = card;                           
        cardList.Remove(playerHand[2]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)
        GameManager.instance.handCardObjects[2].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        GameManager.instance.handCardObjects[2].GetComponent<SpriteRenderer>().flipX = true;            // 카드의 Sprite X 축 뒤집기
        //GameManager.instance.changeButtons[2].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        GameManager.instance.changeButtons[2].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색
    }

    public void ChangeFour()
    {   
        int randomCardNum = Random.Range(0, 52);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeFour();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[3] = card;                           
        cardList.Remove(playerHand[3]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)
        GameManager.instance.handCardObjects[3].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        GameManager.instance.handCardObjects[3].GetComponent<SpriteRenderer>().flipX = true;            // 카드의 Sprite X 축 뒤집기
        //GameManager.instance.changeButtons[3].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        GameManager.instance.changeButtons[3].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색
        
    }

    public void ChangeFive()
    {   
        int randomCardNum = Random.Range(0, 52);

        if(!cardList.Contains(getDecK[randomCardNum]))  // 만약 cardList에 getDecK[randomCardNum 이 포함되어있지않으면 함수 재실행
        ChangeFive();

        Card card = getDecK[randomCardNum];             // 새로운 카드 뽑기
        card.myRank = getDecK[randomCardNum].myRank;    // 새로운 카드에 Rank 값 넣기
        card.mySuit = getDecK[randomCardNum].mySuit;    // 새로운 카드에 Suit 값 넣기

        playerHand[4] = card;                           
        cardList.Remove(playerHand[4]);                 // 덱리스트에서 뽑은 카드를 삭제 (= 중복 방지)
        GameManager.instance.handCardObjects[4].GetComponent<SpriteRenderer>().sprite = card.sprite;    // 카드의 SpriteRenderer 컴포넌트 가져와 Sprite 적용
        GameManager.instance.handCardObjects[4].GetComponent<SpriteRenderer>().flipX = true;            // 카드의 Sprite X 축 뒤집기
        //GameManager.instance.changeButtons[4].GetComponent<Button>().interactable = false;              // 버튼 한번 누르면 비활성화
        GameManager.instance.changeButtons[4].GetComponent<Image>().color = Color.red;                  // 버튼 한번 누르면 빨강색
    }

    

    public void EvaluateHand()
    {
        SpriteRenderer spriteRenderer = GameManager.instance.handRanking.GetComponent<SpriteRenderer>();
        Sprite[] rankSprites = Resources.LoadAll<Sprite>("Sprites/Rank");

        if(HighCard())
        {
            spriteRenderer.sprite = rankSprites[2];
        }

        if(OnePair())
        {
            spriteRenderer.sprite = rankSprites[3];
        }

        if(TwoPair())
        {
            spriteRenderer.sprite = rankSprites[8];
        }

        if(ThreeOfKind())
        {
            spriteRenderer.sprite = rankSprites[7];
        }

        if(FullHouse())
        {
            spriteRenderer.sprite = rankSprites[1];
        }

        if(Straight())
        {
            spriteRenderer.sprite = rankSprites[5];
        }

        if(FourOfKind())
        {
            spriteRenderer.sprite = rankSprites[0];
        }
        
        if(Plush())
        {
            spriteRenderer.sprite = rankSprites[4];
        }

        if(StraightPlush())
        {
            spriteRenderer.sprite = rankSprites[6];
        }
    }

    public void GetNumberOfSuit()
    {   
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

    private bool HighCard()     // 하이 인가? (= 아무런 족보도 충족하지 못하였을 때)
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

    private bool OnePair()      // 원 페어인가?
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

    private bool TwoPair()      // 투 페어인가?
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
        else
        {
            return false;
        }
    }

    private bool ThreeOfKind()       // 트리플인가?
    {   
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[2].myRank)
            return true;
        if(playerHand[1].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[3].myRank)
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

    private bool FourOfKind()         // 포 카드인가?
    {
        if(playerHand[0].myRank == playerHand[1].myRank && playerHand[0].myRank == playerHand[2].myRank && playerHand[0].myRank == playerHand[3].myRank)
            return true;

        else if(playerHand[1].myRank == playerHand[2].myRank && playerHand[1].myRank == playerHand[3].myRank && playerHand[1].myRank == playerHand[4].myRank)
            return true;

        else
            return false;
    }

    private bool Plush()
    {
        if(heartSum == 5 && spadeSum == 5 && diamondSum == 5 && clubSum == 5)
            return true;

        else
        {
            return false;
        }
    }

    private bool StraightPlush()            // 로얄 스트레이트 플러쉬인가?
    {
       if(Plush() && Straight())
        return true;

        else
        {
            return false;
        }

    }
}