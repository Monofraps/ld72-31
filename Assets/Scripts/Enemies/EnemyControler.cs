using UnityEngine;
using System.Collections;

[RequireComponent (typeof(FollowPath))]
public class EnemyControler : MonoBehaviour
{
    public float speed = 5.0f;
    private FollowPath path;
    private bool frozen;
    public bool Frozen
    {
        get{ return frozen; }
        set
        { 
            frozen = value;
            if (frozen)
            {
                path.Speed = 0;
            } else
            {
                path.Speed = speed;
            }
        }
    }

    void Awake()
    {
        path = GetComponent<FollowPath>();
        path.Speed = speed;
        Frozen = true;
    }

    // Use this for initialization
    void Start()
    {
        Frozen = false;
    }
}
