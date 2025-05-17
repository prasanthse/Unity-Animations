using UnityEngine;

public class AlienController : MonoBehaviour
{
    private Animator animator;

    private int SPEED = Animator.StringToHash("Speed");
    private float currentSpeed;

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
                currentSpeed += Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, 1f);
            }
            else if(currentSpeed > 0.5f)
            {
                currentSpeed -= Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0.5f);
            }
            else
            {
                currentSpeed += Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, 0.5f);
            }

            animator.SetFloat(SPEED, currentSpeed);
        }
        else if(currentSpeed > 0)
        {
            currentSpeed -= Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0);

            animator.SetFloat(SPEED, currentSpeed);
        }
    }
}