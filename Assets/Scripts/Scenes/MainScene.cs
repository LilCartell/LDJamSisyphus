using UnityEngine;

public class MainScene : MonoBehaviour
{
    public GameObject PlacementUI;
    public GameObject Ball;
    public Transform PlacableItemsRoot;
    public Vector3 OffsetForPlacingItems;

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
}