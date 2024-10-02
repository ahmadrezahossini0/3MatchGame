using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour,IHighScoremethodes
{
    ISetScore _scoreManager;
    private short Highscore;
    private short CurrentScore;




    public const string HighScoreKey = "Highscore";

    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(HighScoreKey)) 
        {
           
            Highscore = (short)PlayerPrefs.GetInt(HighScoreKey);
        }
        else 
        {

            PlayerPrefs.SetInt(HighScoreKey, 0);
            Debug.Log("we are creating highscore file ");
            Highscore =(short) PlayerPrefs.GetInt(HighScoreKey);



        }
    }

    public void SetHighscore()
    {
        if (GetCurrentScore() > Highscore) 
        {
            Highscore = CurrentScore;
            PlayerPrefs.SetInt(HighScoreKey, Highscore);
               
        }
    }

    public short GetHighscore()
    {
        return Highscore;
    }

    public short GetCurrentScore()
    {
        CurrentScore = _scoreManager.appearScoreNumber();
        return CurrentScore;
    }
}
