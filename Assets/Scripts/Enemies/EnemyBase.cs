using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public bool IsStunned { get; set; }

    void Start()
    {
        IsStunned = false;
    }
}
