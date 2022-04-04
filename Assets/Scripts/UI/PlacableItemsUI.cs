using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacableItemsUI : MonoBehaviour
{
    public PlacableItemDisplayer2D placableItemDisplayerPrefab;
    public Transform itemsRoot;
    public Text CurrentPoints;

    private List<PlacableItemDisplayer2D> _items;

    private void Awake()
    {
        _items = new List<PlacableItemDisplayer2D>();
        foreach(var archetype in GameDatas.Instance.GetPlacableItemArchetypes())
        {
            var placableItemDisplayer = Instantiate(placableItemDisplayerPrefab);
            placableItemDisplayer.transform.parent = itemsRoot;
            placableItemDisplayer.transform.localScale = Vector3.one;
            placableItemDisplayer.GetComponent<PlacableItemDisplayer2D>().InitializeOriginalWithItemType(archetype.ItemType);
            _items.Add(placableItemDisplayer.GetComponent<PlacableItemDisplayer2D>());
        }
    }

    private void Start()
    {
        RefreshPoints();
    }

    public void RefreshPoints()
    {
        CurrentPoints.text = MainScene.Instance.CurrentPoints.ToString();
        foreach (var item in _items)
            item.RefreshAvailable();
    }
}