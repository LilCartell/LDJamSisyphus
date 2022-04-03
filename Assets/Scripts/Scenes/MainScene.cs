using UnityEngine;

public class MainScene : GenericScene
{
    public GameObject PlacementUI;
    public GameObject GoButton;
    public GameObject Ball;
    public GameObject ScoreContainer;
    public Transform PlacableItemsRoot;
    public Vector3 OffsetForPlacingItems;

    [HideInInspector]
    public bool IsDraggingObject;

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

    protected override StateType GetFirstState()
    {
        return StateType.PLACING_OBJECTS;
    }
}