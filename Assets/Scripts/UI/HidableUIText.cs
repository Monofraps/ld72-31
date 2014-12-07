using UnityEngine;
using System.Collections;

public class HidableUIText : MonoBehaviour {

    public bool IsVisible
    {
        get { return gameObject.activeInHierarchy; }
        set
        {
            gameObject.SetActive(value);
        }
    }
}
