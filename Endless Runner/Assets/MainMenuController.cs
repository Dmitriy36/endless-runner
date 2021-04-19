using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private GameObject[] panels;
    private GameObject[] mmButtons;

    private void Start()
    {
        panels = GameObject.FindGameObjectsWithTag("SubPanel");
        mmButtons = GameObject.FindGameObjectsWithTag("MMButton");

        foreach(GameObject p in panels)
        {
            p.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void ClosePanel(Button button)
    {
        button.gameObject.transform.parent.gameObject.SetActive(false);
        foreach (GameObject b in mmButtons)
        {
            b.SetActive(true);
        }
    }

    public void OpenPanel(Button button)
    {
        button.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        foreach (GameObject b in mmButtons)
        {
            if(b != button.gameObject)
            b.SetActive(false);
        }
    }

    //public void CloseOptionsPanel()
    //{
    //    optionsPanel.SetActive(false);
    //}

    //public void OpenOptionsPanel()
    //{
    //    optionsPanel.SetActive(true);
    //}

    //public void CloseStatisticsPanel()
    //{
    //    statisticsPanel.SetActive(false);
    //}

    //public void OpenStatisticsPanel()
    //{
    //    statisticsPanel.SetActive(true);
    //}

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

}
