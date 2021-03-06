﻿using UnityEngine;
using System.Collections;

public class SpeedUpItem : ItemBase
{

    public float speedMultiplier;
    public float duration;
    private PlayerControler playerControler;   

    public override void Activate()
    {
        playerControler = PlayerControler.FindInScene();
        playerControler.speed *= speedMultiplier;
        Invoke("ResetPlayerSpeed", duration);
    }

    void ResetPlayerSpeed()
    {
        playerControler.speed /= speedMultiplier;
        Destroy(gameObject);
    }
}
