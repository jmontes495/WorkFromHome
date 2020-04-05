using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UpgradesSetter : MonoBehaviour
{
    [SerializeField] private Button showButton;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private UpgradesRetriever upgradesRetriever;
    [SerializeField] private ComputerImage computerImage;
    [SerializeField] private ChairImage chairImage;
    [SerializeField] private MainCharacterAnimator mainCharacterAnimator;


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
        {
            UpdateUpgrades();
            if (upgrade.Category == UpgradeCategory.Computer)
                computerImage.UpdateComputer();
            else if (upgrade.Category == UpgradeCategory.Chair)
                chairImage.UpdateChair();
            else if (upgrade.Category == UpgradeCategory.Clothes)
                mainCharacterAnimator.UpdateClothes();
        }
    }

    private void OnShow()
    {
        if (isShowing)
        {
            transform.DOMoveY(transform.position.y + 4f, 0.2f);
            isShowing = false;
            buttonText.text = "See Upgrades";
        }
        else
        {
            UpdateUpgrades();
            transform.DOMoveY(transform.position.y - 4f, 0.2f);
            isShowing = true;
            buttonText.text = "Hide Upgrades";
        }

    }
}
