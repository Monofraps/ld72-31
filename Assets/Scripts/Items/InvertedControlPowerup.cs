using UnityEngine;
using System.Collections;

public class InvertedControlPowerup : ItemBase {

    public float duration;
    private PlayerControler playerControler;

    public override void Activate()
    {
        playerControler = PlayerControler.FindInScene();
        playerControler.IsControlInverted = true;
        Invoke("DisableControlInversion", duration);
    }

    private void DisableControlInversion()
    {
        playerControler.IsControlInverted = false;
        Destroy(gameObject);
    }
}
