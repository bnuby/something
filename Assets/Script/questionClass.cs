using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Xml.Linq;
using UnityEditor;
using UnityEditorInternal;
using System.IO;



public class questionSet {
    public List<question> questionList = new List<question>();
    void addQuiz(question a){
        questionList.Add(a);
    }
}
    
public class question : MonoBehaviour{
    public List<string> optionsA = new List<string>();
    public List<string> optionsB = new List<string>();
    public List<answers> answerList = new List<answers>();

//    public void addOptionA(string a){
//        optionsA.Add(a);
//    }
//    public void addOptionB(string a ){
//        optionsB.Add(a);
//    }
//
//    public void addAnswer(string a, string b){
//        answerList.Add(new answers(a,b));
//    }

    public bool[] checkAnswer(Dictionary<int, answers> a){
        bool[] Bool = new bool[a.Count];

        for ( int i = 0 ; i < a.Count ; i++)
        {
            foreach (var j in answerList)
            {
                if(a[i].question == j.question && a[i].answer == j.answer){
                    Bool[i] = true;
                    continue;
                }
            }
        }

       
        return Bool;
    }
}

public class answers{
    public string question;
    public string answer;
    public answers (){
        
    }
    public answers (string question, string answer){
        this.question = question;
        this.answer = answer;
    }
}