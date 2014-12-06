using UnityEngine;
using System.Collections;

public class PickupField : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PowerupController powerupController = collision.gameObject.GetComponent<PowerupController>();
            powerupController.Callback();

            GameObject.Destroy(gameObject);
        }

    }
}
