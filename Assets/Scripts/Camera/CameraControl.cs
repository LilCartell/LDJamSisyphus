using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float DistanceFactorWhenPlacingObjects;
    public float MovementSpeedFactor;

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
            if (Input.GetKey(KeyCode.UpArrow))
                _totalDownFactor -= MovementSpeedFactor;
            if (Input.GetKey(KeyCode.DownArrow))
                _totalDownFactor += MovementSpeedFactor;
            if (Input.GetKey(KeyCode.RightArrow))
                _totalLeftFactor -= MovementSpeedFactor;
            if (Input.GetKey(KeyCode.LeftArrow))
                _totalLeftFactor += MovementSpeedFactor;

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
