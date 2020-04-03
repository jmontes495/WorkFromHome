using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariablesController : MonoBehaviour
{
    private TimeStreaming timeStreaming;
    private BabyHappiness babyHappiness;
    private FilthyRoom filthyRoom;

    private void Start()
    {
        timeStreaming = GetComponent<TimeStreaming>();
        babyHappiness = GetComponent<BabyHappiness>();
        filthyRoom = GetComponent<FilthyRoom>();
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

    public void StartCleaning()
    {
        filthyRoom.StartCleaning();
    }

    public void StopCleaning()
    {
        filthyRoom.StopCleaning();
    }
}
