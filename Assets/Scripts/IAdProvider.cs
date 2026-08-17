using System;

public interface IAdProvider
{
    // Show a rewarded ad and invoke onComplete when the reward should be granted.
    void ShowRewardedAd(Action onComplete);
}
