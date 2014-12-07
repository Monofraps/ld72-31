using UnityEngine;
using System.Collections;

public class PowerupController : MonoBehaviour
{
    public ItemPickupNotification pickupUI;

    private ItemBase currentItem;
    public ItemBase CurrentItem
    {
        set
        {
            currentItem = value;
            if(currentItem)
            {
                pickupUI.ShowPickupNotification(currentItem);
            }
        }
        get
        {
            return currentItem;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentItem)
            {
                CurrentItem.Activate();
                pickupUI.ClosePickupNotification();
                CurrentItem = null;

            }
        }
    }

    
}
