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

    public void SetPoints(double seconds)
    {
        int minutes = Mathf.FloorToInt((float)(seconds / 60f));
        pointsText.text = String.Format("{0}:{1:00.0}", minutes, (seconds - minutes * 60f));
    }

    public void SetDiamonds(int collectedDiamonds, int totalDiamonds)
    {
        diamondsCounterText.text = String.Format("You collected {0} of {1} diamonds.", collectedDiamonds, totalDiamonds);
    }
}
