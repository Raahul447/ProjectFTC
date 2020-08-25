using UnityEngine.Advertisements;
using UnityEngine;

public class Ad_Manager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3776425";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private string bannerAd = "";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd); return;
        }
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }

    public void PlayRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd)
                {
                    Debug.Log("Yes, Skip Level");
                }
                if(placementId == interstitialAd)
                {
                    Debug.Log("Yes, this is interstitial");
                }
                break;
        }
    }
}
