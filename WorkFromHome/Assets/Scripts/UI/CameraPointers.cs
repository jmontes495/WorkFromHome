using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraPointers : MonoBehaviour
{
    [SerializeField] private Image leftArrow;
    [SerializeField] private Image rightArrow;
    [SerializeField] private Image cryingIndicator;
    [SerializeField] private Image dirtyIndicatorLeft;
    [SerializeField] private Image dirtyIndicatorRight;

    private void Start()
    {
        dirtyIndicatorLeft.transform.DOShakeRotation(0.5f, 30).SetLoops(-1);
        dirtyIndicatorRight.transform.DOShakeRotation(0.5f, 30).SetLoops(-1);
        cryingIndicator.transform.DOShakeRotation(0.5f, 30).SetLoops(-1);
    }

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
