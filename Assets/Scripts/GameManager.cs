using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score { get; private set; }
    public int Coins { get; private set; }
    public float ComboMultiplier { get; private set; } = 1f;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int basePoints)
    {
        int points = Mathf.RoundToInt(basePoints * ComboMultiplier);
        Score += points;
        Debug.Log($"Added {points} points (base {basePoints}) — Total: {Score}");
        // TODO: wire to UI/XP systems
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        Debug.Log($"Coins +{amount} => {Coins}");
    }

    public void SetCombo(float multiplier, float duration = 5f)
    {
        ComboMultiplier = multiplier;
        CancelInvoke(nameof(ResetCombo));
        Invoke(nameof(ResetCombo), duration);
    }

    void ResetCombo() => ComboMultiplier = 1f;

    // Ad hooks (stubs call AdService)
    public void WatchAdForDoubleXP()
    {
        AdService.Instance?.ShowRewardedAd(() =>
        {
            SetCombo(2f, 10f);
        });
    }

    public void WatchAdForRevive(System.Action onRevive)
    {
        AdService.Instance?.ShowRewardedAd(() => onRevive?.Invoke());
    }
}
