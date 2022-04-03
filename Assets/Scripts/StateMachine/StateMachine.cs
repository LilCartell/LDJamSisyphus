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
						MainScene.Instance.Ball.gameObject.SetActive(false);
						Camera.main.GetComponent<CameraControl>().SetToBasePosition();
						MainScene.Instance.ScoreContainer.SetActive(false);
						break;

					case StateType.BALL_ROLLING:
						MainScene.Instance.Ball.gameObject.SetActive(false);
						MainScene.Instance.PlacementUI.gameObject.SetActive(true);
						Camera.main.GetComponent<CameraControl>().SetToBasePosition();
						MainScene.Instance.ScoreContainer.SetActive(false);
						break;
				}
				break;

			case StateType.BALL_ROLLING:
				switch(CurrentState)
                {
					case StateType.END_TITLE_SCENE:
						SceneManager.LoadScene("MainScene");
						MainScene.Instance.PrepareBallRoll();
						break;

					case StateType.PLACING_OBJECTS:
						MainScene.Instance.PrepareBallRoll();
						break;

                }
				break;
        }
		CurrentState = newState;
    }
}