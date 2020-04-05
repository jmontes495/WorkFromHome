using UnityEngine;

public class FilthyRoom : MonoBehaviour
{
    float timeGettingMessy;
    float timeBeingClean;

    private bool isGettingMessy;
    private bool isClean = true;
    private bool isBeingCleaned;
    private bool isFilthyAF;

    public bool IsFilthyAF { get { return isFilthyAF; } private set { isFilthyAF = value; } }

    public float TimeGettingMessy { get { return timeGettingMessy; } private set { timeGettingMessy = value; } }
    public float TimeBeingClean { get { return timeBeingClean; } private set { timeBeingClean = value; } }

    [SerializeField] private float timeStayingClean;
    [SerializeField] private float messinessMultiplier;
    [SerializeField] private float cleaningRate;
    [SerializeField] private float messinessLimit;

    private void Update()
    {
        if (isBeingCleaned)
        {
            isFilthyAF = false;
            timeGettingMessy -= cleaningRate * Time.deltaTime;
            if (timeGettingMessy <= 0)
            {
                timeGettingMessy = 0;
                isClean = true;
                isGettingMessy = false;
            }
        }
        else if (isGettingMessy)
        {
            timeGettingMessy += messinessMultiplier * Time.deltaTime;
            if (timeGettingMessy >= messinessLimit)
            {
                timeGettingMessy = messinessLimit;
                isFilthyAF = true;
            }
        }
        else if (isClean)
        {
            isFilthyAF = false;
            timeBeingClean += messinessMultiplier * Time.deltaTime;
            if (timeBeingClean >= timeStayingClean)
            {
                timeBeingClean = 0;
                isGettingMessy = true;
                isClean = false;
            }
        }

    }

    public float CleanlinessPercentage()
    {
        if (isFilthyAF)
            return 1.0f;

        return timeGettingMessy/messinessLimit;
    }

    public void StartCleaning()
    {
        isBeingCleaned = true;
    }

    public void StopCleaning()
    {
        isBeingCleaned = false;
    }

    public void ResetInfo()
    {
        isBeingCleaned = false;
        isClean = true;
        isGettingMessy = false;
        isFilthyAF = false;
        timeBeingClean = 0;
        timeGettingMessy = 0;
    }
}
