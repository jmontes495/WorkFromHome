using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariablesController : MonoBehaviour
{
    private TimeStreaming timeStreaming;
    private BabyHappiness babyHappiness;

    private void Start()
    {
        timeStreaming = GetComponent<TimeStreaming>();
        babyHappiness = GetComponent<BabyHappiness>();
    }

    public void BeginStream()
    {
        timeStreaming.BeginStream();
    }

    public void EndStream()
    {
        timeStreaming.StopStream();
    }

    public void HoldBaby()
    {
        babyHappiness.HoldBaby();
    }

    public void DropBaby()
    {
        babyHappiness.DropBaby();
    }
}
