using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesRetriever : MonoBehaviour
{
    private StreamingUpgrade[] upgrades;
    [SerializeField] private PlayerProgress playerProgress;
    // Start is called before the first frame update
    void Start()
    {
        upgrades = GetComponentsInChildren<StreamingUpgrade>();
    }

    public List<StreamingUpgrade> GetAvailableUpgrades()
    {
        List<StreamingUpgrade> availableUpgrades = new List<StreamingUpgrade>();
        foreach (StreamingUpgrade upgrade in upgrades)
        {
            if (playerProgress.CurrentDay >= upgrade.DayUnlocked && upgrade.IsAvailable() && !upgrade.IsPurchased)
                availableUpgrades.Add(upgrade);
        }

        return availableUpgrades;
    }

    public bool PurchaseUpgrade(StreamingUpgrade upgrade)
    {
        if (!UpdateCanBePurchased(upgrade))
            return false;

        upgrade.SetPurchased();
        playerProgress.PurchaseUpgrade(upgrade);
        return true;
    }

    public bool UpdateCanBePurchased(StreamingUpgrade upgrade)
    {
        return playerProgress.GetMoney() >= upgrade.Price;
    }
}
