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
    public void sendKeyTap(string noteName)
    {
        onKeyTap?.Invoke(noteName);
    }
    
    // Start is called before the first frame update
    void Start()
    {
    
    }
      
    public void SetNoteName(string noteName)
    { 
        _noteName = noteName;
    }

    public string GetNoteName()
    {
        return _noteName;
    }
}
