using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraPointers : MonoBehaviour
{
    [SerializeField] private Image leftArrow;
    [SerializeField] private Image rightArrow;


    public void ActivateLeftArrow(bool active)
    {
        leftArrow.gameObject.SetActive(active);
    }

    public void ActivateRightArrow(bool active)
    {
        rightArrow.gameObject.SetActive(active);
    }
}
