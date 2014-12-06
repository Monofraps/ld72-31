using UnityEngine;
using System.Collections;

public class PowerupController : MonoBehaviour {
	public ItemRegistry itemRegistry;
    public ItemPickupNotification pickupNotification;

	public void InstantiatePowerup(){
		GameObject powerUp = itemRegistry.GetRandomPrefab();
		ItemBase powerupInstance = ((GameObject)Instantiate (powerUp)).GetComponent<ItemBase>();
        pickupNotification.ShowPickupNotification(powerupInstance);
	}
}
