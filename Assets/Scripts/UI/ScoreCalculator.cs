using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{   
    private float seconds;
    private float tempScore = 0;
    public int Score = 0;
    public bool pause;

    void Update ()
    {
        if(!pause)
        {
            seconds += Time.deltaTime;
            tempScore = seconds * 20;
            Score = (int) tempScore;
            gameObject.GetComponent<Text>().text = Score + "";
        }
    }

    public void ResetScore()
    {
        Score = 0;
        tempScore = 0;
        seconds = 0;
    }
}
