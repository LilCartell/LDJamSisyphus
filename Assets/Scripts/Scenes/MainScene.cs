using UnityEngine;

public class MainScene : GenericScene
{
    public GameObject PlacementUI;
    public GameObject GoButton;
    public GameObject Ball;
    public GameObject ScoreContainer;
    public Transform PlacableItemsRoot;
    public Vector3 OffsetForPlacingItems;
    public float MinDistanceBetweenItems;

    [HideInInspector]
    public bool IsDragging2DObject;

    public static MainScene Instance { get; private set; }

    private Vector3 _firstBallPosition;

    private void Awake()
    {
        Instance = this;
        _firstBallPosition = Ball.transform.position;
    }

    public void SetBallToInitPosition()
    {
        Ball.transform.position = _firstBallPosition;
    }

    public void OnStartButtonClick()
    {
        StateMachine.Instance.TransitionToState(StateType.BALL_ROLLING);
    }

    public void PrepareObjectsPlacement()
    {
        Ball.gameObject.SetActive(false);
        Camera.main.GetComponent<CameraControl>().SetToBasePosition();
        ScoreContainer.SetActive(false);
        GoButton.gameObject.SetActive(true);
    }

    public void PrepareBallRoll()
    {
        PlacementUI.gameObject.SetActive(false);
        SetBallToInitPosition();
        Ball.gameObject.SetActive(true);
        Camera.main.GetComponent<CameraControl>().SetToRollingPosition();
        ScoreContainer.GetComponentInChildren<ScoreCalculator>().ResetScore();
        ScoreContainer.SetActive(true);
    }

    protected override StateType GetFirstState()
    {
        return StateType.PLACING_OBJECTS;
    }
}