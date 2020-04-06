using System.Collections.Generic;
using UnityEngine;

public class StreamingUpgrade : MonoBehaviour
{
    [SerializeField] private string upgradeName;
    [SerializeField] private float price;
    [SerializeField] private int viewersGained;
    [SerializeField] private int dayUnlocked;
    [SerializeField] private UpgradeCategory category;
    [SerializeField] private List<StreamingUpgrade> prerequisites;
    [SerializeField] private Sprite sprite;


    public bool IsPurchased { get { return isPurchased; } private set { isPurchased = value; } }

    public string UpgradeName { get { return upgradeName; } private set { upgradeName = value; } }
    public float Price { get { return price; } private set { price = value; } }
    public int ViewersGained { get { return viewersGained; } private set { viewersGained = value; } }
    public int DayUnlocked { get { return dayUnlocked; } private set { dayUnlocked = value; } }
    public UpgradeCategory Category { get { return category; } private set { category = value; } }
    public Sprite Sprite { get => sprite; set => sprite = value; }

    private bool isPurchased;

    public void Purchase()
    {
        isPurchased = true;
    }

    public bool IsAvailable()
    {
        foreach(StreamingUpgrade current in prerequisites)
        {
            if (!current.isPurchased)
                return false;
        }

        return true;
    }

    public void SetPurchased()
    {
        isPurchased = true;
    }
}
