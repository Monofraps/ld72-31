using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPickupNotification : MonoBehaviour
{
    public static ItemPickupNotification Instance { get; private set; }

    public Text text;
    public Image itemImage;

    public double showDuration = 2;

    private double elapsedTime = 0;
    private bool isDisplaying = false;

    void Start()
    {
        Instance = this;
        text.text = "";
        itemImage.gameObject.SetActive(false);
    }

    public void ShowPickupNotification(ItemBase item)
    {
        text.text = item.GetDisplayName();
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = item.GetSprite();
        isDisplaying = true;
    }

    void Update()
    {
        if (!isDisplaying)
        {
            return; 
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= showDuration)
        {
            text.text = "";
            itemImage.gameObject.SetActive(false);
            elapsedTime = 0;
            isDisplaying = false;
        }
    }
}
