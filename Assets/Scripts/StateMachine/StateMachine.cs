using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
	public StateType CurrentState { get; private set; }

	public static StateMachine Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
			return;
		}

		Instance = this;

		DontDestroyOnLoad(this.gameObject);
		CurrentState = StateType.NONE;
	}

	public void TransitionToState(StateType newState)
    {
		switch(newState)
        {
			case StateType.LANGUAGE_SELECT:
				switch(CurrentState)
                {
					case StateType.NONE:
						TitleScene.Instance.LanguageButtonsPanel.gameObject.SetActive(true);
						TitleScene.Instance.EnterPseudoPanel.gameObject.SetActive(false);
						TitleScene.Instance.TitleScreen.gameObject.SetActive(false);
						TitleScene.Instance.EndTitleScreen.gameObject.SetActive(false);
						SoundManager.Instance.PlayTitleMusic();
						break;
                }
				break;

			case StateType.PSEUDO_SELECT:
				switch(CurrentState)
                {
					case StateType.LANGUAGE_SELECT:
						TitleScene.Instance.LanguageButtonsPanel.gameObject.SetActive(false);
						TitleScene.Instance.EnterPseudoPanel.gameObject.SetActive(true);
						break;
                }
				break;

			case StateType.TITLE_SCREEN:
				switch(CurrentState)
                {
					case StateType.LANGUAGE_SELECT:
						TitleScene.Instance.LanguageButtonsPanel.gameObject.SetActive(false);
						TitleScene.Instance.TitleScreen.gameObject.SetActive(true);
						break;

					case StateType.PSEUDO_SELECT:
						TitleScene.Instance.EnterPseudoPanel.gameObject.SetActive(false);
						TitleScene.Instance.TitleScreen.gameObject.SetActive(true);
						break;
				}
				break;

			case StateType.END_TITLE_SCENE:
				switch(CurrentState)
                {
					case StateType.TITLE_SCREEN:
						TitleScene.Instance.TitleScreen.gameObject.SetActive(false);
						TitleScene.Instance.EndTitleScreen.gameObject.SetActive(true);
						TitleScene.Instance.StartEndTitleScreenTimer();
						break;
                }
				break;

			case StateType.PLACING_OBJECTS:
				switch(CurrentState)
				{
					case StateType.NONE:
					case StateType.END_TITLE_SCENE:
						MainScene.Instance.PrepareObjectsPlacement();
						SoundManager.Instance.PlayPlacingMusic();
						break;
					case StateType.SCORE_SCREEN:
					case StateType.TUTORIAL:
						MainScene.Instance.ScoreScreen.gameObject.SetActive(false);
						MainScene.Instance.SisyphusDialog.gameObject.SetActive(false);
						MainScene.Instance.PrepareObjectsPlacement();
						MainScene.Instance.ReactivateDestroyedObjects();
						SoundManager.Instance.PlayPlacingMusic();
						break;
					case StateType.BALL_ROLLING:
						MainScene.Instance.PrepareObjectsPlacement();
						MainScene.Instance.ReactivateDestroyedObjects();
						SoundManager.Instance.PlayPlacingMusic();
						MainScene.Instance.StopButton.SetActive(false);
						break;
				}
				break;

			case StateType.BALL_ROLLING:
				switch(CurrentState)
                {
					case StateType.END_TITLE_SCENE:
						SceneManager.LoadScene("MainScene");
						StartCoroutine(ExecuteActionAfterAFrame(() =>
							{
								MainScene.Instance.PrepareBallRoll();
								MainScene.Instance.StopButton.SetActive(false);
								MainScene.Instance.GoButton.SetActive(false);
							}
							));
						SoundManager.Instance.PlayRollingMusic();
						break;

					case StateType.PLACING_OBJECTS:
						MainScene.Instance.PrepareBallRoll();
						MainScene.Instance.GoButton.gameObject.SetActive(false);
						SoundManager.Instance.PlayRollingMusic();
						MainScene.Instance.StopButton.SetActive(true);
						break;
                }
				break;

			case StateType.TUTORIAL:
				switch(CurrentState)
                {
					case StateType.BALL_ROLLING:
						MainScene.Instance.ScoreContainer.gameObject.SetActive(false);
						MainScene.Instance.SisyphusDialog.LoadTutorialDialog();
						MainScene.Instance.StopButton.SetActive(false);
						break;
                }
				break;

			case StateType.SCORE_SCREEN:
				switch(CurrentState)
                {
					case StateType.BALL_ROLLING:
						MainScene.Instance.ScoreCalculator.SubmitScore();
						MainScene.Instance.StopButton.SetActive(false);
						if(GameSession.Instance.HasWonOnce)
                        {
							MainScene.Instance.ScoreScreen.Load(Strings.Get("RANDOM_WIN_SCORE_SCREEN"));
							if(GameSession.Instance.LastScore >= GameSession.Instance.BestScore)
                            {
								MainScene.Instance.ScoreScreen.Load(Strings.Get("BEAT_PERSONAL_BEST_SCORE_SCREEN"));
								MainScene.Instance.SisyphusDialog.LoadPersonalBestDialog();
							}
							else if (GameSession.Instance.LastScore > MainScene.Instance.VictoryTime)
                            {
								MainScene.Instance.ScoreScreen.Load(Strings.Get("RANDOM_WIN_SCORE_SCREEN"));
							}
							else
                            {
								MainScene.Instance.ScoreScreen.Load(Strings.Get("DEFEAT_SCORE_SCREEN"));
							}
							MainScene.Instance.Leaderboard.gameObject.SetActive(true);
                        }
						else
                        {
							if(GameSession.Instance.LastScore > MainScene.Instance.VictoryTime) //Victory !
                            {
								MainScene.Instance.Leaderboard.gameObject.SetActive(true);
								MainScene.Instance.ScoreScreen.Load(Strings.Get("FIRST_WIN_SCORE_SCREEN"));
								MainScene.Instance.SisyphusDialog.LoadFirstWinDialog();
								GameSession.Instance.HasWonOnce = true;
								MainScene.Instance.ObjectiveText.SetActive(false); //Never show again
                            }
							else
                            {
								MainScene.Instance.Leaderboard.gameObject.SetActive(false);
								MainScene.Instance.ScoreScreen.Load(Strings.Get("DEFEAT_SCORE_SCREEN"));
                            }
                        }
						break;
                }
				break;
        }
		CurrentState = newState;
    }

	private IEnumerator ExecuteActionAfterAFrame(Action action)
    {
		yield return null;
		action.Invoke();
    }
}