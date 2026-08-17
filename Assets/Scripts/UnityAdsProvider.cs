#if UNITY_ADS
using UnityEngine;
using UnityEngine.Advertisements;
using System;

// Example adapter for Unity Ads. Compile only when UNITY_ADS symbol is enabled.
public class UnityAdsProvider : MonoBehaviour, IAdProvider
{
    public string rewardedPlacementId = "rewardedVideo";

    public void ShowRewardedAd(Action onComplete)
    {
        if (!Advertisement.isInitialized || !Advertisement.IsReady(rewardedPlacementId))
        {
            Debug.Log("[UnityAdsProvider] Ad not ready, granting reward immediately for testing.");
            onComplete?.Invoke();
            return;
        }

        var options = new ShowOptions { resultCallback = result =>
        {
            if (result == ShowResult.Finished)
                onComplete?.Invoke();
            else
                Debug.Log("[UnityAdsProvider] Ad not finished or skipped; no reward granted.");
        }};

        Advertisement.Show(rewardedPlacementId, options);
    }
}
#endif
