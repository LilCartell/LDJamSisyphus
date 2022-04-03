using System.Linq;
using UnityEngine;

public class PlacableItemDisplayer3D : MonoBehaviour
{
    public SpriteRenderer NormalSpriteRenderer;
    public SpriteRenderer ErrorSpriteRenderer;
    public bool IsOnGround { get; private set; }
    public bool WasCreatedFromConstructionScreen { get; private set; }

    private bool _dragged3D;
    private bool _dragged2D;
    private bool _placementOk;

    public void SetDraggedFrom2D()
    {
        _dragged2D = true;
        WasCreatedFromConstructionScreen = true;
    }

    public void OnMouseDown()
    {
        if(!_dragged2D && WasCreatedFromConstructionScreen)
            _dragged3D = true;
    }

    public void OnMouseDrag()
    {
        if (_dragged3D && !_dragged2D) //If dragging 2D displayer, drag is already handled once
            OnDragToPosition(Input.mousePosition);
    }

    public void OnMouseUp()
    {
        if (_dragged3D && !_dragged2D)
            OnEndDrag();
    }

    public void OnDragToPosition(Vector2 mousePosition)
    {
        Ray rayCast = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit result;
        int rayCastLayerMask = LayerMask.GetMask("Ground");
        if (Physics.Raycast(rayCast, out result, Mathf.Infinity, rayCastLayerMask))
        {
            this.transform.position = result.point + MainScene.Instance.OffsetForPlacingItems;
            this.transform.gameObject.SetActive(true);
            IsOnGround = true;

            int overlapSphereLayerMask = LayerMask.GetMask("Items");
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, MainScene.Instance.MinDistanceBetweenItems, overlapSphereLayerMask);
            if(hitColliders.ToList().Exists(collider => collider.gameObject != this.gameObject))
            {
                _placementOk = false;
                NormalSpriteRenderer.enabled = false;
                ErrorSpriteRenderer.enabled = true;
            }
            else
            {
                _placementOk = true;
                NormalSpriteRenderer.enabled = true;
                ErrorSpriteRenderer.enabled = false;
            }
        }
        else
        {
            IsOnGround = false;
            _placementOk = false;
            NormalSpriteRenderer.enabled = false;
            ErrorSpriteRenderer.enabled = false;
        }
    }

    public void OnEndDrag()
    {
        _dragged2D = false;
        _dragged3D = false;

        if (!_placementOk)
            Destroy(this.gameObject);
    }
}