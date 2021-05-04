using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameData : MonoBehaviour
{
    public static GameData singleton;
    public TMP_Text scoreText = null;
    [SerializeField] private int score = 0;

    public GameObject musicSlider;
    public GameObject soundSlider;

    private void Awake()
    {        
        if(singleton == null)
        {
            singleton = this;
        }        
        else
        {
            Destroy(gameObject);
        }

        GameObject[] gd = GameObject.FindGameObjectsWithTag("GameData");

        if(gd.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        //PlayerPrefs.SetInt("Score", 0);
    }

    private void Start()
    {
        musicSlider.GetComponent<UpdateMusic>().Start();
        musicSlider.GetComponent<UpdateMusic>().Start();
    }

    public void UpdateScore(int s)
    {
        score += s;
        PlayerPrefs.SetInt("Score", score);
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

}

