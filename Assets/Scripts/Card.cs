using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum SUIT
    {
        SPADES,
        HEARTS,
        CLUBS,
        DIAMONDS
    }

    public enum RANK
    {
        TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN,
        JACK, QUEEN, KING, ACE
    }

    public SUIT mySuit { get; set;}
    public RANK myRank { get; set;} 

}
