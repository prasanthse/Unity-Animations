using UnityEngine;

public class Alien1DAnimation : MonoBehaviour
{
    private Animator animator;

    private int SPEED_HASH = Animator.StringToHash("Speed");
    private float currentSpeed;

    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentSpeed = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed += Time.deltaTime * acceleration;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, 1f);
            }
            else if(currentSpeed > 0.5f)
            {
                currentSpeed -= Time.deltaTime * deceleration;
                currentSpeed = Mathf.Max(currentSpeed, 0.5f);
            }
            else
            {
                currentSpeed += Time.deltaTime * acceleration;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, 0.5f);
            }

            animator.SetFloat(SPEED_HASH, currentSpeed);
        }
        else if(currentSpeed > 0)
        {
            currentSpeed -= Time.deltaTime * deceleration;
            currentSpeed = Mathf.Max(currentSpeed, 0);

            animator.SetFloat(SPEED_HASH, currentSpeed);
        }
    }
}