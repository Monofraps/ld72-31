using UnityEngine;
using System.Collections;

public class ShieldItem : ItemBase
{
    public float duration;
    private PlayerControler playerControler;   
    
    public override void Activate()
    {
        playerControler = PlayerControler.FindInScene();
        playerControler.Shield = true;
        Invoke("DeactivateShield", duration);
    }

    private void DeactivateShield()
    {
        playerControler.Shield = false;
        Destroy(gameObject);
    }
    


}
