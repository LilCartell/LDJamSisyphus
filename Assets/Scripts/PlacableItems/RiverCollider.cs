using UnityEngine;

public class RiverCollider : MonoBehaviour
{
    private void OnCollisionEnter()
    {
        var ballRigidBody = MainScene.Instance.Ball.GetComponent<Rigidbody>();
        ballRigidBody.useGravity = false;
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
    }
}