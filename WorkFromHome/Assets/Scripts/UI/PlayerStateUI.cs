using TMPro;
using UnityEngine;

public class PlayerStateUI : MonoBehaviour
{
    [SerializeField] private PlayerProgress playerProgress;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI followersText;


    private void Update()
    {
        if(playerProgress)
        {
            moneyText.text = Mathf.FloorToInt(playerProgress.GetMoney()).ToString();
            followersText.text = playerProgress.GetFollowers().ToString();
        }
    }
}
