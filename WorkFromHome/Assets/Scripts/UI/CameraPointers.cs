using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraPointers : MonoBehaviour
{
    [SerializeField] private Image leftArrow;
    [SerializeField] private Image rightArrow;
    [SerializeField] private Image cryingIndicator;
    [SerializeField] private Image dirtyIndicatorLeft;
    [SerializeField] private Image dirtyIndicatorRight;

    public void ActivateLeftArrow(bool active)
    {
        leftArrow.gameObject.SetActive(active);
    }

    public void ActivateRightArrow(bool active)
    {
        rightArrow.gameObject.SetActive(active);
    }

    public void ActivateCryingIndicator(bool active)
    {
        cryingIndicator.gameObject.SetActive(active);
    }

    public void ActivateDirtyIndicatorLeft(bool active)
    {
        dirtyIndicatorLeft.gameObject.SetActive(active);
    }

    public void ActivateDirtyIndicatorRight(bool active)
    {
        dirtyIndicatorRight.gameObject.SetActive(active);
    }
}
