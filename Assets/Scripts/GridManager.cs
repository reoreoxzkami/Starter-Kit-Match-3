using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 8;
    public int cols = 6;
    public GameObject tilePrefab;
    public float spacing = 1.05f;

    private Tile[,] tiles;

    void Start()
    {
        tiles = new Tile[cols, rows];
        SeedGrid();
    }

    void SeedGrid()
    {
        for (int x = 0; x < cols; x++)
        for (int y = 0; y < rows; y++)
            SpawnTileAt(x, y);
    }

    void SpawnTileAt(int x, int y)
    {
        var go = Instantiate(tilePrefab, transform);
        go.transform.localPosition = new Vector3(x * spacing, y * spacing, 0);
        var tile = go.GetComponent<Tile>();
        tile.x = x; tile.y = y;
        // assign random color id and visual color
        int id = Random.Range(0, 5);
        tile.SetColor(id, ColorFromId(id));
        tiles[x, y] = tile;
    }

    Color ColorFromId(int id)
    {
        switch (id)
        {
            case 0: return Color.red;
            case 1: return Color.green;
            case 2: return Color.blue;
            case 3: return Color.yellow;
            default: return Color.magenta;
        }
    }

    public void ClearChain(List<Tile> chain)
    {
        if (chain == null || chain.Count == 0) return;
        foreach (var t in chain)
        {
            if (t == null) continue;
            tiles[t.x, t.y] = null;
            Destroy(t.gameObject);
        }

        int points = ChainDetector.CalculatePoints(chain.Count);
        GameManager.Instance.AddScore(points);

        // simple gravity/fill: drop existing tiles down and spawn on top
        CollapseColumns();
        FillEmpty();
    }

    void CollapseColumns()
    {
        for (int x = 0; x < cols; x++)
        {
            int write = 0;
            for (int y = 0; y < rows; y++)
            {
                if (tiles[x, y] != null)
                {
                    tiles[x, write] = tiles[x, y];
                    tiles[x, write].y = write;
                    tiles[x, y] = (write == y) ? tiles[x, y] : null;
                    tiles[x, write].transform.localPosition = new Vector3(x * spacing, write * spacing, 0);
                    write++;
                }
            }
            for (int y = write; y < rows; y++) tiles[x, y] = null;
        }
    }

    void FillEmpty()
    {
        for (int x = 0; x < cols; x++)
            for (int y = 0; y < rows; y++)
                if (tiles[x, y] == null)
                    SpawnTileAt(x, y);
    }
}
