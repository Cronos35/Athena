using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTapListener : MonoBehaviour
{
    public static KeyTapListener currentListener;

    private string _noteName;

    private void Awake()
    {
        currentListener = this;
    }

    public event Action<string> onKeyTap;
    public event Action onPlayButtonPress;

    public void sendKeyTap(string noteName)
    {
        onKeyTap?.Invoke(noteName);
    }

    public void PressPlayButton()
    {
        onPlayButtonPress?.Invoke();
    }
}
