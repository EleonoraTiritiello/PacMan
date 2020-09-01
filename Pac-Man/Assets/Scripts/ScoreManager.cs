using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region VARIABLES
    public int score_;
    public int highscore;

    Text text;
    
    #endregion

    void Start()
    {
        text = GetComponent<Text>();

        score_ = 0;

        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }

    void Update()
    {
        if (score_ > highscore)
        highscore = score_;
        text.text = "" + score_;

        PlayerPrefs.SetInt("highscore", highscore);
    }

    public void AddPoints(int pointsToAdd)
    {
        score_ += pointsToAdd;
    }

    public void Reset()
    {
        score_ = 0;
    }
}

