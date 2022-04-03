using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float DistanceFactorWhenPlacingObjects;
    public float MovementSpeedFactor;
    public float UpperLimit;
    public float DownLimit;
    public float LeftLimit;
    public float RightLimit;

    private float _totalDownFactor;
    private float _totalLeftFactor;
    private float _initialSize;
    private Vector3 _downDirection;
    private Vector3 _leftDirection;
    private Vector3 _initialOffsetToTarget;


    private void Start()
    {
        _downDirection = MainScene.Instance.Ball.transform.right;
        _leftDirection = MainScene.Instance.Ball.transform.up;
        _initialOffsetToTarget = this.transform.position - target.position;
        _initialSize = this.GetComponent<Camera>().orthographicSize;
    }

    private void Update()
    {
        if(StateMachine.Instance.CurrentState == StateType.PLACING_OBJECTS)
        {
            bool anyDirectionKeyPressed = false;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                _totalDownFactor -= MovementSpeedFactor;
                anyDirectionKeyPressed = true;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                _totalDownFactor += MovementSpeedFactor;
                anyDirectionKeyPressed = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _totalLeftFactor -= MovementSpeedFactor;
                anyDirectionKeyPressed = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _totalLeftFactor += MovementSpeedFactor;
                anyDirectionKeyPressed = true;
            }

            if(!anyDirectionKeyPressed
                && (!EventSystem.current.IsPointerOverGameObject()
                    || MainScene.Instance.IsDraggingObject))//Test for mouse movements if no direction key and not browsing items
            {
                float xRatio = Input.mousePosition.x / Screen.width;
                float yRatio = Input.mousePosition.y / Screen.height;
                if (xRatio > 0.9 && xRatio < 1.05)
                    _totalLeftFactor -= MovementSpeedFactor;
                else if (xRatio < 0.1 && xRatio > -0.05)
                    _totalLeftFactor += MovementSpeedFactor;

                if (yRatio > 0.9 && yRatio < 1.05)
                    _totalDownFactor -= MovementSpeedFactor;
                else if (yRatio < 0.1 && yRatio > -0.05)
                    _totalDownFactor += MovementSpeedFactor;
            }

            _totalDownFactor = Mathf.Clamp(_totalDownFactor, UpperLimit, DownLimit);
            _totalLeftFactor = Mathf.Clamp(_totalLeftFactor, RightLimit, LeftLimit);

            this.transform.position = target.transform.position + _initialOffsetToTarget
                                      + _totalDownFactor * _downDirection
                                      + _totalLeftFactor * _leftDirection;
        }
        else
        {
            this.transform.position = target.transform.position + _initialOffsetToTarget;
        }
    }

    public void SetToBasePosition()
    {
        _totalDownFactor = 0;
        _totalLeftFactor = 0;
        this.GetComponent<Camera>().orthographicSize = _initialSize * DistanceFactorWhenPlacingObjects;
    }

    public void SetToRollingPosition()
    {
        this.GetComponent<Camera>().orthographicSize = _initialSize;
    }
}
