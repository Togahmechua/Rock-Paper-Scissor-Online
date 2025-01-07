using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : UICanvas
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI highestScore;

    private int curScore;

    private void Start()
    {
        curScore = PlayerPrefs.GetInt("Score", 0);
        highestScore.text = PlayerPrefs.GetInt("HighestScore", 0).ToString();
    }

    public void SetScore(int num)
    {
        score.text = num.ToString();
        curScore = num;

        // Save the score to PlayerPrefs
        PlayerPrefs.SetInt("Score", num);

        // Check and update the highest score
        int highest = PlayerPrefs.GetInt("HighestScore", 0);
        if (curScore > highest)
        {
            PlayerPrefs.SetInt("HighestScore", curScore);
            highestScore.text = curScore.ToString();
        }
    }
}
