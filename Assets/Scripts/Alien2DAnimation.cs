using UnityEngine;

public class Alien2DAnimation : MonoBehaviour
{
    private Animator animator;

    private int SPEED_X_HASH = Animator.StringToHash("Speed X");
    private int SPEED_Z_HASH = Animator.StringToHash("Speed Z");

    private float currentXSpeed;
    private float currentZSpeed;

    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Move forward
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentZSpeed += Time.deltaTime * acceleration;
                currentZSpeed = Mathf.Clamp(currentZSpeed, 0, 1f);
            }
            else if (currentZSpeed > 0.5f)
            {
                currentZSpeed -= Time.deltaTime * deceleration;
                currentZSpeed = Mathf.Max(currentZSpeed, 0.5f);
            }
            else
            {
                currentZSpeed += Time.deltaTime * acceleration;
                currentZSpeed = Mathf.Clamp(currentZSpeed, 0, 0.5f);
            }
        }
        else if(currentZSpeed > 0)
        {
            currentZSpeed -= Time.deltaTime * deceleration;
            currentZSpeed = Mathf.Max(currentZSpeed, 0);
        }

        bool leftKeyPressed = Input.GetKey(KeyCode.A);
        bool rightKeyPressed = Input.GetKey(KeyCode.D);

        // Move left
        if (leftKeyPressed)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentXSpeed += Time.deltaTime * acceleration;
                currentXSpeed = Mathf.Clamp(currentXSpeed, 0, 1f);
            }
            else if (currentXSpeed > 0.5f)
            {
                currentXSpeed -= Time.deltaTime * deceleration;
                currentXSpeed = Mathf.Max(currentXSpeed, 0.5f);
            }
            else
            {
                currentXSpeed += Time.deltaTime * acceleration;
                currentXSpeed = Mathf.Clamp(currentXSpeed, 0, 0.5f);
            }
        }

        // Move right
        if (rightKeyPressed)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentXSpeed -= Time.deltaTime * acceleration;
                currentXSpeed = Mathf.Clamp(currentXSpeed, -1f, 0);
            }
            else if (currentXSpeed < -0.5f)
            {
                currentXSpeed += Time.deltaTime * deceleration;
                currentXSpeed = Mathf.Min(currentXSpeed, -0.5f);
            }
            else
            {
                currentXSpeed -= Time.deltaTime * acceleration;
                currentXSpeed = Mathf.Clamp(currentXSpeed, -0.5f, 0);
            }
        }

        if(!leftKeyPressed && !rightKeyPressed && currentXSpeed != 0)
        {
            if(currentXSpeed > 0)
            {
                currentXSpeed -= Time.deltaTime * deceleration;
                currentXSpeed = Mathf.Max(currentXSpeed, 0);
            }
            else
            {
                currentXSpeed += Time.deltaTime * deceleration;
                currentXSpeed = Mathf.Min(currentXSpeed, 0);
            }
        }
        
        animator.SetFloat(SPEED_X_HASH, currentXSpeed);
        animator.SetFloat(SPEED_Z_HASH, currentZSpeed);
    }
}