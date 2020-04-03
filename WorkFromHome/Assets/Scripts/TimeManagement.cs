using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagement : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float dayProgress;
    [SerializeField] private float daySpeed;

    private bool inProgress = true;

    private void Start()
    {
        slider.maxValue = 100;
    }

    private void Update()
    {
        if (inProgress)
        {
            dayProgress += Time.deltaTime * daySpeed;
            if (dayProgress >= slider.maxValue)
            {
                dayProgress = slider.maxValue;
                inProgress = false;
            }
            slider.value = dayProgress;
        }
    }
}
