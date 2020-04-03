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
            if (upgrade.DayUnlocked >= playerProgress.CurrentDay && upgrade.IsAvailable() && !upgrade.IsPurchased)
                availableUpgrades.Add(upgrade);
        }

        return availableUpgrades;
    }
}
