using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Text ScoreText;

    public float Timer { get; private set; }

    void Update ()
    {
        Timer += Time.deltaTime;
        var timeSpan = TimeSpan.FromSeconds(Timer);
        ScoreText.text = string.Format("{0:D2}'{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }

    public void ResetScore()
    {
        Timer = 0;
    }
}
