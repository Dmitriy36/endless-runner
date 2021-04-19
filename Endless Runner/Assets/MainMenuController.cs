using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("ScrollingWorld", LoadSceneMode.Single);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }

}
