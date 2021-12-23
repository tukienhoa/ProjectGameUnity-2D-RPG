using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDialog : MonoBehaviour
{
    public event Action OnYesEvent;
    public event Action OnNoEvent;

    public Text text;

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnYesButtonClick()
    {
        if (OnYesEvent != null)
        {
            OnYesEvent();
            OnYesEvent = null;
        }

        gameObject.SetActive(false);
    }

    public void OnNoButtonClick()
    {
        if (OnNoEvent != null)
        {
            OnNoEvent();
        }

        OnYesEvent = null;
        gameObject.SetActive(false);
    }

    public bool IsOnYesEventNull()
    {
        return OnYesEvent == null;
    }
}
