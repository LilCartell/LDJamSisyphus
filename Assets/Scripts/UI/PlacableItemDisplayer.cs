using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacableItemDisplayer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image icon;

    private PlacableItemType _itemType;
    private bool _isCopy;
    private GameObject _linked3DItem;

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
        _linked3DItem = (GameObject)Instantiate(Resources.Load(GameDatas.Instance.GetPlacableItemArchetypeByType(itemType).PrefabPath));
        var scaleBefore = _linked3DItem.transform.localScale;
        var rotationBefore = _linked3DItem.transform.localRotation;
        _linked3DItem.transform.parent = MainScene.Instance.PlacableItemsRoot;
        _linked3DItem.transform.localScale = scaleBefore;
        _linked3DItem.transform.localRotation = rotationBefore;
        _linked3DItem.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!_isCopy)
        {
            var copy = (GameObject)Instantiate(this.gameObject);
            copy.GetComponent<PlacableItemDisplayer>().InitializeCopyWithItemType(_itemType);
            eventData.pointerDrag = copy;
            copy.transform.parent = this.transform.parent;
            copy.transform.position = this.transform.position;
            copy.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta;
            copy.GetComponent<LayoutElement>().ignoreLayout = true;
            copy.transform.localScale = Vector3.one;
            MainScene.Instance.IsDraggingObject = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(_isCopy)
        {
            this.transform.position = eventData.position;
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit result;
            int layerMask = LayerMask.GetMask("Ground");
            if (Physics.Raycast(rayCast, out result, Mathf.Infinity, layerMask))
            {
                _linked3DItem.transform.position = result.point + MainScene.Instance.OffsetForPlacingItems;
                Set2DVisible(false);
                _linked3DItem.transform.gameObject.SetActive(true);
            }
            else
            {
                Set2DVisible(true);
                _linked3DItem.transform.gameObject.SetActive(false);
            }
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
            if (_linked3DItem == null || !_linked3DItem.gameObject.activeSelf)
                Destroy(_linked3DItem.gameObject);
            Destroy(this.gameObject);
            MainScene.Instance.IsDraggingObject = false;
        }
    }
}
