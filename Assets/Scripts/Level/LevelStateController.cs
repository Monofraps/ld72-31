using UnityEngine;
using System.Collections;

public class LevelStateController : MonoBehaviour
{
    public static LevelStateController Instance { get; private set; }
    
    public delegate void PlayerColorChangedHandler(ColorizationColors newPlayerColor);

    public event PlayerColorChangedHandler OnPlayerColorChanged;

    public void PublicPlayerColorChangeEvent(ColorizationColors newPlayerColor)
    {
        OnPlayerColorChanged(newPlayerColor);
    }

    void Start()
    {
        Instance = this;
    }
}
