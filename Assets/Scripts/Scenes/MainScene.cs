using UnityEngine;

public class MainScene : MonoBehaviour
{
    public Transform PlacableItemsRoot;    public Vector3 OffsetForPlacingItems;

    public static MainScene Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}