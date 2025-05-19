using System.Collections.Generic;
using UnityEngine;

public class AnimationRetargetting : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    private int activeCharacterIndex;

    private float ticks;

    private void Start()
    {
        for(int i = 0; i < characters.Count; i++)
        {
            characters[i].SetActive(false);
        }

        activeCharacterIndex = 0;

        characters[activeCharacterIndex].SetActive(true);
    }

    private void Update()
    {
        ticks += Time.deltaTime;
        ticks = Mathf.Min(ticks, 3);

        if (ticks == 3)
        {
            ticks = 0;

            characters[activeCharacterIndex].SetActive(false);

            activeCharacterIndex++;
            activeCharacterIndex = activeCharacterIndex > characters.Count - 1 ? 0 : activeCharacterIndex;

            characters[activeCharacterIndex].SetActive(true);
        }
    }
}