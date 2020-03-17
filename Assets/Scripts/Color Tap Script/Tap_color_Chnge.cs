using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_color_Chnge : MonoBehaviour
{
    public Sprite[] boxes; 
    private SpriteRenderer rend;

    //boxes
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
           if(hit.transform.name!="")
            {
                /*
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    int rand = Random.Range(0, 8);
                    hit.transform.GetComponent<SpriteRenderer>().sprite = boxes[rand];
                }
                */
                if (Input.GetMouseButtonDown(0))
                {
                    int rand = Random.Range(0, 8);
                    hit.transform.GetComponent<SpriteRenderer>().sprite = boxes[rand];
                }

            }
        }
        
    }
}
