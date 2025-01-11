using GoogleMobileAds.Api;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum RewardType
{
    GamePlayTimerIncrease,
    CameraDetectRevive,
    StaminaPowerUp,
    GrabDistance,
    Hint,
    GuardDetect,
    DestroyCCTV,
    KillGuard,
    none,
}

public enum InterstitialType
{
    OnLevelEnd,
    BackToDashBoardFromPause,
    RestartLevel,
    GameOverRestart,
    WrongItems,
    IloveAdsButton,
}

public enum BannerTypes
{
    DashBoard,
    GamePlay
}
public enum AppOpen
{
    GameStart,
    AppFocus
}

public class RewardManager : MonoBehaviour
{
    public static RewardManager instance;

    #region Variables

    public RewardType rewardType;
    [HideInInspector] public InterstitialType interstitialType;
    [HideInInspector] public AppOpen appOpenType;
    [HideInInspector] public BannerTypes bannerType;

    [Header("NoAd Pop-Up Variable")]
    public Canvas NoAd_Canvas;
    public Image NoAd_AlphaBG;
    public Image NoAd_BgImage;
    public Button NoAd_CloseBtn;
    public TextMeshProUGUI NoAdHeader;
    public TextMeshProUGUI NoAd_InfoText;
    public bool IsNoAdPopUpOpen;

    [Header("Ad Show Bool Variable")]
    [HideInInspector] public bool IsRewardAdShowing;
    [HideInInspector] public bool IsInterstitialAdShowing;
    [HideInInspector] public bool IsBannerAdShowing;



    public bool IsAdOn;

    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            GetAdShowData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region Sound And Music Pause/Unpause Function for Ads

    public void SoundAndMusicPause(bool IsPause)
    {
        //SoundMusicVibrationManager.Instance.PauseSoundAndMusic(IsPause);
    }

    #endregion

    #region Banner Ad Functions

    public void CallBannerAd()
    {
        if (!IsAdOn) return;

        if (ValidateAdBeforeShow(bannerType.ToString(), "Banner"))
        {
            //GoogleAds.instance.ShowBannerAd();
        }
    }


    public void DisableBannerAd()
    {

        //GoogleAds.instance.DestroyBannerAd();
    }

    #endregion

    #region Reward Ad Functions

   /* public bool IsRewardAdLoaded()
    {
        return GoogleAds.instance.IsRewardAdLoaded();
    }*/

    public void CallRewardAd()
    {
        DisableBannerAd();

        if (rewardType == RewardType.GrabDistance || rewardType == RewardType.StaminaPowerUp)
        {
            StartCoroutine(DelayRewardAdCall());
            return;
        }

        if (ValidateAdBeforeShow(rewardType.ToString(), "Reward"))
        {
            //LogData.LogWarning("Validation true");
            StartCoroutine(DelayRewardAdCall());
        }
        else
        {
            //LogData.LogWarning("Validation false");
            RewardVideoComp();
        }
    }

    public IEnumerator DelayRewardAdCall()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        //RewardVideoComp();


