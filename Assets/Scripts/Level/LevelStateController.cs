using UnityEngine;
using System.Collections;

public class LevelStateController : MonoBehaviour
{
    public delegate void PlayerColorChangedHandler(ColorizationColors newPlayerColor);

    public event PlayerColorChangedHandler OnPlayerColorChanged;

    public void PublishPlayerColorChangeEvent(ColorizationColors newPlayerColor)
    {
        if (OnPlayerColorChanged != null)
        {
            OnPlayerColorChanged(newPlayerColor);
        }
    }
}
