using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    public Text Commentary;
    public Text BestScore;

    public void Load(string commentary)
    {
        Commentary.text = commentary;
        var bestScore = MainScene.Instance.GetBestScore();
        var timeSpan = TimeSpan.FromSeconds(bestScore);
        BestScore.text = string.Format("{0:D2}'{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        this.gameObject.SetActive(true);
    }

    public void OnTryAgainClick()
    {
        StateMachine.Instance.TransitionToState(StateType.PLACING_OBJECTS);
    }
}