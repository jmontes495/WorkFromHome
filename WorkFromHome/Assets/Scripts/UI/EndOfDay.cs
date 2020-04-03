using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndOfDay : MonoBehaviour
{
    [SerializeField] private Button newDayButton;
    [SerializeField] private TextMeshProUGUI costs;
    [SerializeField] private PlayerProgress playerProgress;

    public void Show()
    {
        newDayButton.onClick.RemoveAllListeners();
        newDayButton.onClick.AddListener(OnNextDay);

        gameObject.SetActive(true);
        string costsOfDay = "";
        List<string> dailyExpenses = playerProgress.DailyExpenses();
        List<float> dailyCosts = playerProgress.DailyCosts();
        for (int i = 0; i < dailyExpenses.Count; i++)
        {
            costsOfDay += dailyExpenses[i] + " - " + dailyCosts[i] + "<br>";
        }
        costsOfDay += "money - " + playerProgress.MoneyOfTheDay;
}

    private void OnNextDay()
    {
        playerProgress.CashDay();
        gameObject.SetActive(false);
    }

}
