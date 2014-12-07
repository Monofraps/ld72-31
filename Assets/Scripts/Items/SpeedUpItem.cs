using UnityEngine;
using System.Collections;

public class SpeedUpItem : ItemBase
{

    public float speedMultiplier;
    public float duration;
    private PlayerControler playerControler;   

    public override void Activate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            throw new UnityException("No player found in the scene.");
        }
        playerControler = player.GetComponent<PlayerControler>();
        if (playerControler == null)
        {
            throw new UnityException("No PlayerControler attached to Player Gameobject.");
        }
        playerControler.speed *= speedMultiplier;
        Invoke("ResetPlayerSpeed", duration);
    }

    void ResetPlayerSpeed()
    {
        playerControler.speed /= speedMultiplier;
        Destroy(gameObject);
    }
}
