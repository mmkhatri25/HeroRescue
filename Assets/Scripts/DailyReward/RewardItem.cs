using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardItem : MonoBehaviour
{
    public DailyGiftPanel _dailyGift;
    public Sprite sprSelected, sprHasClaim, sprDisable;
    public GameObject gTick;
    public Image imgPreview;
    public int dayIndex;

    public void DisplayAgain()
    {
        if (dayIndex == Utils.curDailyGift && !Utils.cantakegiftdaily && !Utils.IsClaimReward())
        {
            imgPreview.sprite = sprSelected;
            _dailyGift._dayIndex = dayIndex;
            gTick.SetActive(false);
            if (dayIndex == 7)
            {
                _dailyGift.btnClaimX3.gameObject.SetActive(false);
            }
            else _dailyGift.btnClaimX3.gameObject.SetActive(true);


        }
        else if (dayIndex == Utils.curDailyGift && Utils.cantakegiftdaily)
        {
            _dailyGift.btnClaimX3.gameObject.SetActive(false);
            _dailyGift.btnClaim.gameObject.SetActive(false);
        }
        else if (dayIndex == Utils.curDailyGift - 1 && !Utils.cantakegiftdaily && Utils.IsClaimReward())
        {
            _dailyGift.btnClaimX3.gameObject.SetActive(false);
            _dailyGift.btnClaim.gameObject.SetActive(false);
            imgPreview.sprite = sprHasClaim;
        }
        else if (dayIndex < Utils.curDailyGift)
        {
            imgPreview.sprite = sprHasClaim;
            gTick.SetActive(true);
        }
        else
        {
            imgPreview.sprite = sprDisable;
            gTick.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Day_"+dayIndex) == 0)
        {
            gTick.SetActive(true);
        }

    }
    private void OnEnable()
    {
        DisplayAgain();
    }
}