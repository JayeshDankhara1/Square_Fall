using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
    public GoogleAds Ref_GoogleAds;
    public void Start()
    {
       // Ref_GoogleAds = GoogleAds.instance;
        AppOpenAd();


    }

    public void AppOpenAd()
    { 
        Ref_GoogleAds.ShowAppOpenAd();
    }
}
