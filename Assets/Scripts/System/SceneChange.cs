using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void LoadToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadToTitleScnen()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
