using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfDay : MonoBehaviour
{
    [SerializeField] private Button okButton;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private TextMeshProUGUI costs;
    [SerializeField] private PlayerProgress playerProgress;
    [SerializeField] private GameVariablesController gameVariables;
    [SerializeField] private Image badEnding;
    [SerializeField] private Image goodEnding;

    public void Show()
    {
        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(OnNextDay);

        badEnding.gameObject.SetActive(false);
        goodEnding.gameObject.SetActive(false);

        buttonText.text = "Start Next Day";

        gameObject.SetActive(true);
        string costsOfDay = "";
        List<string> dailyExpenses = playerProgress.DailyExpenses();
        List<float> dailyCosts = playerProgress.DailyCosts();

        costsOfDay += "expenses: " + playerProgress.GetCurrentDayCosts() + "<br>";        
        costsOfDay += "money earned: " + playerProgress.MoneyOfTheDay;

        costs.text = costsOfDay;
    }

    public void ShowPlayerLost(bool isBroke = false)
    {
        gameVariables.SetProgress(false);

        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(Retry);

        badEnding.gameObject.SetActive(true);
        goodEnding.gameObject.SetActive(false);

        buttonText.text = "Retry";

        gameObject.SetActive(true);
        costs.text = isBroke ? "You ran out of money!" : "You are out of strikes!";
    }

    public void ShowPlayerWon()
    {
        gameVariables.SetProgress(false);

        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(Retry);

        badEnding.gameObject.SetActive(false);
        goodEnding.gameObject.SetActive(true);

        buttonText.text = "New Game";

        costs.text = "You are now a succesful streamer and were able to take care of your daughter.";
        gameObject.SetActive(true);
    }

    private void OnNextDay()
    {
        gameVariables.CompleteDay();
        gameObject.SetActive(false);
        if (playerProgress.GetMoney() < 0)
            ShowPlayerLost(isBroke: true);
        else if (playerProgress.CheckIfWon())
            ShowPlayerWon();
    }

    private void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
