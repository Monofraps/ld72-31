using UnityEngine;
using System.Collections.Generic;

public class PathDefinition : MonoBehaviour
{
    public List<Transform> points { get; private set; }

    // Use this for initialization
    void Start()
    {
        points = new List<Transform>();
        foreach (Transform child in transform)
        {
            points.Add(child);
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
