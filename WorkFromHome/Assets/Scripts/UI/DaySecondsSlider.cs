using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaySecondsSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private DayProgress dayProgress;

    void Start()
    {
        slider.maxValue = dayProgress.SecondsPerDay;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = dayProgress.SecondsPassed;
    }
}
