using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ItemRegistry : MonoBehaviour
{
    public List<GameObject> itemPrefabs;

    public GameObject GetRandomPrefab()
    {
        GameObject selectedItemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Count)];

        return selectedItemPrefab;
    }
}
