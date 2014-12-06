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

    private LevelStateController levelStateController;

    void Start()
    {
        TileColor = tileColor;
        levelStateController = transform.parent.gameObject.GetComponent<LevelStateController>();
        levelStateController.OnPlayerColorChanged += PlayerColorChanged;
    }

    void Destroy()
    {
        levelStateController.OnPlayerColorChanged -= PlayerColorChanged;
    }

    void PlayerColorChanged(ColorizationColors color)
    {
        collider2D.enabled = color != tileColor;
    }
}
