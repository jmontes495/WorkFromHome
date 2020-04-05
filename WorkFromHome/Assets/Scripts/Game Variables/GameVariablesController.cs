using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariablesController : MonoBehaviour
{
    private PlayerProgress playerProgress;
    private TimeStreaming timeStreaming;
    private BabyHappiness babyHappiness;
    private FilthyRoom filthyRoom;
    private DayProgress dayProgress;

    private void Start()
    {
        playerProgress = GetComponent<PlayerProgress>();
        timeStreaming = GetComponent<TimeStreaming>();
        babyHappiness = GetComponent<BabyHappiness>();
        filthyRoom = GetComponent<FilthyRoom>();
        dayProgress = GetComponent<DayProgress>();
    }

    public void BeginStream()
    {
        timeStreaming.BeginStream();
        if (filthyRoom.IsFilthyAF)
            playerProgress.AddStrike();
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

    public void CompleteDay()
    {
        playerProgress.CashDay();
        timeStreaming.ResetInfo();
        babyHappiness.ResetInfo();
        filthyRoom.ResetInfo();
        dayProgress.ResetInfo();
    }
}
