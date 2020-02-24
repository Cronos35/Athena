using System;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 fingerUpPosition;
    private Vector2 fingerDownPosition;

    private SwipeDirection swipeDirection;

    public Transform level;

    //when the player is active, the Awake() routine will bind the SwipeDetector_OnSwipe method to the OnSwipe event of the Swipe Detector script, allowing the user to make use of the data of the swipe
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    // Start is called before the first frame update
    void Start()
    {
           
    }
    
    // Update is called once per frame
    void Update()
    {              
              
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        swipeDirection = data.Direction;
        
        if (swipeDirection == SwipeDirection.Up)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
        }
    } 
}
