using System;
using UnityEngine;

// Simple AdService stub — replace with real SDK integration later.
public class AdService : MonoBehaviour
{
    public static AdService Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowRewardedAd(Action onComplete)
    {
        Debug.Log("[AdService] Simulating rewarded ad.");
        // In production, call the real SDK and invoke onComplete when reward is granted.
        // For local testing we immediately grant the reward.
        onComplete?.Invoke();
    }
}
