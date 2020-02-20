using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class NSGameManager : MonoBehaviour{
    public Question[] questions;
    public float nsScore;
    public static List<Question> listOfQuestions;
    private float currCountdownValue;
    private Question currentQuestion;
    private GameObject button1, button2, button3, button4, timer;
    private bool gameOver;

    [SerializeField]
    private Text questionText, choice1, choice2, choice3, choice4;


    void Start(){
    	button1 = GameObject.Find("Choice1");
    	button2 = GameObject.Find("Choice2");
    	button3 = GameObject.Find("Choice3");
    	button4 = GameObject.Find("Choice4");
    	timer = GameObject.Find("Timer");
    	button1.SetActive(false);
    	button2.SetActive(false);
    	button3.SetActive(false);
    	button4.SetActive(false);
    	if(listOfQuestions == null){
    		listOfQuestions = questions.ToList<Question>();
    	}

    	GetRandomQuestion();
    	StartCoroutine(StartCountdown());
    }


    void GetRandomQuestion(){
    	int randomQuestionIndex = Random.Range(0, listOfQuestions.Count);
    	currentQuestion = listOfQuestions[randomQuestionIndex];
    	questionText.text = currentQuestion.question;
    	choice1.text = currentQuestion.choice1;
    	choice2.text = currentQuestion.choice2;
    	choice3.text = currentQuestion.choice3;
    	choice4.text = currentQuestion.choice4;


    }

    public void checkAnswer(Button btn){
    	if(btn.GetComponentInChildren<Text>().text == currentQuestion.answer){
    		gameOver = true;
    		
    		btn.GetComponent<Image>().color = new Color(0, 255, 0);
    		if(currCountdownValue >= 20){
    			nsScore = 10;
    		}else if(currCountdownValue >= 15 && currCountdownValue < 20){
    			nsScore = 8;
    		}else if(currCountdownValue >= 10 && currCountdownValue < 15){
    			nsScore = 6;
    		}else if(currCountdownValue >= 5 && currCountdownValue < 10){
    			nsScore = 4;
    		}else{
    			nsScore = 2;
    		}


    		Debug.Log(nsScore);
    		Debug.Log((nsScore/10)* 100 + "% in Logical Skill");
    	}else{
    		btn.GetComponent<Image>().color = new Color(255, 0, 0);
    		currCountdownValue = currCountdownValue - 5;
    	}
    }

	 public IEnumerator StartCountdown(float countdownValue = 5)
	 {

	     currCountdownValue = countdownValue;
	     while (currCountdownValue >= 0)
	     {		
	     	 timer.GetComponentInChildren<Text>().text = currCountdownValue.ToString();
	         yield return new WaitForSeconds(1.0f);
	         currCountdownValue--;
	     }
	    button1.SetActive(true);
    	button2.SetActive(true);
    	button3.SetActive(true);
    	button4.SetActive(true);
    	StartCoroutine(QuestionTimer());
	 }

	 public IEnumerator QuestionTimer(float countdownValue = 30)
	 {

	     currCountdownValue = countdownValue;
	     while (currCountdownValue >= 0)
	     {		
	         if(gameOver){
	         	yield break;
	         }else{
	         	timer.GetComponentInChildren<Text>().text = currCountdownValue.ToString();
	         	yield return new WaitForSeconds(1.0f);
	         	currCountdownValue--;
	         }  
	     }
	 }


}
