using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;
using UnityEditor;


public class CanvasLoad : MonoBehaviour {
    
    public GameObject AnswerTarget;
    public GameObject QuestionTarget;
    public GameObject prefabs;
//    public int Count;

//    public GameObject Target;
    public Transform QuestionParent;
    public Transform AnswerParent;
    [HideInInspector]
    public string text = "";public int linkCount = 0;public Dictionary<int, answers> answerList = new Dictionary<int, answers>();
    question quiz = new question();
    bool check = false;


	// Use this for initialization
	void Start () {
        readJson();
        constructQuiz();

	}
        
    void readJson(){
        var OpenFile = File.OpenText("Assets/Json/question.json");
        text = OpenFile.ReadToEnd();
        quiz = JsonMapper.ToObject<question> (text); 
    }
        

    void constructQuiz(){
        foreach (string e in quiz.optionsA)
        {
            var a = Instantiate(QuestionTarget);
            a.GetComponentInChildren<Text>().text = e;
            a.transform.SetParent(QuestionParent);
        }
        foreach (string e in quiz.optionsB)
        {
            var a = Instantiate(AnswerTarget);
            a.GetComponentInChildren<Text>().text = e;
            a.transform.SetParent(AnswerParent);
        }
    }
        

	// Update is called once per frame
	void Update () {
        if (linkCount == quiz.optionsA.Count && !check)
        {
            
            this.transform.FindChild("Button").transform.DOKill(true);
            this.transform.FindChild("Button").transform.DOMoveY(this.transform.position.y , 2 , false);
            this.transform.FindChild("Button").GetComponent<Button>().onClick.AddListener(Check);
            check = true;
        }
        else if (linkCount != quiz.optionsA.Count && check)
        {
            check = false;
            this.transform.FindChild("Button").transform.DOKill(true);
            this.transform.FindChild("Button").transform.DOMoveY(-50f , 1 , false); 
        }
	}

    void Check()
    {
        this.transform.FindChild("Button").GetComponent<Button>().onClick.RemoveAllListeners();
        this.transform.FindChild("Button").GetComponent<Button>().GetComponentInChildren<Text>().text = "Next";

        this.transform.FindChild("Button").GetComponent<Button>().onClick.AddListener(Next);

        var green = new Color(0, 255, 0);
        var red = new Color(255, 0, 0);
        bool[] checkList = quiz.checkAnswer(answerList);
        for(int i = 0 ; i < checkList.Length; i++){
            var currentTarget = this.QuestionParent.GetChild(i);
            if (checkList[i])
            {
                currentTarget.transform.GetComponent<LineRenderer>().startColor = green;
                currentTarget.transform.GetComponent<LineRenderer>().endColor = green;

            }
            else
            {                    
                bool find = false;
                currentTarget.transform.GetComponent<LineRenderer>().startColor = red;
                currentTarget.transform.GetComponent<LineRenderer>().endColor = red;

//                currentTarget.transform.GetComponent<LineRenderer>().SetPosition(0, LineStartLocation(currentTarget));
                for (int j = 0; j < AnswerParent.childCount; j++)
                {
                    if (AnswerParent.GetChild(j).GetComponentInChildren<Text>().text == quiz.answerList[i].answer && QuestionParent.GetChild(j).GetComponentInChildren<Text>().text == quiz.answerList[i].question)
                    {
                        find = true;
                        var destinationTarget = AnswerParent.GetChild(j);
                        var numOfPos = currentTarget.transform.GetComponent<LineRenderer>().numPositions += 2;

                        currentTarget.transform.GetComponent<LineRenderer>().SetPosition(numOfPos-2, LineStartLocation(currentTarget));
                        currentTarget.transform.GetComponent<LineRenderer>().SetPosition(numOfPos-1, LineStartLocation(destinationTarget));

                    }
                }
                if (find == false)
                {
                    currentTarget.transform.GetComponent<LineRenderer>().numPositions = 0;
                }
            }
        }

//        print(answerList[0].answer);
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Next(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    Vector3 LineStartLocation(Transform a){

        if ( a.transform.parent.CompareTag("QuestionList"))
        {
            var DragObjectPosX = a.transform.position.x + a.transform.GetComponent<RectTransform>().rect.width / 2 - 10;
            var DragObjectPosY = a.transform.position.y;

            return Camera.main.ScreenToWorldPoint(new Vector3(DragObjectPosX, DragObjectPosY, 10));

        }
        else if (a.transform.parent.CompareTag("AnswerList"))
        {

            var DragObjectPosX = a.transform.position.x - a.transform.GetComponent<RectTransform>().rect.width / 2 + 10;
            var DragObjectPosY = a.transform.position.y ;

            return Camera.main.ScreenToWorldPoint(new Vector3(DragObjectPosX, DragObjectPosY, 10));
        }
        return new Vector3(0,0,0);
    }

}


    