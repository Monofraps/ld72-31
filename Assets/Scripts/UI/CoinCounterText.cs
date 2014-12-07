using System;
using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCounterText : HidableUIText
{
    public Text counterText;

    void Start()
    {
        SetCoinCount(0);
    }
    
    public void SetCoinCount(int coins)
    {
        counterText
            .text = String.Format("{0}", coins);
    }
}
