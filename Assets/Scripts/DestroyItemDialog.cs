using System;
using UnityEngine;

public class DestroyItemDialog : MonoBehaviour
{
    public event Action OnYesEvent;
    public event Action OnNoEvent;

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnYesButtonClick()
    {
        if (OnYesEvent != null)
        {
            OnYesEvent();
        }
        gameObject.SetActive(false);
    }

    public void OnNoButtonClick()
    {
        if (OnNoEvent != null)
        {
            OnNoEvent();
        }
        gameObject.SetActive(false);
    }
}
