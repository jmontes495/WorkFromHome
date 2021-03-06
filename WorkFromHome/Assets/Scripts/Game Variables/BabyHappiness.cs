﻿using System.Collections;
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
    [SerializeField] private float happinessDecreasingRate;
    [SerializeField] private float happinessWhenHoldRate;

    private PlayerProgress playerProgress;

    public bool IsCrying { get => isCrying; set => isCrying = value; }

    private void Start()
    {
        playerProgress = GetComponent<PlayerProgress>();
    }

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
                happinessPerDay -= Time.deltaTime * happinessDecreasingRate;
                if (happinessPerDay <= 0)
                {
                    playerProgress.AddStrike();
                }

            }
        }
        else
        {
            timeAlone -= Time.deltaTime * happinessWhenHoldRate;
            if (timeAlone < secondsWithoutAttention)
            {
                happinessPerDay = maximumHappiness;
                isCrying = false;
            }
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
