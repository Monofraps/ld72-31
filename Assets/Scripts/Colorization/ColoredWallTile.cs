using System.IO;
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
        LevelStateController.Instance.OnPlayerColorChanged += PlayerColorChanged;
    }

    void Destroy()
    {
        LevelStateController.Instance.OnPlayerColorChanged -= PlayerColorChanged;
    }

    void PlayerColorChanged(ColorizationColors color)
    {
        if (color == tileColor)
        {
            collider2D.enabled = false;
        }
        else
        {
            collider2D.enabled = true;
        }
    }
}
