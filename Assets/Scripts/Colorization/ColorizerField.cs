using UnityEngine;
using System.Collections;

public class ColorizerField : MonoBehaviour
{
    public ColorizationColors fieldColor;

    void Start()
    {
        ((SpriteRenderer)renderer).color = ColorResolver.Instance.ResolveColor(fieldColor);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (collider.OverlapPoint(new Vector2(transform.position.x, transform.position.y)))
            {
                collider.gameObject.GetComponent<PlayerColorController>().PlayerColor = fieldColor;
            }

        }
    }
}
