﻿using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float rotationOffset;

    private Rigidbody2D playerRigidbody2d;
    private Animator animator;
    private float rotation;

    // Use this for initialization
    void Start()
    {
        playerRigidbody2d = rigidbody2D;
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation = 90.0f;
            velocity.x = -speed;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation = -90.0f;
            velocity.x = +speed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rotation = 0.0f;
            velocity.y = +speed;
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            rotation = 180.0f;
            velocity.y = -speed;
        }
        playerRigidbody2d.velocity = velocity;
        transform.rotation = Quaternion.Euler(new Vector3(0,0, rotation + rotationOffset));


        animator.SetFloat("Velocity", Mathf.Abs(velocity.x + velocity.y));
    }
}
