using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class CanvasLoad : MonoBehaviour {
    
//    public GameObject AnswerTarget;
//    public int Count;

    public GameObject Target;
    public Transform QuestionParent;
    public Transform AnswerParent;
    public string text = "";
    public int linkCount = 0;
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

        if (linkCount == quiz.optionsA.Count)
        {
            Vector3 vector = new Vector3(this.transform.position.x, this.transform.position.y, 10);
//            var buttonPos = this.transform.FindChild("Button").transform.GetComponent<RectTransform>().position;
//            this.transform.FindChild("Button").transform.GetComponent<RectTransform>().position = Vector3.Lerp(buttonPos, vector, Time.deltaTime * 5); 
            this.transform.FindChild("Button").transform.DOMoveY(this.transform.position.y , 2 , false);

        }
        else
        {
//            this.transform.FindChild("Button").transform.GetComponent<RectTransform>().position = new Vector3(this.transform.position.x , -50 , 0); 
        }
	}

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
