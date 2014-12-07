using System;
using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerText : HidableUIText
{
    public Text counterText;

    public void SetTimeInSeconds(float seconds)
    {
        int minutes = Mathf.FloorToInt((float)(seconds / 60f));
        counterText.text = String.Format("{0}:{1:00.0}", minutes, (seconds - minutes * 60f));
    }
}
