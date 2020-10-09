using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Ad_Manager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3776425";
    private string appStoreID = "3776424";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private string bannerAd = "bannerID";

    public bool isTargetPlayStore;
    public bool isTestAd;

    public GameObject lifeSystem;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
        lifeSystem = GameObject.FindGameObjectWithTag("LifeSystem");
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
        Advertisement.Initialize(appStoreID, isTestAd);
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

    public void PlayBannerAd()
    {
        Advertisement.Banner.Show(bannerAd);
    }


    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
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
        AudioListener.volume = 0f;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd)
                {
                    lifeSystem.GetComponent<LifeSystem>().lives = lifeSystem.GetComponent<LifeSystem>().maxLives;
                    lifeSystem.GetComponent<LifeSystem>().timerForLife = 0f;
                    AudioListener.volume = 1f;
                    Scene loadedLevel = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(loadedLevel.buildIndex);
                    //Debug.Log("watched");
                }
                break;
        }
    }
}
