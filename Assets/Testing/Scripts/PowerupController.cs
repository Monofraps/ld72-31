using UnityEngine;
using System.Collections;

public class PowerupController : MonoBehaviour {
	ItemRegistry itemRegistry = new ItemRegistry();
	GameObject powerUp;
    public void Callback()
    {
		getPowerup ();
		Debug.Log("sef");
    }
	public void getPowerup(){
		powerUp = itemRegistry.GetRandomPrefab();
		GameObject.Instantiate (powerUp);
	}
}
