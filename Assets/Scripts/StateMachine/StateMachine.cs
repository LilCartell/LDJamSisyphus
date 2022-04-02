using UnityEngine;

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
			case StateType.PLACING_OBJECTS:
				switch(CurrentState)
				{
					case StateType.NONE:
					case StateType.TITLE_SCREEN:
						MainScene.Instance.Ball.gameObject.SetActive(false);
						break;

					case StateType.BALL_ROLLING:
						MainScene.Instance.Ball.gameObject.SetActive(false);
						MainScene.Instance.PlacementUI.gameObject.SetActive(true);
						break;
				}
				break;

			case StateType.BALL_ROLLING:
				switch(CurrentState)
                {
					case StateType.PLACING_OBJECTS:
						MainScene.Instance.PlacementUI.gameObject.SetActive(false);
						MainScene.Instance.SetBallToInitPosition();
						MainScene.Instance.Ball.gameObject.SetActive(true);
						break;
                }
				break;
        }
		CurrentState = newState;
    }
}