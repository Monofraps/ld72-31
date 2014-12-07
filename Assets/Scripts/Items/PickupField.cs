using UnityEngine;
using System.Collections;

public class PickupField : MonoBehaviour {

    public GameObject powerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(powerUp == null)
            {
                throw new UnityException("No power up set for PickupField x=" + transform.position.x + " y=" + transform.position.y);
            }
            GameObject obj = (GameObject)Instantiate(powerUp);
            ItemPickupNotification.Instance.ShowPickupNotification(obj.GetComponent<ItemBase>());
            /*
            PowerupController powerupController = collision.gameObject.GetComponent<PowerupController>();
            powerupController.InstantiatePowerup();
            */
            GameObject.Destroy(gameObject);

        }

    }
}
