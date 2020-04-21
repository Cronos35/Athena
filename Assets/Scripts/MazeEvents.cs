using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MazeEvents : MonoBehaviour
{
    public static MazeEvents mazeEventsListener;
    
    // Start is called before the first frame update
    void Awake()
    {
        mazeEventsListener = this;
    }

    public event Action OnReachedMazeEnd;
    public void EndGame()
    {
        OnReachedMazeEnd?.Invoke();
    }
    // Update is called once per frame
}
