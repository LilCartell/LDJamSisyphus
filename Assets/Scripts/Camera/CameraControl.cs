using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    private Vector3 _offsetToTarget;

    private void Awake()
    {
        _offsetToTarget = this.transform.position - target.position;
    }

    private void Update()
    {
        this.transform.position = target.transform.position + _offsetToTarget;
    }
}
