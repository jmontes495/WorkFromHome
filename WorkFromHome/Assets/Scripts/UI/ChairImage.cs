using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChairImage : MonoBehaviour
{
    [SerializeField] private SpriteRenderer chair;
    [SerializeField] private List<Sprite> chairs;

    private int currentChair;

    void Start()
    {
        currentChair = 0;
        chair.sprite = chairs[currentChair];
    }

    public void UpdateChair()
    {
        if (currentChair < chairs.Count - 1)
        {
            Debug.Log("Updated Chair");
            currentChair++;
            chair.sprite = chairs[currentChair];
        }
    }
}
