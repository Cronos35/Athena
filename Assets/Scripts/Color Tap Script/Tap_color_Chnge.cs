﻿using System.Collections;
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

    //Penalty For Not touching
    public Text txtpenalty;
    float penaltyTime = 1f;//Initial Penalty Time
    float timeLeft;
    bool turnonpenalty = false;

    public int totalpentalty = 0;
    public int score_correct_input = 0;
    public int score_wrong_input = 0;
    //boxes
    bool allowTouch = true;

    //Countdown for game to stop
    public int countDownTimer;
    public Text countDowntxt;
    bool gameStop = false;

    //Countdown to start the game
    public int gameStartTimer;
    public Text gameStarttxt;

    //ALL BOXES
    public GameObject allboxes;

    //Max Score
    public int maxScore = 30;

    //Total Game Score
    public int gameScore;
    void Start()
    {
        allboxes.SetActive(false);
        set_Color();
        set_Question();
        check_color();
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameStop!=true)
        {
            selected_Box();
            check_color();
            if(turnonpenalty==true)
            {
                penalty();
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name != "question")
                {
                    //if (Input.GetMouseButtonDown(0))
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);

                        if (allowTouch == true)
                        {
                            allowTouch = false;
                            if (box[selected_box] == question_value)
                            {
                                score_correct_input++;
                            }
                            else
                            {
                                score_wrong_input++;
                            }
                            while (true)
                            {
                                int rand = Random.Range(0, 8);
                                if (box[selected_box] != rand)
                                {
                                    box[selected_box] = rand;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        allowTouch = true;
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
    }
    void display()
    {
        for(int i=0;i<9;i++)
        {
            boxes[i].transform.GetComponent<SpriteRenderer>().sprite = colors[box[i]];
        }
    }
    //Penalty For being slow hehe
    void penalty()
    {
        penaltyTime -= 1 * Time.deltaTime;
        //txtpenalty.text = penaltyTime.ToString();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                penaltyTime = 1;
                print("Total Penalty: " + totalpentalty);
            }
        }
        if (penaltyTime<=0)
        {
            totalpentalty++;
            penaltyTime = 1;
            print("Total Penalty: "+totalpentalty);
        }
    }
    IEnumerator CountDown()
    {
        while(countDownTimer>=0)
        {
            countDowntxt.text = "TIME: "+countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }
        gameStop = true;
        allboxes.SetActive(false);
        
        get_GameResultScore();
    }
    IEnumerator StartGame()
    {
        while (gameStartTimer>0)
        {
            gameStarttxt.text = gameStartTimer.ToString();
            yield return new WaitForSeconds(1f);
            gameStartTimer--;
        }
        gameStarttxt.text = "GO!";
        yield return new WaitForSeconds(1f);
        allboxes.SetActive(true);
        //Destroy(gameStarttxt);
        gameStarttxt.text = "";
        StartCoroutine(CountDown());
        turnonpenalty = true;
    }
    void get_GameResultScore()
    {
        int result;
        int correct = score_correct_input;
        int wrong = score_wrong_input;
        int penalty = totalpentalty;

        if(correct>=30)
        {
            print("Ni lapaw ang score so");
            correct = 30;
        }
        int difference = maxScore - correct;

        print(correct);
        print(wrong);
        print(penalty);
        print(difference);
        result = correct - wrong;
        
        result -=difference;
        
        result -= penalty;
        if(result<=5)
        {
            result = 5;
        }
        gameScore = result;
        print("Game Score: "+gameScore);
        gameStarttxt.fontSize = 48;
        gameStarttxt.text = "TIME'S UP!";
    }
}
