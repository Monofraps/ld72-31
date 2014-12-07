using UnityEngine;
using System.Collections;

public class PlayerColorController : MonoBehaviour
{
    public ColorizationColors playerColor;

    public ColorizationColors PlayerColor
    {
        get { return playerColor; }
        set
        {
            if (value != playerColor)
            {
                playerColor = value;
                ((SpriteRenderer)renderer).color = ColorResolver.Instance.ResolveColor(playerColor);
                GameController.Instance.PublishPlayerColorChangeEvent(playerColor);
            }
        }
    }

    void Update()
    {
        if (Application.isEditor)
        {

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.T))
            {
                PlayerColor = ColorizationColors.Red;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.G))
            {
                PlayerColor = ColorizationColors.Green;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.B))
            {
                PlayerColor = ColorizationColors.Blue;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
            {
                PlayerColor = ColorizationColors.White;
            }
        }
    }

}
