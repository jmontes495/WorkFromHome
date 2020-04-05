using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    private float money;
    private int followers;
    private int currentDay;
    [SerializeField] private float moneyPerSecondPerFollower;
    [SerializeField] private float followersPerSecond;
    [SerializeField] private float purchaseDelay;
    [SerializeField] private int initialFollowers;
    [SerializeField] private float initialMoney;
    [SerializeField] private List<string> dailyExpenses;
    [SerializeField] private List<float> dailyCosts;
    [SerializeField] private int maximumDays;


    [SerializeField] private EndOfDay endOfDayScreen;

    private float moneyOfTheDay;
    private TimeStreaming timeStreaming;
    private int followersRemaining;

    private const int maximumStrikes = 3;
    private int strikes;

    public int CurrentDay { get { return currentDay; } private set { currentDay = value; } }
    public float MoneyOfTheDay { get { return moneyOfTheDay; } private set { moneyOfTheDay = value; } }

    private float deltaT;
    private float initialDelta;

    public List<float> DailyCosts()
    {
        return dailyCosts;
    }

    public List<string> DailyExpenses()
    {
        return dailyExpenses;
    }

    public float GetMoney()
    {
        return money;
    }

    public int GetFollowers()
    {
        return followers;
    }

    private void Start()
    {
        timeStreaming = GetComponent<TimeStreaming>();
        followers = initialFollowers;
        money = initialMoney;
        strikes = 0;
    }

    private void Update()
    {
        if (timeStreaming.IsStreaming)
            moneyOfTheDay += moneyPerSecondPerFollower * followers * Time.deltaTime;

        if (followersRemaining > 0)
        {
            deltaT += Time.deltaTime;
            initialDelta += Time.deltaTime;

            if (initialDelta < purchaseDelay)
                return;

            if (deltaT > 1.0f)
                deltaT = 0f;
            else
                return;
            float deltaFollowers = followersPerSecond;
            if (followersRemaining < deltaFollowers)
                deltaFollowers = followersRemaining;
            followersRemaining -= (int) deltaFollowers;
            followers += (int) deltaFollowers;
        }

    }

    public void PurchaseUpgrade(StreamingUpgrade newUpgrade)
    {
        money -= newUpgrade.Price;
        followersRemaining += newUpgrade.ViewersGained;
        initialDelta = 0;
    }

    public void ResetProgress()
    {
        followers = initialFollowers;
        money = initialMoney;
    }

    public void CashDay()
    {
        money += moneyOfTheDay;
        moneyOfTheDay = 0;

        if (currentDay < dailyCosts.Count)
            money -= GetCurrentDayCosts();

        currentDay++;
        if (currentDay > maximumDays)
            currentDay = maximumDays;
    }

    public float GetCurrentDayCosts()
    {
        if (currentDay < dailyCosts.Count)
            return dailyCosts[currentDay];

        return 0;
    }

    public int NumberOfStrikes()
    {
        return strikes;
    }

    public void AddStrike()
    {
        strikes++;
        Debug.LogError(strikes);
        if (strikes >= maximumStrikes)
            endOfDayScreen.ShowPlayerLost();
    }
}
