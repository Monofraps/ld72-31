using UnityEngine;
using System.Collections;

public class ItemBase : MonoBehaviour
{
    public string itemName;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public string GetDisplayName()
    {
        return itemName;
    }
}
