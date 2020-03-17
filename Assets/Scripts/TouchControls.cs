using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private Vector3 objectPosition;
    private Rigidbody2D rb;
    private SwipeData swipe;

    private float xPosition;
    private float yPosition;

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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

            if(hitInfo.collider != null)
            {
                GameObject touchedObject = hitInfo.transform.gameObject;

                //Make sure the tag of the object using this script is player and has a dynamic Rigidbody2D 
                if (touchedObject.tag == "Player")
                {
                    if(swipe.Direction == SwipeDirection.Up || swipe.Direction == SwipeDirection.Down)
                    {
                        xPosition = touchedObject.transform.position.x;
                        yPosition = touchWorldPos2d.y;

                        //touchedObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(touchedObject.transform.position.x, touchWorldPos2d.y));
                    }
                    else if (swipe.Direction == SwipeDirection.Left || swipe.Direction == SwipeDirection.Right)
                    {
                        xPosition = touchWorldPos2d.x;
                        yPosition = touchedObject.transform.position.y;

                        //touchedObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(touchWorldPos2d.x, touchedObject.transform.position.y));
                    }

                    touchedObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(xPosition, yPosition));

                    //touchedObject.GetComponent<Rigidbody2D>().MovePosition(touchWorldPos2d);
                    //if (Input.GetAxis("Vertical") == 1f || Input.GetAxis("Vertical") == -1f)
                    //{
                    //    touchedObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0, touchWorldPos2d.y));
                    //}
                }
            }
        }
    }

    void SwipeDetector_OnSwipe(SwipeData data)
    {
        swipe = data;
    }
}
