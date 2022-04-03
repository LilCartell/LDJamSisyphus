using UnityEngine;

public class PlacableItemsUI : MonoBehaviour
{
    public PlacableItemDisplayer2D placableItemDisplayerPrefab;
    public Transform itemsRoot;

    private void Awake()
    {
        foreach(var archetype in GameDatas.Instance.GetPassableItemArchetypes())
        {
            var placableItemDisplayer = Instantiate(placableItemDisplayerPrefab);
            placableItemDisplayer.transform.parent = itemsRoot;
            placableItemDisplayer.transform.localScale = Vector3.one;
            placableItemDisplayer.GetComponent<PlacableItemDisplayer2D>().InitializeOriginalWithItemType(archetype.ItemType);
        }
    }
}