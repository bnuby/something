using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Xml.Linq;

public class questionSet{
    public List<question> questionList = new List<question>();
    void addQuiz(question a){
        questionList.Add(a);
    }
}
    
public class question{
    public List<string> optionsA = new List<string>();
    public List<string> optionsB = new List<string>();
    public List<answers> answerList = new List<answers>();

    public void addQuestion(string a, string b){
        optionsA.Add(a);
        optionsB.Add(b);
    }

    public void addAnswer(string a, string b){
        answerList.Add(new answers(a,b));
    }

    public bool[] checkAnswer(List<answers> a){
        bool[] boolean = new bool[a.Count];

        foreach(var i in a){
            foreach (var j in answerList)
            {
                if(i.question == j.question){
                    boolean[a.IndexOf(i)] = true;
                    continue;
                }

            }

        }
        return boolean;

    }
}

public class answers{
    public string question;
    public string answer;
    public answers (string question, string answer){
        this.question = question;
        this.answer = answer;
    }
}