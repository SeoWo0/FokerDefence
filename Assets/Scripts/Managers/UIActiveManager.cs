using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActiveManager : MonoBehaviour
{
    public static UIActiveManager   instance {get; private set;}
    public GameObject               pokerUI;
    public GameObject               GameUI;

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

    public void InfoUIOff()
    {
        GameUI.SetActive(false);
    }

    public void InfoUIOn()
    {
        GameUI.SetActive(true);
    }
}

