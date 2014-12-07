using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsText : HidableUIText
{
    public Text pointsText;

    void Start()
    {
        IsVisible = false;
    }

    public void SetPoints(int points)
    {
        pointsText.text = points.ToString();
    }
}
