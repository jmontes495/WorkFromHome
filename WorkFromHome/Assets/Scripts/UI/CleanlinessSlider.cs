using UnityEngine;
using UnityEngine.UI;

public class CleanlinessSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private FilthyRoom filthyRoom;

    void Start()
    {
        slider.maxValue = 1.0f;
        slider.value = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = 1f - filthyRoom.CleanlinessPercentage();
    }
}
