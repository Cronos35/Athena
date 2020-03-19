using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_color_Chnge : MonoBehaviour
{
    public Sprite[] colors; 
    private SpriteRenderer rend;

    //BOXES
    public GameObject[] boxes;
    public GameObject question;

    //BOXES VALUE
    private int[] box = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private int question_value = 0;
    

    //boxes

    void Start()
    {
        set_Color();
        set_Question();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        set_Color();

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
                    hit.transform.GetComponent<SpriteRenderer>().sprite = colors[rand];
                }

            }
        }
        
    }
    void set_Color()
    {
        for(int i=0;i<9;i++)
        {
            int rand = Random.Range(0, 8);
            box[i] = rand;
            boxes[i].transform.GetComponent<SpriteRenderer>().sprite = colors[rand];
        }
    }
    void set_Question()
    {
        int rand = Random.Range(0, 8);
        question_value = rand;
        question.transform.GetComponent<SpriteRenderer>().sprite = colors[question_value];
    }
    void check_color()
    {
        int count = 0;
        for (int i = 0; i < 9; i++)
        {
            if (box[i]==question_value)
            {
                count++;
            }
        }
        if (count == 0)
        {
            set_Color();
           
        }
    }
}
