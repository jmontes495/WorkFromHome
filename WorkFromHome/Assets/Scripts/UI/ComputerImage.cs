using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerImage : MonoBehaviour
{
    [SerializeField] private SpriteRenderer computer;
    [SerializeField] private List<Sprite>  computers;

    private int currentComputer;

    void Start()
    {
        currentComputer = 0;
        computer.sprite = computers[currentComputer];
    }

    public void UpdateComputer()
    {
        if (currentComputer < computers.Count - 1)
        {
            Debug.Log("Updated Computer");
            currentComputer++;
            computer.sprite = computers[currentComputer];
        }
    }
}
