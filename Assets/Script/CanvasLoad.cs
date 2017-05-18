using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLoad : MonoBehaviour {
    public GameObject QuestionTarget;
    public GameObject AnswerTarget;
    public Transform QuestionParent;
    public Transform AnswerParent;

    public int Count;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < Count; i++)
        {
            var a = Instantiate(QuestionTarget);
            a.transform.SetParent(QuestionParent);
        }

        for (int i = 0; i < Count; i++)
        {
            var a = Instantiate(AnswerTarget);
            a.transform.SetParent(AnswerParent);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
