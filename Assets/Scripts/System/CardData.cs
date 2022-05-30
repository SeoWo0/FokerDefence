using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData.asset", menuName = "Card / CardData")]
public class CardData : ScriptableObject
{
    public Card.RANK cardRank;
    public Card.SUIT cardSuit;
    public Sprite sprite;
}
