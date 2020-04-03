using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyHappiness : MonoBehaviour
{
    float timeAlone;
    float happinessPerDay;
    private bool isBeingHeld;
    private bool isCrying;

    [SerializeField] private float secondsWithoutAttention;
    [SerializeField] private float maximumHappiness;
    [SerializeField] private float happinessDeltaRate;

    private void Update()
    {
        if (!isBeingHeld)
        {
            if (!isCrying)
            {
                timeAlone += Time.deltaTime;
                if (timeAlone >= secondsWithoutAttention)
                    isCrying = true;                
            }
            else if (isCrying && happinessPerDay > 0)
            {
                happinessPerDay -= Time.deltaTime * happinessDeltaRate;
            }
        }
        else
        {
            timeAlone -= Time.deltaTime;
            if (timeAlone < secondsWithoutAttention)
                isCrying = false;
        }
    }

    public void HoldBaby()
    {
        isBeingHeld = true;
    }

    public void DropBaby()
    {
        isBeingHeld = false;
    }

    public void ResetInfo()
    {
        timeAlone = 0;
        happinessPerDay = maximumHappiness;
        isBeingHeld = false;
        isCrying = false;
    }
}
