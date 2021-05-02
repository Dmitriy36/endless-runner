using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public TMP_Text lastScore;
    public TMP_Text highestScore;

    private void OnEnable()
    {
        // last score
        if (PlayerPrefs.HasKey("LastScore")) 
            lastScore.text = "Last Score: " + PlayerPrefs.GetInt("LastScore");
        else
            lastScore.text = "Last Score: 0";
        // high score
        if (PlayerPrefs.HasKey("HighScore"))
            highestScore.text = "Highest Score: " + PlayerPrefs.GetInt("HighScore");
        else
            highestScore.text = "Highest Score: 0";
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
