﻿using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour
{
    public float initialDelay = 0;
    private float timer = 0;
    public enum FollowStrategy
    {
        Circle,
        Pingpong
    }
    public FollowStrategy followStrategy = FollowStrategy.Pingpong;
    public float Speed{ get; set; }
    public PathDefinition path;
    private int targetPoint;
    private enum Direction
    {
        Up,
        Down,
    }
    Direction direction;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        if (path.points.Count > 0)
        {
            transform.position = path.points[0];
            targetPoint = 1;
        }

        direction = Direction.Up;
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < initialDelay)
        {
            return;
        }
        if (path.points.Count < 2)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, path.points [targetPoint], Speed * Time.deltaTime);
        if (transform.position.x == path.points [targetPoint].x &&
            transform.position.y == path.points [targetPoint].y )
        {
            if(followStrategy == FollowStrategy.Pingpong)
            {
                if (targetPoint == path.points.Count - 1)
                {
                    direction = Direction.Down;
                } else if(targetPoint == 0)
                {
                    direction = Direction.Up;
                }
                
                if(direction == Direction.Up)
                {
                    ++targetPoint;
                }else{
                    --targetPoint;
                }
            }
            else
            {
                if (targetPoint == path.points.Count - 1)
                {
                    targetPoint = 0;
                    
                } else
                {
                    ++targetPoint;
                }
            }
        }

    }

   
}
