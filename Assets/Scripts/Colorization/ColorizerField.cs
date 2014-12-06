using UnityEngine;
using System.Collections;

public class ColorizerField : MonoBehaviour
{
    public ColorizationColors fieldColor;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerColorController>().PlayerColor = fieldColor;
        }
    }
}
