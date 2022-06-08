using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set; }

    private void Awake() {
        
        instance = this;
    }

    public GameObject[] handCardObjects;
    public GameObject handRanking;
}
