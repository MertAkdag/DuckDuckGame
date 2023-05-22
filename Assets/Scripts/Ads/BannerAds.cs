using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class BannerAds : MonoBehaviour
{
    
    private BannerView bannerView;

    void Start()
    {
        string adUnitId = "ca-app-pub-8095700878802270/8099327153";
        
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

}
