using UnityEngine;

public class TimeStreaming : MonoBehaviour
{
    float timeStreamingToday;

    private bool isStreaming;

    public bool IsStreaming { get { return isStreaming; } private set { isStreaming = value; } }
    
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
