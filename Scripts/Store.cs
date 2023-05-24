using System;
using UnityEngine;
using TMPro;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI bombText;
    public TextMeshProUGUI missileText;
    //private RewardedAd rAd;
    //private string rAd_id;
    void Start()
    {
        //rAd_id = "ca-app-pub-5715784809870825/7237896347";
        //MobileAds.Initialize(inintStatus => { } );
        coinText.text = PlayerPrefs.GetInt("coin").ToString();
        bombText.text = PlayerPrefs.GetInt("bomb").ToString();
        missileText.text = PlayerPrefs.GetInt("missile").ToString();
        //RequestRewardedAdVideo();
    }
    private void Update()
    {
        PlayerPrefs.SetInt("coin", Coin.coin);
        coinText.text = PlayerPrefs.GetInt("coin").ToString();
        PlayerPrefs.SetInt("bomb",Player_Controller.bomb);
        bombText.text = PlayerPrefs.GetInt("bomb").ToString();
        PlayerPrefs.SetInt("missile",Player_Controller.missile);
        missileText.text = PlayerPrefs.GetInt("missile").ToString();
    }
    public void BombBuy()
    {
        if (Coin.coin >= 20)
        {
            Player_Controller.bomb++;
            Coin.coin -= 20;
            PlayerPrefs.SetInt("coin", Coin.coin);
            PlayerPrefs.SetInt("bomb",Player_Controller.bomb);
        }
    }
    public void MissileBuy()
    {
        if (Coin.coin >= 40)
        {
            Player_Controller.missile++;
            Coin.coin -= 40;
            PlayerPrefs.SetInt("coin", Coin.coin);
            PlayerPrefs.SetInt("missile", Player_Controller.missile);
        }
    }
    /*private void RequestRewardedAdVideo()
    {
        rAd = new RewardedAd(rAd_id);
        rAd.OnUserEarnedReward += HandleUserEarnedReward;
        rAd.OnAdClosed += HandleRewardedAdClosed;
        rAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        AdRequest request = new AdRequest.Builder().Build();
        rAd.LoadAd(request);
    }

    public void ShowRewardedVideo()
    {
        if (rAd.IsLoaded())
        {
            Coin.coin += 200;
            PlayerPrefs.SetInt("coin", Coin.coin);
            rAd.Show();
        }
    }

    private void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs e)
    {
        RequestRewardedAdVideo();
    }

    private void HandleRewardedAdClosed(object sender, EventArgs e)
    {
        RequestRewardedAdVideo();
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        RequestRewardedAdVideo();
    }   */

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
