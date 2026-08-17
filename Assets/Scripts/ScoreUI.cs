using UnityEngine;
using UnityEngine.UI;

// Minimal UI connector to display score, coins, and combo multiplier.
[RequireComponent(typeof(Canvas))]
public class ScoreUI : MonoBehaviour
{
    public Text scoreText;
    public Text coinsText;
    public Text comboText;

    void Update()
    {
        if (GameManager.Instance == null) return;
        if (scoreText != null) scoreText.text = $"Score: {GameManager.Instance.Score}";
        if (coinsText != null) coinsText.text = $"Coins: {GameManager.Instance.Coins}";
        if (comboText != null) comboText.text = $"Combo x{GameManager.Instance.ComboMultiplier:0.##}";
    }
}
