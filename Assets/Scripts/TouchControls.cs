using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private Vector3 objectPosition;
    private Rigidbody2D rb;
    private SwipeData swipe;
    private bool touched = false;

    private float xPosition;
    private float yPosition;

    Vector2 touchWorldPos2d;
    RaycastHit2D hitInfo;
    //= Physics2D.Raycast(touchWorldPos2d, Camera.main.transform.forward);

    //if this is set to false, sprite that will have this script can move around the screen freely. Otherwise, it will only move in a linear fashion vertically or horizontally. 
    [SerializeField] private bool restrictMoveDirection = true;
    private bool touchEventFired = false;

    private void Awake()
    {
        touchWorldPos2d =  new Vector2(objectPosition.x, objectPosition.y);
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
        rb = GetComponent<Rigidbody2D>();
    }

    private void detectTouchOnObject()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            objectPosition = Camera.main.ScreenToWorldPoint(touch.position);
            objectPosition.z = 0f;
        }
    }

    private void Start()
    {
        touchEventFired = false;   
    }

    // Start is called before the first frame update

    // Update is called once per frame

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            objectPosition = Camera.main.ScreenToWorldPoint(touch.position);
            objectPosition.z = 0f;
         
            Vector2 touchWorldPos2d = new Vector2(objectPosition.x, objectPosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(touchWorldPos2d, Camera.main.transform.forward);

            if(hitInfo.collider != null && touch.phase != TouchPhase.Ended)
            {
                GameObject touchedObject = hitInfo.transform.gameObject;              

                //Make sure the tag of the object using this script is player and has a dynamic Rigidbody2D 
                //if (touchedObject.tag == "Player" && touchedObject.gameObject == gameObject)

                if (touchedObject.gameObject == gameObject)
                {
                    setTouchedStatus(true);

                    if (restrictMoveDirection)
                    {
                        if (swipe.Direction == SwipeDirection.Up || swipe.Direction == SwipeDirection.Down)
                        {
                            xPosition = touchedObject.transform.position.x;
                            yPosition = touchWorldPos2d.y;
                        }
                        else if (swipe.Direction == SwipeDirection.Left || swipe.Direction == SwipeDirection.Right)
                        {
                            xPosition = touchWorldPos2d.x;
                            yPosition = touchedObject.transform.position.y;
                        }
                    }

                    else
                    {
                        xPosition = touchWorldPos2d.x;
                        yPosition = touchWorldPos2d.y;
                    }

                    if (rb != null)
                    {
                        touchedObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(xPosition, yPosition));
                    }
                }
            }
            else
            {
                setTouchedStatus(false);
            }
        }
    }

    public bool isTouched()
    {
        return touched;
    }

    private void setTouchedStatus(bool touchedStatus)
    {
        touched = touchedStatus;
    }

    void SwipeDetector_OnSwipe(SwipeData data)
    {
        swipe = data;
    }
}
