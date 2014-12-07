﻿using UnityEngine;
using System.Collections;

public class PlayerColorController : MonoBehaviour
{
    public ColorizationColors playerColor;

    public ColorizationColors PlayerColor
    {
        get { return playerColor; }
        set
        {
            if(value != playerColor)
            {
                playerColor = value;
                ((SpriteRenderer)renderer).color = ColorResolver.Instance.ResolveColor(playerColor);
                GameController.Instance.PublishPlayerColorChangeEvent(playerColor);
            }
        }
    }
}
