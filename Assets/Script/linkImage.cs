using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class linkImage : MonoBehaviour {

    public Button btn; 

	// Use this for initialization
	void Start () {
        var a = new ArrayList();
        a.Add(2);
        a.Add(5123);
//        print(a[1]);
        var b = new question();
        b.addQuestion("hello","b");
        b.addAnswer("hello","b");
        List<answers> c = new List<answers>(); 
        c.Add(new answers("hello", "b"));
        c.Add(new answers("helo", "b"));

        foreach (var i in b.checkAnswer(c))
        {
//            print(i);

        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
