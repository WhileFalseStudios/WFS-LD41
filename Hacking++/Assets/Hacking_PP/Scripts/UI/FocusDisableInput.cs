using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FocusDisableInput : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public void OnDeselect(BaseEventData eventData)
    {
        if (PlayerStats.instance != null)
        {
            PlayerStats.instance.isInEditor = false;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (PlayerStats.instance != null)
        {
            PlayerStats.instance.isInEditor = true;
        }
    }
}
