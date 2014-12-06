using UnityEngine;
using System.Collections;

public class ColoredWallTile : MonoBehaviour
{
    private ColorizationColors tileColor = ColorizationColors.Red;

    public ColorizationColors TileColor
    {
        get { return tileColor; }
        set
        {
            tileColor = value;
            ((SpriteRenderer)renderer).color = ColorResolver.Instance.ResolveColor(tileColor);
        }
    }
}
