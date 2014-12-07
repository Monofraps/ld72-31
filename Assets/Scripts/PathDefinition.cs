using UnityEngine;
using System.Collections.Generic;

public class PathDefinition : MonoBehaviour
{
    public List<Vector2> points { get; private set; }

    void Awake()
    {
        points = new List<Vector2>();
        foreach (Transform child in transform)
        {
            points.Add(new Vector2(child.position.x, child.position.y));
        }
    }
    
    void OnDrawGizmos()
    {
        Transform[] points = gameObject.GetComponentsInChildren<Transform>();

        if (points == null || points.Length < 3)
        {
            return;
        }
        for (int i = 2; i < points.Length; ++i)
        {
            Gizmos.DrawLine(points[i-1].position, points[i].position);
        }
    }

}
