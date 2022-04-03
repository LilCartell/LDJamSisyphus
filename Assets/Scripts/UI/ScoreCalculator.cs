using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Text ScoreText;

    public float Timer { get; private set; }

    public GameObject HighscoreScript;

    void Update ()
    {
        if(StateMachine.Instance.CurrentState == StateType.BALL_ROLLING)
        {
            Timer += Time.deltaTime;
            var timeSpan = TimeSpan.FromSeconds(Timer);
            ScoreText.text = string.Format("{0:D2}'{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
    }

    public void SubmitScore()
    {
        GameSession.Instance.LastScore = Timer;
        String Pseudo = GameSession.Instance.Pseudo;
        int scoreToSubmit = (int) GameSession.Instance.LastScore;
        Highscores.AddNewHighscore(Pseudo, scoreToSubmit);
    }

    public void ResetScore()
    {
        Timer = 0;
    }
}
