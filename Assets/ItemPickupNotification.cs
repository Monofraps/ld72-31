using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPickupNotification : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = "";
    }

    public void ShowPickupNotification(ItemBase item)
    {
        text.text = item.GetDisplayName();
    }
}
