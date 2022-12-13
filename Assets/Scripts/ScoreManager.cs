using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI textM;
    public TextMeshProUGUI text;
    int score1;
    int score2;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int mushValue)
    {
        score1 += mushValue;
        textM.text = "X" + score1.ToString();
    }

    public void KillScore(int killCount)
    {
        score2 += killCount;
        text.text = "X" + score2.ToString();
    }
}