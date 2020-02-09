using System;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 fingerUpPosition;
    private Vector2 fingerDownPosition;

    private float minSwipeDistance = 20f;

    public static event Action<SwipeData> OnSwipe = delegate { };

    // Start is called before the first frame update
    void Start()
    {
           
    }


    // Update is called once per frame
    void Update()
    {
      
    }

   
}
