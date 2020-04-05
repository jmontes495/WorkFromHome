using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerStateUI : MonoBehaviour
{
    [SerializeField] private PlayerProgress playerProgress;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI followersText;
    [SerializeField] private Color greyStrike;
    [SerializeField] private Color redStrike;
    [SerializeField] private List<Image> strikes;

    private int lastStrikes;

    private void Start()
    {
        lastStrikes = 0;
        foreach(Image strike in strikes)
        {
            strike.color = greyStrike;
        }
    }


    private void Update()
    {
        if(playerProgress)
        {
            moneyText.text = Mathf.FloorToInt(playerProgress.GetMoney()).ToString();
            followersText.text = playerProgress.GetFollowers().ToString();
            if(playerProgress.NumberOfStrikes() > lastStrikes)
            {
                lastStrikes = playerProgress.NumberOfStrikes();
                for(int i = 0; i < lastStrikes; i ++)
                {
                    strikes[i].color = redStrike;
                    strikes[i].transform.DOPunchScale(Vector3.one * 0.5f, 0.3f);
                }

                
            }
        }
    }
}
