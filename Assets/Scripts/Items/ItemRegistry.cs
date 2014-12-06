using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ItemRegistry : MonoBehaviour
{
    public static ItemRegistry Instance { get; private set; }

    public List<GameObject> itemPrefabs;

    void Start()
    {
        Instance = this;
    }

    public void InstantiateRandomItem()
    {
        
    }
}
