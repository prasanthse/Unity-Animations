using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RiggingAimAnimation : MonoBehaviour
{
    [SerializeField] private Rig rig;
    private float targetWeight = 0;

    [SerializeField] private Transform target;

    private void Start()
    {
        rig.weight = 0;
    }

    private void Update()
    {
        float targetDistance = Vector3.Distance(transform.localPosition, target.localPosition);

        if(targetDistance < 5 && transform.localPosition.z > target.localPosition.z)
        {
            targetWeight = 1;
        }
        else
        {
            targetWeight = 0;
        }

        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime);

        target.localPosition += Vector3.forward * Time.deltaTime;
    }
}