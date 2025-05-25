using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float speed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.Move(Vector3.back * Time.deltaTime * speed);
    }
}