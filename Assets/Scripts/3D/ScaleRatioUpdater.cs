using UnityEngine;

[ExecuteInEditMode]
public class ScaleRatioUpdater : MonoBehaviour
{
    public Transform parent;
    public Vector3 DesiredScale;

    private void Update()
    {
        this.transform.localScale = new Vector3(DesiredScale.x / parent.lossyScale.x, DesiredScale.y / parent.lossyScale.y, DesiredScale.z / parent.lossyScale.z);
    }
}
