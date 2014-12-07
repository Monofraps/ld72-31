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
                Debug.LogError("No power up set for PickupField x=" + transform.position.x + " y=" + transform.position.y);
                return;
            }
            GameObject obj = (GameObject)Instantiate(powerUp);
            ItemBase item = obj.GetComponent<ItemBase>();

            if (!item.activateOnStart)
            {
                PowerupController powerupController = collision.gameObject.GetComponent<PowerupController>();
                powerupController.CurrentItem = item;
            }

            GameObject.Destroy(gameObject);

        }

    }
}
