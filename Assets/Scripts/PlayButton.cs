using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private TouchControls touchControls;
    private float yPosition;
    private bool eventFired;

    private void Start()
    {
        touchControls = GetComponent<TouchControls>();
        yPosition = transform.position.y;
        eventFired = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (touchControls.isTouched())
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, yPosition - 0.08f, 0f), transform.rotation);

            if (!eventFired)
            {
                KeyTapListener.currentListener.PressPlayButton();
                eventFired = true;
            }

            transform.SetPositionAndRotation(new Vector3(transform.position.x, yPosition, 0f), transform.rotation);
            return;
        }

        else
        {
            eventFired = false;
        }
        transform.SetPositionAndRotation(new Vector3(transform.position.x, yPosition, 0f), transform.rotation);
    }
}
