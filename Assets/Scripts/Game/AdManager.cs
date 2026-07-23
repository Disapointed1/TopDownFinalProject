using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour
{

    private InterstitialAd _interstitialAd;


    public event Action OnAdClosed;

    private void Start()
    {
         MobileAds.Initialize(initStatus => { });
         LoadInterstitialAd();
    }

    private void LoadInterstitialAd()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        InterstitialAd.Load(adUnitId, new AdRequest(), (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null)
            {
                return;
            }
            _interstitialAd = ad;
        });
    }

    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.OnAdFullScreenContentClosed += HandleAdClosed;
            _interstitialAd.Show();
        }
    }

    private void HandleAdClosed()
    {
        OnAdClosed?.Invoke();
        LoadInterstitialAd();
    }
}
