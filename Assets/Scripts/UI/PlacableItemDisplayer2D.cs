using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacableItemDisplayer2D : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image icon;

    private PlacableItemType _itemType;
    private bool _isCopy;
    private PlacableItemDisplayer3D _linked3DItem;

    public void InitializeOriginalWithItemType(PlacableItemType itemType)
    {
        _itemType = itemType;
        _isCopy = false;
        icon.sprite = Resources.Load<Sprite>(GameDatas.Instance.GetPlacableItemArchetypeByType(itemType).SpritePath);
    }

    public void InitializeCopyWithItemType(PlacableItemType itemType)
    {
        _itemType = itemType;
        _isCopy = true;
        _linked3DItem = ((GameObject)Instantiate(Resources.Load(GameDatas.Instance.GetPlacableItemArchetypeByType(itemType).PrefabPath))).GetComponent<PlacableItemDisplayer3D>();
        var scaleBefore = _linked3DItem.transform.localScale;
        var rotationBefore = _linked3DItem.transform.localRotation;
        _linked3DItem.transform.parent = MainScene.Instance.PlacableItemsRoot;
        _linked3DItem.transform.localScale = scaleBefore;
        _linked3DItem.transform.localRotation = rotationBefore;
        _linked3DItem.gameObject.SetActive(false);
        _linked3DItem.SetDraggedFrom2D();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!_isCopy)
        {
            var copy = (GameObject)Instantiate(this.gameObject);
            copy.GetComponent<PlacableItemDisplayer2D>().InitializeCopyWithItemType(_itemType);
            eventData.pointerDrag = copy;
            copy.transform.parent = this.transform.parent;
            copy.transform.position = this.transform.position;
            copy.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta;
            copy.GetComponent<LayoutElement>().ignoreLayout = true;
            copy.transform.localScale = Vector3.one;
            MainScene.Instance.IsDragging2DObject = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(_isCopy)
        {
            this.transform.position = eventData.position;
            _linked3DItem.OnDragToPosition(Input.mousePosition);
            Set2DVisible(!_linked3DItem.IsOnGround);
        }
    }

    private void Set2DVisible(bool visible)
    {
        GetComponent<Image>().enabled = visible;
        icon.gameObject.SetActive(visible);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(_isCopy)
        {
            _linked3DItem.OnEndDrag();
            Destroy(this.gameObject);
            MainScene.Instance.IsDragging2DObject = false;
        }
    }
}
