using UnityEngine;
using UnityEngine.UI;

public class ComputerImage : MonoBehaviour
{
    [SerializeField] private SpriteRenderer computer;

    void Start()
    {
        
    }

    public void UpdateComputer()
    {
        Debug.Log("Updated Computer");
    }
}
