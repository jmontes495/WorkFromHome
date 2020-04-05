using UnityEngine;
using UnityEngine.UI;

public class ChairImage : MonoBehaviour
{
    [SerializeField] private SpriteRenderer chair;

    void Start()
    {
        
    }

    public void UpdateChair()
    {
        Debug.Log("Updated Chair");
    }
}