        //GoogleAds.instance.ShowRewardedAd();
    }

    public void RewardVideoComp()
    {
        CallBannerAd();

        Invoke(nameof(handleRewardState), 1f);
        SoundAndMusicPause(false);
        GrantRewardFunction(rewardType);
    }

    public void handleRewardState()
    {
        IsRewardAdShowing = false;
    }


    #region Grant Reward Function

    public void GrantRewardFunction(RewardType rewardType)
    {
        switch (rewardType)
        {
            case RewardType.GamePlayTimerIncrease:
                GrantReward_GamePlayTimerIncrease();
                break;

            case RewardType.CameraDetectRevive:
                GrantReward_CCTVDetect();
                break;

            case RewardType.StaminaPowerUp:
                GrantReward_StaminaIncrease();
                break;

            case RewardType.GrabDistance:
                GrantReward_GrabDistanceIncrease();
                break;

            case RewardType.Hint:
                GrantReward_Hint();
                break;

            case RewardType.GuardDetect:
                GrantReward_GuardDetect();
                break;

            case RewardType.DestroyCCTV:
                GrantReward_RemoteButton(RewardType.DestroyCCTV);
                break;

            case RewardType.KillGuard:
                GrantReward_RemoteButton(RewardType.KillGuard);
                break;

            default:
                Debug.Log("Default case");
                break;
        }

    }


    public void GrantReward_GamePlayTimerIncrease()
    {
       // GamePlayManager.instance.TimeIncreaseReward();
    }

    public void GrantReward_CCTVDetect()
    {
        //GamePlayManager.instance.CCTVDetectReward();
    }

    public void GrantReward_StaminaIncrease()
    {
        //UpgradeManager.Instance.StaminaReward();
    }

    public void GrantReward_GrabDistanceIncrease()
    {
       // UpgradeManager.Instance.GrabDistanceReward();
    }

    public void GrantReward_Hint()
    {
       // GamePlayManager.instance.HintReward(true);
    }

    public void GrantReward_GuardDetect()
    {
        //GamePlayManager.instance.GuardDetectReward();
    }


    public void GrantReward_RemoteButton(RewardType rewardType)
    {
       // GamePlayManager.instance.RemoteBtnReward(rewardType);
    }
    #endregion

    #endregion

    #region AppOpen Ad Functions

    public void CallAppOpenAd()
    {
        /*if (!IsAdOn)
        {
            AppOpenComp();
            return;
        }*/



        /*if (IsRewardAdShowing || IsInterstitialAdShowing)
        {
            AppOpenComp();
            return;
        }*/

        StartCoroutine(DelayCallAppOpenAd());

        /*if (ValidateAdBeforeShow(appOpenType.ToString(), "AppOpen"))
        {
            StartCoroutine(DelayCallAppOpenAd());
        }
        else
        {
            AppOpenComp();
        }*/
    }

    public IEnumerator DelayCallAppOpenAd()
    {
        yield return new WaitForSecondsRealtime(0f);
        SoundAndMusicPause(true);
        GoogleAdManager.instance.OpenAdController.ShowAd();
    }

    public bool CheckIfAnyAppOpenAdTrue()
    {
        if (ValidateAdBeforeShow(AppOpen.GameStart.ToString(), "AppOpen")
            || ValidateAdBeforeShow(AppOpen.AppFocus.ToString(), "AppOpen"))
        {
            return true;
        }

        return false;
    }


    #region After Ad Function

    public void AppOpenComp()
    {
        //CallBannerAd();

        SoundAndMusicPause(false);
        AppOpenCompFunction(appOpenType);
    }

    public void AppOpenCompFunction(AppOpen appOpen)
    {
        //if (AnimationController.Instance.isAnimationPlaying) return;
        //if (AnimationController.Instance.IsButtonAnimating) return;

        switch (appOpen)
        {
            case AppOpen.GameStart:
                AppOpenComp_GameStart();
                break;

            case AppOpen.AppFocus:
                AppOpenComp_AppFocus();
                break;

            default:
                Debug.Log("Default case");
                break;
        }
    }

    public void AppOpenComp_GameStart()
    {
       // LoadingCanvas.Instance.LoadSceneAfterAppOpen();

        //here we have to show push notification Panel
        /*if (StaticData.IsPushNotification == 1)
        {
            LogData.Log("Need to show Notification Panel");
            FireBaseManager.Instance.checkNotification();
        }*/
    }

    public void AppOpenComp_AppFocus()
    {

    }

    #endregion

    #endregion

    #region Interstitial Add Function

    public void CallInterstitialAd()
    {
        //DisableBannerAd();

        /*if (!IsAdOn)
        {
            InterstitialComp();
            return;
        }*/


        StartCoroutine(DelayCallInterstitialAd());

        /*if (ValidateAdBeforeShow(interstitialType.ToString(), "Interstitial"))
        {
              StartCoroutine(DelayCallInterstitialAd());
        }
        else
        {
            InterstitialComp();
        }*/
    }

    public IEnumerator DelayCallInterstitialAd()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SoundAndMusicPause(true);
        GoogleAdManager.instance.interstitialAdController.ShowAd();
    }
    #region After Ad Function

    public void InterstitialComp()
    {
        IsInterstitialAdShowing = false;
        SoundAndMusicPause(false);
        InterstitialCompFunction(interstitialType);
    }

    public void InterstitialCompFunction(InterstitialType interstitial)
    {

        switch (interstitial)
        {
            case InterstitialType.OnLevelEnd:
                InterstitialComp_NextLevel();
                break;

            case InterstitialType.RestartLevel:
                InterstitialComp_RestartLevel();
                break;

            case InterstitialType.GameOverRestart:
                InterstitialComp_GameOverRestart();
                break;

            case InterstitialType.BackToDashBoardFromPause:
                InterstitialComp_BackToDashBoardFromPause();
                break;

            case InterstitialType.WrongItems:
                InterstitialComp_WrongItems();
                break;

            case InterstitialType.IloveAdsButton:
                InterstitialComp_ILoveAds();
                break;

            default:
                Debug.Log("Default case");
                break;
        }
    }

    public void InterstitialComp_NextLevel()
    {
       // LogData.Log("InterstitialComp_NextLevel");
       // GamePlayManager.instance.gamePlayUIManager.AfterInterstitial_LoadNextLevel();
    }

    public void InterstitialComp_RestartLevel()
    {
        //LogData.Log("InterstitialComp_RestartLevel");
        //GamePlayManager.instance.gamePlayUIManager.AfterInterstitial_RestartLevel();
    }
    public void InterstitialComp_GameOverRestart()
    {
       // GamePlayManager.instance.gamePlayUIManager.AfterInterstitial_GameOverRestart();
    }
    public void InterstitialComp_BackToDashBoardFromPause()
    {

        //LogData.Log("InterstitialComp_BackToDashBoard");
        //GamePlayManager.instance.gamePlayUIManager.AfterInterstitial_BackToDashBoard();
    }

    public void InterstitialComp_WrongItems()
    {
       // GamePlayManager.instance.AfterInterstitial_WrongItems();
    }

    public void InterstitialComp_ILoveAds()
    {
        CallBannerAd();
        //DashBoardUIManager.Instance.HandleBtnClickFromCloseRemoveAd();
    }


    public bool CheckIfAnyInterstitialAdTrue()
    {
        if (ValidateAdBeforeShow(InterstitialType.OnLevelEnd.ToString(), "Interstitial")
            || ValidateAdBeforeShow(InterstitialType.BackToDashBoardFromPause.ToString(), "Interstitial")
            || ValidateAdBeforeShow(InterstitialType.RestartLevel.ToString(), "Interstitial")
            || ValidateAdBeforeShow(InterstitialType.GameOverRestart.ToString(), "Interstitial")
            || ValidateAdBeforeShow(InterstitialType.WrongItems.ToString(), "Interstitial")
            || ValidateAdBeforeShow(InterstitialType.IloveAdsButton.ToString(), "Interstitial"))
        {
            return true;
        }

        return false;
    }

    #endregion

    #endregion

    #region NO AD PopUP Function

    public void Open_NoAD_PopUp()
    {
        Debug.Log("Open_NoAD_PopUp");
        if (!NoAd_Canvas.enabled)
        {
            Debug.Log("NoAd_Canvas.enabled");

            IsNoAdPopUpOpen = true;

            /*if (GamePlayManager.instance != null)
            {
                GamePlayManager.instance.gameTimer.PauseTimer();
            }*/

            /*bool IsInternetOn = InternetConnectivity.Instance.CheckInternet();

            UpdateNoAdPopUpUI(IsInternetOn);

            AnimationController.Instance.PopUpOpenAnimationCall(NoAd_Canvas, NoAd_BgImage, NoAd_AlphaBG, delay: 0.01f);*/
        }
    }

    public void UpdateNoAdPopUpUI(bool IsInternetOn)
    {
        Debug.Log("UpdateNoAdPopUpUI==> " + IsInternetOn);

        NoAdHeader.text = IsInternetOn ? "No Ads !" : "No Internet Available!";
        NoAd_InfoText.text = IsInternetOn ? "Ads are currently unavailable. \n Please try again soon." : "Please check your internet connection \n and try again.";
    }

    public void Close_NoAD_PopUp()
    {
        /*if (GamePlayManager.instance != null && !GamePlayManager.instance.IsGameOver)
        {
            if (!UpgradeManager.Instance.IsPowerPopUpOpen)
            {
                //GamePlayManager.instance.gameTimer.ResumeTimer();
                GamePlayManager.instance.SetGamePlayState(false);
            }
        }

        SoundMusicVibrationManager.Instance.PlaySound(ClipName.ButtonClick);
        SoundMusicVibrationManager.Instance.vibrationBtnClickNew(VibrationType.ButtonClick);
        AnimationController.Instance.NormalButtonClickAnim(NoAd_CloseBtn);
        AnimationController.Instance.PopUpCloseAnimationCall(NoAd_Canvas, NoAd_BgImage, NoAd_AlphaBG,
            EndAction: () =>
            {
                IsNoAdPopUpOpen = false;
            });*/

    }

    #endregion

    #region FireBase Validation Function

    public bool ValidateAdBeforeShow(string AdPosition, String AdType)
    {
        return IsNeedToShowAd(AdPosition, AdType);
    }

    public bool IsNeedToShowAd(string AdPosition, string AdType)
    {
        /*bool IsValidateToShow = false;

        switch (AdType)
        {
            case "Interstitial":
                IsValidateToShow = GameManager.instance.fireBaseManager.Validate_Interstitial(AdPosition);
                break;

            case "Reward":
                IsValidateToShow = GameManager.instance.fireBaseManager.Validate_Reward(AdPosition);
                break;

            case "Banner":
                IsValidateToShow = GameManager.instance.fireBaseManager.Validate_Banner(AdPosition);
                break;

            case "AppOpen":
                IsValidateToShow = GameManager.instance.fireBaseManager.Validate_AppOpen(AdPosition);
                break;

            default:
                Debug.Log("Default case");
                break;
        }*/

        return true;
    }

    #endregion

    #region Handle variable To show Ad Or not

    public void UpdateAdShowVariable(bool IsShowAd)
    {
       // LogData.LogWarning("UpdateAdShowVariable == > " + StaticData.IsAdShow);
        //StaticData.IsAdShow = IsShowAd;
        //IsAdOn = StaticData.IsAdShow;
    }

    public void GetAdShowData()
    {
       // IsAdOn = StaticData.IsAdShow;
    }

    #endregion


    public void ResetAdTypeState()
    {
        rewardType = RewardType.none;
    }

}


