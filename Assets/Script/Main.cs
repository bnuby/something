using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    private GameObject game;
	// Use this for initialization
	void Start () {
//        game.GetComponentInChildren(GameObject);
        game = (GameObject.Find("QuestionList"));

        print("hello");
    }

	// Update is called once per frame
	void Update () {
        print(game.transform.GetChild(0).transform.GetChild(1).transform.Find("Text").GetComponent<Text>().text);

	}
}
