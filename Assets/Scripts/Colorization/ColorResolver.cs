using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ColorResolver : MonoBehaviour
{
    public static ColorResolver Instance { get; private set; }

    public Color redColor;
    public Color greenColor;
    public Color blueColor;

    void Awake()
    {
        Instance = this;
    }
   
    public Color ResolveColor(ColorizationColors color)
    {
        switch (color)
        {
                case ColorizationColors.Red:
                return redColor;

                case ColorizationColors.Green:
                return greenColor;

                case ColorizationColors.Blue:
                return blueColor;
        }

        throw new UnityException("Unexpected control flow.");
    }
}
