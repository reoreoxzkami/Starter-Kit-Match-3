using System;
using UnityEngine;

// Simple AdService with pluggable provider — replace or register a provider for real SDKs.
public class AdService : MonoBehaviour
{
    public static AdService Instance;

    // Optional provider implementing IAdProvider. If set, it will be used instead of the stub.
    public IAdProvider provider;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetProvider(IAdProvider p) => provider = p;

    public void ShowRewardedAd(Action onComplete)
    {
        if (provider != null)
        {
            provider.ShowRewardedAd(onComplete);
            return;
        }

        Debug.Log("[AdService] Simulating rewarded ad.");
        // In production, the provider should call the real SDK and invoke onComplete when reward is granted.
        // For local testing we immediately grant the reward.
        onComplete?.Invoke();
    }
}
