using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    public int selected_box=0;

    //HIDDEN SCORE
    public Text txtScore;
    public Text txtwrong;
    public int score_correct_input = 0;
    public int score_wrong_input = 0;
    //boxes

    //check
    bool check_clr = false;

    void Start()
    {
        set_Color();
        set_Question();
        selected_Box();
        check_color();
        display();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
           if(hit.transform.name!="question")
            {
                selected_Box();
                check_color();
                /*
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    int rand = Random.Range(0, 8);
                    hit.transform.GetComponent<SpriteRenderer>().sprite = boxes[rand];
                }
                */
                if (Input.GetMouseButtonDown(0))
                //if (Input.touchCount > 0)
                {
                    //Touch touch = Input.GetTouch(0);
                    if (box[selected_box]==question_value)
                    {
                        score_correct_input++;
                        txtScore.text = "CORRECT: " + score_correct_input.ToString();
                    }
                    else
                    {
                        score_wrong_input++;
                        txtwrong.text = "WRONG: " + score_wrong_input.ToString();
                    }
                    while(true)
                    {
                        int rand = Random.Range(0, 8);
                        if(box[selected_box]!=rand)
                        {
                            box[selected_box] = rand;
                            break;
                        }
                    }
                }
            }
        }
        
    }

    void selected_Box()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == "box1")
            {
                selected_box = 0;
            }
            if (hit.transform.name == "box2")
            {
                selected_box = 1;
            }
            if (hit.transform.name == "box3")
            {
                selected_box = 2;
            }
            if (hit.transform.name == "box4")
            {
                selected_box = 3;
            }
            if (hit.transform.name == "box5")
            {
                selected_box = 4;
            }
            if (hit.transform.name == "box6")
            {
                selected_box = 5;
            }
            if (hit.transform.name == "box7")
            {
                selected_box = 6;
            }
            if (hit.transform.name == "box8")
            {
                selected_box = 7;
            }
            if (hit.transform.name == "box9")
            {
                selected_box = 8;
            }
        }
    }
    void set_Color()
    {
        for(int i=0;i<9;i++)
        {
            int rand = Random.Range(0, 8);
            box[i] = rand;
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
        for(int i=0;i<9;i++)
        {
            if(box[i]==question_value)
            {
                count++;
            }
        }
        if(count==0)
        {
            set_Color();
        }
        else
        {
            display();
        }
        check_clr = true;
    }
    void display()
    {
        for(int i=0;i<9;i++)
        {
            boxes[i].transform.GetComponent<SpriteRenderer>().sprite = colors[box[i]];
        }
    }
}
