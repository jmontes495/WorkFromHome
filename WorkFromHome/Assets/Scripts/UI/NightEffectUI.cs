using UnityEngine;
using UnityEngine.UI;

public class NightEffectUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private DayProgress dayProgress;
    [SerializeField] private float dayNightimePercentage;

    private void Update()
    {
        if(dayProgress)
        {
            if (dayProgress.SecondsPassed / dayProgress.SecondsPerDay >= dayNightimePercentage)
                canvasGroup.alpha = (dayProgress.SecondsPassed / dayProgress.SecondsPerDay - 0.6f) / (1f - dayNightimePercentage);
            else
                canvasGroup.alpha = 0f;
        }
        else
        {
            canvasGroup.alpha = 0f;
        }
    }
}
