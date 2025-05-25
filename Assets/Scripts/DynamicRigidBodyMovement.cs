using UnityEngine;

public class DynamicRigidBodyMovement : MonoBehaviour
{
    private new Rigidbody rigidbody;
    [SerializeField] private float force;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = Vector3.back * force;
        velocity.y = rigidbody.linearVelocity.y;

        rigidbody.linearVelocity = velocity;
    }
}