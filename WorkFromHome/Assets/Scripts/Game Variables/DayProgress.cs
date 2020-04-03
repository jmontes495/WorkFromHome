using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayProgress : MonoBehaviour
{
    [SerializeField] private float secondsPerDay;
    [SerializeField] private EndOfDay endOfDayScreen;

    private float secondsPassed;

    public float SecondsPassed
    {
        get { return secondsPassed; }
        private set { secondsPassed = value;  }
    }

    public float SecondsPerDay
    {
        get { return secondsPerDay; }
        private set { secondsPerDay = value; }
    }

    private bool inProgress = true;

    private void Update()
    {
        if (inProgress)
        {
            secondsPassed += Time.deltaTime;
            if (secondsPassed >= SecondsPerDay)
            {
                secondsPassed = SecondsPerDay;
                inProgress = false;
                endOfDayScreen.Show();
            }
        }
    }
}
