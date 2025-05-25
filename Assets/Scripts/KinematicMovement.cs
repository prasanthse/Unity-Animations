using UnityEngine;

public class KinematicMovement : MonoBehaviour
{
    private new Rigidbody rigidbody;
    [SerializeField] private float speed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + Vector3.back * speed * Time.fixedDeltaTime);
    }
}