using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ItemRegistry : MonoBehaviour
{
    public List<GameObject> itemPrefabs;

    public GameObject GetRandomPrefab()
    {
        GameObject selectedItemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Count)];

        if (selectedItemPrefab.GetComponent<ItemBase>() == null)
        {
            throw new UnityException("Found item prefab without ItemBase script");
        }

        return selectedItemPrefab;
    }
}
