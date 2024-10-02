using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour,ISetScore
{
    short Score;

   
    public short setScoreNumber(string glassesName)
    {      
        switch (glassesName)
        {
            case "Glass red":
                Score += 30;

                break;

            case "Glass yellow":
                Score += 20;
                break;

            case "Glass blue":

                Score += 10;

                break;

        }

       

        return Score;

    }




    public short appearScoreNumber()
    {
        return Score;
    }








}
