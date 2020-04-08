using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvents : MonoBehaviour
{
    public static TouchEvents touchListener;

    public event Action onTouch;

    public void sendTouch()
    {
        onTouch?.Invoke();
    }

    private void Awake()
    {
        touchListener = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
