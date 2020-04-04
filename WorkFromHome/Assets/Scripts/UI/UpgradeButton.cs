using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private GameObject valuesContained;
    [SerializeField] private TextMeshProUGUI upgradeName;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI followers;
    [SerializeField] private Image icon;
    [SerializeField] private Button purchaseButton;

    private Action<StreamingUpgrade> onPurchaseAction;
    private StreamingUpgrade upgrade;

    private void Start()
    {
        purchaseButton.onClick.RemoveAllListeners();
        purchaseButton.onClick.AddListener(OnPurchased);
    }

    public void SetUpgradeValues(StreamingUpgrade upgrade, Action<StreamingUpgrade> purchased)
    {
        this.upgrade = upgrade;
        onPurchaseAction = purchased;
        valuesContained.SetActive(true);
        purchaseButton.interactable = true;

        upgradeName.text = upgrade.UpgradeName;
        price.text = upgrade.Price.ToString();
        followers.text = upgrade.ViewersGained.ToString();
    }

    public void SetAsEmpty()
    {
        valuesContained.SetActive(false);
        purchaseButton.interactable = false;
    }

    private void OnPurchased()
    {
        onPurchaseAction(upgrade);
    }
}
