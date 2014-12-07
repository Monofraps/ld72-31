using System;
using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsText : HidableUIText
{
    public Text pointsText;
    public Text diamondsCounterText;

    void Start()
    {
        IsVisible = false;
    }

    public void SetPoints(int points)
    {
        pointsText.text = points.ToString();
    }

    public void SetDiamonds(int collectedDiamonds, int totalDiamonds)
    {
        diamondsCounterText.text = String.Format("You collected {0} of {1} diamonds.", collectedDiamonds, totalDiamonds);
    }
}
