using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActiveManager : MonoBehaviour
{
    public static UIActiveManager   instance {get; private set;}

    public Button[]                 pokerChangeButtons;
    public Button                   highQButton;
    public Button                   oneTwoThreeButton;
    [SerializeField]
    private GameObject              pokerUI;
    [SerializeField]
    private GameObject              gameUI;
    [SerializeField]
    private GameObject              unitInfoUI;       
    [SerializeField]
    private GameObject              combineUI;

    private void Awake() {
        instance = this;
    }

    public void PokerUIOff()
    {   
        pokerUI.SetActive(false);
    }

    public void PokerUIOn()
    {
        pokerUI.SetActive(true);
    }

    public void GameUIOff()
    {
        gameUI.SetActive(false);
    }

    public void GameUIOn()
    {
        gameUI.SetActive(true);
    }

    public void UnitInfoOff()
    {
        unitInfoUI.SetActive(false);
    }

    // public void CombineUIOff()
    // {
    //     combineUI.SetActive(false);
    // }

}

