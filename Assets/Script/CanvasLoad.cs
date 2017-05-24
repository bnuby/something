using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;
using UnityEditor;
using UnityEngine.UI;

public class CanvasLoad : MonoBehaviour {
    
//    public GameObject AnswerTarget;
//    public int Count;

    public GameObject Target;
    public Transform QuestionParent;
    public Transform AnswerParent;
    public string text = "";

    question quiz = new question();
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
            var a = Instantiate(Target);
            a.GetComponentInChildren<Text>().text = e;
            a.transform.SetParent(QuestionParent);
        }
        foreach (string e in quiz.optionsB)
        {
            var a = Instantiate(Target);
            a.GetComponentInChildren<Text>().text = e;
            a.transform.SetParent(AnswerParent);
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
