using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject panelHelp;
    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelStats;

    int maxLives = 3;

    private void Start()
    {
        if(panelHelp != null)
            panelHelp.SetActive(false);

        if (panelHelp != null)
            panelOptions.SetActive(false);

        if (panelHelp != null)
            panelStats.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void CloseHelpPanel()
    {
        panelHelp.SetActive(false);
    }

    public void OpenHelpPanel()
    {
        panelHelp.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        panelOptions.SetActive(false);
    }

    public void OpenOptionsPanel()
    {
        panelOptions.SetActive(true);
    }

    public void CloseStatisticsPanel()
    {
        panelStats.SetActive(false);
    }

    public void OpenStatisticsPanel()
    {
        panelStats.SetActive(true);
    }

    public void LoadGameScene()
    {
        PlayerPrefs.SetInt("Lives", maxLives);
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
