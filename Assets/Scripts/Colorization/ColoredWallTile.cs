using UnityEngine;
using System.Collections;

public class ColoredWallTile : MonoBehaviour
{
    public ColorizationColors tileColor = ColorizationColors.Red;

    public ColorizationColors TileColor
    {
        get { return tileColor; }
        set
        {
            tileColor = value;
            ((SpriteRenderer)renderer).color = ColorResolver.Instance.ResolveColor(tileColor);
        }
    }

    void Start()
    {
        TileColor = tileColor;
    }
}
