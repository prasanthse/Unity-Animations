using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
    private Material mat;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    public void TurnRed()
    {
        mat.color = new Color(1, 0, 0, 1);
    }

    public void TurnGreen()
    {
        mat.color = new Color(0, 1, 0, 1);
    }
}