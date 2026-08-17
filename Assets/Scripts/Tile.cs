using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, y;
    public int colorId; // simple integer id for color/type

    // Visual helpers
    public void SetColor(int id, Color color)
    {
        colorId = id;
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.color = color;
    }
}
