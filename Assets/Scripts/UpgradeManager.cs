using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int playerLevel = 1;
    public int coins = 0;

    public void BuyUpgrade(string id, int cost)
    {
        if (coins < cost) { Debug.Log("Not enough coins"); return; }
        coins -= cost;
        Debug.Log($"Bought upgrade {id}");
        // TODO: apply upgrade logic
    }

    // Hook to grant coins after watching an ad
    public void WatchAdForCoins()
    {
        AdService.Instance?.ShowRewardedAd(() =>
        {
            coins += 50;
            GameManager.Instance.AddCoins(50);
        });
    }
}
