using UnityEngine;
using System.Collections;

public abstract class ItemBase : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;
    public bool activateOnStart;

    void Start()
    {
        if (activateOnStart)
        {
            Activate();
        }
    }

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
