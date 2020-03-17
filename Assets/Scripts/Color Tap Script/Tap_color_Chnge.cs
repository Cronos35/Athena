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
            //rend = GetComponent<SpriteRenderer>();
            //box1 = Resources.Load<Sprite>("Game Objects/Prefabs/Color tapping game squares_0");
            // print(box1);
            //print(hit.transform.GetComponent<SpriteRenderer>().sprite);
            hit.transform.GetComponent<SpriteRenderer>().sprite = boxes[5];
            
        }
        
    }
}
