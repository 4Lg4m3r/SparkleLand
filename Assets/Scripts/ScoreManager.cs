using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int mushValue)
    {
        score += mushValue;
        text.text = "X" + score.ToString();
    }

}