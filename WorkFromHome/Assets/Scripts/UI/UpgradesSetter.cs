using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesSetter : MonoBehaviour
{
    [SerializeField] private Button showButton;
    [SerializeField] private UpgradesRetriever upgradesRetriever;
    private UpgradeButton[] upgradeButtons;

    bool isShowing;

    private void Start()
    {
        showButton.onClick.RemoveAllListeners();    
        showButton.onClick.AddListener(OnShow);

        upgradeButtons = GetComponentsInChildren<UpgradeButton>();
    }

    public void UpdateUpgrades()
    {
        List<StreamingUpgrade> upgrades = upgradesRetriever.GetAvailableUpgrades();
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            if (i >= upgrades.Count)
                upgradeButtons[i].SetAsEmpty();
            else
                upgradeButtons[i].SetUpgradeValues(upgradesRetriever.UpdateCanBePurchased(upgrades[i]), upgrades[i], PurchaseUpgrade);
        }
    }

    private void PurchaseUpgrade(StreamingUpgrade upgrade)
    {
        bool result = upgradesRetriever.PurchaseUpgrade(upgrade);
        if(result)
            UpdateUpgrades();
    }

    private void OnShow()
    {
        if (isShowing)
        {
            transform.Translate(0, 50, 0);
            isShowing = false;
        }
        else
        {
            UpdateUpgrades();
            transform.Translate(0, -50, 0);
            isShowing = true;
        }

    }
}
