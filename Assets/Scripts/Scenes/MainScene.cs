using UnityEngine;

public class MainScene : GenericScene
{
    public PlacableItemsUI PlacementUI;
    public GameObject GoButton;
    public GameObject StopButton;
    public GameObject Ball;
    public GameObject ScoreContainer;
    public ScoreCalculator ScoreCalculator;
    public SisyphusDialog SisyphusDialog;
    public ScoreScreen ScoreScreen;
    public LeaderBoard Leaderboard;
    public Transform PlacableItemsRoot;
    public Vector3 OffsetForPlacingItems;
    public float MinDistanceBetweenItems;
    public float BallNotMovingMaxTime;
    public float VictoryTime;
    public float MaxPoints;

    public float CurrentPoints { get; private set; }

    [HideInInspector]
    public bool IsDragging2DObject;

    public static MainScene Instance { get; private set; }

    private Vector3 _firstBallPosition;
    private Quaternion _firstBallRotation;

    private float _timeSinceNoBallMovement;
    private Vector3 _ballPositionLastFrame;

    private void Awake()
    {
        Instance = this;
        _firstBallPosition = Ball.transform.position;
        _firstBallRotation = Ball.transform.rotation;
        CurrentPoints = MaxPoints;
    }

    private void Update()
    {
        if(StateMachine.Instance.CurrentState == StateType.BALL_ROLLING)
        {
            if (_ballPositionLastFrame == Ball.transform.position)
                _timeSinceNoBallMovement += Time.deltaTime;
            else
                _timeSinceNoBallMovement = 0;
            _ballPositionLastFrame = Ball.transform.position;
            if(_timeSinceNoBallMovement > BallNotMovingMaxTime)
            {
                if (GameSession.Instance.SawTutorial)
                    StateMachine.Instance.TransitionToState(StateType.SCORE_SCREEN);
                else
                {
                    StateMachine.Instance.TransitionToState(StateType.TUTORIAL);
                    GameSession.Instance.SawTutorial = true;
                }
            }
        }
    }

    public void SetBallToInitPosition()
    {
        Ball.transform.position = _firstBallPosition;
        Ball.transform.rotation = _firstBallRotation;
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void OnStartButtonClick()
    {
        StateMachine.Instance.TransitionToState(StateType.BALL_ROLLING);
    }

    public void OnStopButtonClick()
    {
        StateMachine.Instance.TransitionToState(StateType.PLACING_OBJECTS);
    }

    public void PrepareObjectsPlacement()
    {
        PlacementUI.gameObject.SetActive(true);
        Ball.gameObject.SetActive(false);
        Camera.main.GetComponent<CameraControl>().SetToBasePosition();
        ScoreContainer.SetActive(false);
        GoButton.gameObject.SetActive(true);
        StopButton.SetActive(false);
        SetBallToInitPosition();
    }

    public void ReactivateDestroyedObjects()//Reactivate objects that have been deactivated during roll
    {
        foreach (Transform createdObject in PlacableItemsRoot)
        {
            var placable3DComponent = createdObject.GetComponent<PlacableItemDisplayer3D>();
            if (placable3DComponent != null && placable3DComponent.WasCreatedFromConstructionScreen)
                placable3DComponent.gameObject.SetActive(true);

            var autoDestructComponent = createdObject.GetComponent<ItemAutoDestruct>();
            if (autoDestructComponent != null)
                autoDestructComponent.ResetCollisions();
        }
    }

    public void PrepareBallRoll()
    {
        PlacementUI.gameObject.SetActive(false);
        SetBallToInitPosition();
        Ball.gameObject.SetActive(true);
        Camera.main.GetComponent<CameraControl>().SetToRollingPosition();
        ScoreContainer.GetComponentInChildren<ScoreCalculator>().ResetScore();
        ScoreContainer.SetActive(true);
        Ball.GetComponent<Rigidbody>().useGravity = true;
    }

    public void UpdatePoints(int modification)
    {
        CurrentPoints += modification;
        PlacementUI.RefreshPoints();
    }

    public float GetBestScore()
    {
        return GameSession.Instance.BestScore;
    }

    public int GetMagicBallPositionRandomSeed()
    {
        return Ball.transform.position.GetHashCode();
    }

    protected override StateType GetFirstState()
    {
        return StateType.PLACING_OBJECTS;
    }
}