using UnityEngine;

public class TimeStreaming : MonoBehaviour
{
    float timeStreamingToday;

    private bool isStreaming;

    [SerializeField] private float dayProgress;
    [SerializeField] private float streamingMultiplier;

    private void Update()
    {
        if (isStreaming)
        {
            timeStreamingToday += Time.deltaTime * streamingMultiplier;
            //Debug.LogError(timeStreamingToday);
        }
    }

    public void BeginStream()
    {
        isStreaming = true;
    }

    public void StopStream()
    {
        isStreaming = false;
    }

    public void ResetInfo()
    {
        timeStreamingToday = 0;
        isStreaming = false;
    }
}
