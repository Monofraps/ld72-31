using System.IO.Compression;
using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.Instance.Coins++;
            Destroy(gameObject);
        }
    }
}
