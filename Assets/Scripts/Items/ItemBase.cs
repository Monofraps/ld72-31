using UnityEngine;
using System.Collections;

public abstract class ItemBase : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;

    public string GetDisplayName()
    {
        return itemName;
    }

    public Sprite GetSprite()
    {
        return itemSprite;
    }

    public abstract void Activate();
}
