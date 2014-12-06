using UnityEngine;
using System.Collections;

public class PlayerColorController : MonoBehaviour
{
    public ColorizationColors playerColor;
    public Color redColor;
    public Color greenColor;
    public Color blueColor;

    public void ChangePlayerColor(ColorizationColors fieldColor)
    {
        playerColor = fieldColor;

        switch (playerColor)
        {
                case ColorizationColors.Red:
                ((SpriteRenderer) renderer).color = redColor;
                break;

                case ColorizationColors.Green:
                ((SpriteRenderer)renderer).color = greenColor;
                break;

                case ColorizationColors.Blue:
                ((SpriteRenderer)renderer).color = blueColor;
                break;
        }
    }
}
