Chain Slide — quick start

This folder adds a lightweight Unity 2D scaffold for a chain-making game.

Files added (Assets/Scripts):
- GameManager.cs — score, coins, combo and ad hooks
- GridManager.cs — spawns a simple grid, clears chains, gravity/fill
- Tile.cs — tile identity and visual helper
- InputController.cs — mouse/touch input to slide and form chains
- ChainDetector.cs — validates same-color chains, calculates points
- UpgradeManager.cs — simple upgrade purchase and ad-for-coins hook
- AdService.cs — stubbed ad service; replace with real SDK (AdMob/UnityAds) later

Ad & analytics integration points:
- AdService.ShowRewardedAd(Action onComplete) — single place to swap providers
- GameManager.WatchAdForDoubleXP() and UpgradeManager.WatchAdForCoins() — example usage

How to use:
1. Open this repo in Unity 2020.3+ (or compatible editor).
2. Create an empty GameObject, attach GameManager, GridManager, InputController, UpgradeManager, AdService.
3. Create a small sprite and a prefab with a SpriteRenderer + Collider2D + Tile component; set tilePrefab on GridManager.
   - NOTE: GridManager now has a runtime fallback: if tilePrefab is not set, it will generate simple runtime tiles so the scene is playable without creating a prefab.
4. (Optional) Add a Canvas and 3 Text UI elements for Score, Coins, and Combo. Add the ScoreUI component and wire Text references.
5. For real ads: implement and register an IAdProvider. Example adapter for Unity Ads is provided (UnityAdsProvider.cs) and compiles when UNITY_ADS is enabled. Attach UnityAdsProvider and call AdService.Instance.SetProvider(yourProvider) at startup.

Future work suggestions:
- Add particle VFX, SFX and polish
- Hook UI into a proper HUD and animated value changes
- Integrate ad SDK (Unity Ads / AdMob) via IAdProvider and keep AdService as dispatcher
- Add upgrade trees and IAP hooks

