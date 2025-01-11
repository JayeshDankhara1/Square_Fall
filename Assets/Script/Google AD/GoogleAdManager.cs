using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Sample;
using UnityEngine;

public class GoogleAdManager : MonoBehaviour
{

    public static GoogleAdManager instance; 
   
    


    public AppOpenAdController OpenAdController;
    public InterstitialAdController interstitialAdController;
    public RewardedAdController rewardedAdController;
    public BannerViewController bannerViewController;




    public void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        LoadAllAd();
    }


    public void LoadAllAd()
    {
        OpenAdController.LoadAd();
        interstitialAdController.LoadAd();
        rewardedAdController.LoadAd();
        bannerViewController.LoadAd();
    }
}
