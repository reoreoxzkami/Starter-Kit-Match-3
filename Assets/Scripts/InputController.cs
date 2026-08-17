using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private List<Tile> currentChain = new List<Tile>();
    private Camera mainCam;

    void Start() { mainCam = Camera.main; }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeginChain();
            TryAddUnderPointer();
        }
        else if (Input.GetMouseButton(0))
        {
            TryAddUnderPointer();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndChain();
        }
    }

    void BeginChain() { currentChain.Clear(); }

    void TryAddUnderPointer()
    {
        var wp = mainCam.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.OverlapPoint(wp);
        if (hit == null) return;
        var tile = hit.GetComponent<Tile>();
        if (tile == null) return;

        if (currentChain.Count == 0)
        {
            currentChain.Add(tile);
        }
        else
        {
            var last = currentChain[currentChain.Count - 1];
            if (tile == last) return; // same tile
            // allow adding tile if it's not already in chain and same color
            if (!currentChain.Contains(tile) && tile.colorId == currentChain[0].colorId)
                currentChain.Add(tile);
        }
    }

    void EndChain()
    {
        if (currentChain.Count >= 2)
        {
            ChainDetector.ProcessChain(currentChain);
        }
        currentChain.Clear();
    }
}
