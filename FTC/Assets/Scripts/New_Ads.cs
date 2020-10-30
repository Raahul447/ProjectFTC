using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class New_Ads : MonoBehaviour
{

    public Ad_Manager Ads;
    public bool isLevel;

    // Start is called before the first frame update
    void Start()
    {
        Ads = GameObject.Find("AdManager").GetComponent<Ad_Manager>();
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        if (isLevel == true)
        {
            Ads.PlayBannerAd();
            
        }
        else if(isLevel == false)
        {
            Ads.HideBannerAd();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
