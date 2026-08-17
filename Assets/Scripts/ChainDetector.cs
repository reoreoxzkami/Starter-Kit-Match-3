using System.Collections.Generic;
using UnityEngine;

public static class ChainDetector
{
    public static void ProcessChain(List<Tile> chain)
    {
        if (chain == null || chain.Count < 2) return;

        int colorId = chain[0].colorId;
        // verify all same color
        foreach (var t in chain) if (t.colorId != colorId) return;

        // award points and clear
        // Note: keep a copy since GridManager.ClearChain destroys tiles
        var copy = new List<Tile>(chain);
        var gm = Object.FindObjectOfType<GridManager>();
        gm?.ClearChain(copy);

        // combo logic
        GameManager.Instance.SetCombo(1f + (copy.Count / 6f), 3f);
    }

    public static int CalculatePoints(int length)
    {
        // simple quadratic scoring — rewards long chains
        return length * length * 10;
    }
}
