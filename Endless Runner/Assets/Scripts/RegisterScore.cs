using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegisterScore : MonoBehaviour
{
    private void Awake()
    {
        GameData.singleton.scoreText = GetComponent<TMP_Text>();
        GameData.singleton.UpdateScore(0);
    }
}
