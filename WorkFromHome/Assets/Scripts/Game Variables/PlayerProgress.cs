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
    [SerializeField] private int initialFollowers;
    [SerializeField] private float initialMoney;
    [SerializeField] private List<string> dailyExpenses;
    [SerializeField] private List<float> dailyCosts;
    [SerializeField] private int maximumDays;

    private float moneyOfTheDay;
    private TimeStreaming timeStreaming;
    private int followersRemaining;

    public int CurrentDay { get { return currentDay; } private set { currentDay = value; } }
    public float MoneyOfTheDay { get { return moneyOfTheDay; } private set { moneyOfTheDay = value; } }

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
    }

    private void Update()
    {
        if (timeStreaming.IsStreaming)
            moneyOfTheDay += moneyPerSecondPerFollower * followers * Time.deltaTime;

        if (followersRemaining > 0)
        {
            int deltaFollowers = (int)(followersRemaining * followersPerSecond * Time.deltaTime);
            if (followersRemaining < followersPerSecond)
                deltaFollowers = followersRemaining;
            followersRemaining -= deltaFollowers;
            followers += deltaFollowers;
        }
    }

    public void PurchaseUpgrade(StreamingUpgrade newUpgrade)
    {
        money -= newUpgrade.Price;
        followersRemaining += newUpgrade.ViewersGained;
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

        foreach (float cost in dailyCosts)
        {
            money -= cost;
        }

        currentDay++;
        if (currentDay > maximumDays)
            currentDay = maximumDays;
    }
}
