using UnityEngine;
using GoogleMobileAds.Api;
public class MainMenuBannerAd : MonoBehaviour
{/*
    private BannerView bannerView;
    public void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
    }

    private void Update()
    {
        if (MainMenu.p == true)
        {
            bannerView.Hide();
            bannerView.Destroy();
        }
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5715784809870825/6373490949";
        #else
            string adUnitId = "unexpected_platform";
        #endif
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }*/
}
