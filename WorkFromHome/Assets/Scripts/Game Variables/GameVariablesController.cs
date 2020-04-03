using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariablesController : MonoBehaviour
{
    private TimeStreaming timeStreaming;

    private void Start()
    {
        timeStreaming = GetComponent<TimeStreaming>();
    }

    public void BeginStream()
    {
        timeStreaming.BeginStream();
    }

    public void EndStream()
    {
        timeStreaming.StopStream();
    }
}
