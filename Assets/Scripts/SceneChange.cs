﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangePokerScene()
    {
        SceneManager.LoadScene("PokerScene");
    }

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}