using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System;
using LitJson;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;

public class linkModule : MonoBehaviour, IDragHandler ,IEndDragHandler {

    private bool isConnected = false;
    private answers answer;

  void Start () {
        boxColliderUpdate();
        this.GetComponentInChildren<Image>().sprite = new Sprite();
        this.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("test");
//        var Text = this.GetComponentInParent<CanvasLoad>().text;
//        JsonReader Json = new JsonReader(Text);
//        JsonData data = JsonMapper.ToObject(Text);

//        this.GetComponentInChildren<InputField>().GetComponentInChildren<Text>().text = (string)data["questions"][0]["question"][0]["type"];


    }

    void FixedUpdate(){
        boxColliderUpdate();

    }

    void boxColliderUpdate(){
        var rect = this.transform.GetComponent<RectTransform>().rect;
        this.GetComponent<BoxCollider>().size = new Vector3( rect.width, rect.height, 2);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 Pos = LineStartLocation();
        Pos.z = 20;
        RaycastHit hit = new RaycastHit();
        Vector3 Pos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Pos2.z = 20;
        bool test = false;
        Physics.Raycast(Pos, Pos);
        this.GetComponent<LineRenderer>().SetPosition(0, Pos);

        try
        {
            test = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        }catch{
            Debug.Log("error");

        }

        if ( test && hit.transform.tag == "linkModule" ) {
            var getEndPos = LineEndLocation(hit);
            getEndPos.z = 20;
            this.GetComponent<LineRenderer>().SetPosition(1,  getEndPos);
        }
        else
        {

            Vector3 pos=Camera.main.ScreenToWorldPoint (Input.mousePosition);
            pos.z = 0;
            this.GetComponent<LineRenderer>().SetPosition(1, Pos2 );

        }
            
       
   

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool test = false;
        RaycastHit hit = new RaycastHit();

        if (this.isConnected)
        {
            this.GetComponentInParent<CanvasLoad>().linkCount -= 1;
            this.GetComponentInParent<CanvasLoad>().answerList.Remove(this.transform.GetSiblingIndex());
            this.isConnected = false;
        }
        answer = new answers();

//        this.GetComponentInParenΩt<CanvasLoad>().answerList.RemoveAt(this.transform.GetSiblingIndex());

        Ray Pos = Camera.main.ScreenPointToRay(Input.mousePosition);
        try{
            Physics.Raycast(Pos, out hit);

            var questionText = this.GetComponentInChildren<Text>().text;
            var answerText = hit.transform.GetComponentInChildren<Text>().text;

            test = hit.transform.tag == "linkModule";
            this.isConnected = true;
            hit.transform.GetComponent<linkModule>().isConnected = true;
            this.GetComponentInParent<CanvasLoad>().linkCount += 1;
            answer = new answers(questionText,answerText);
            this.GetComponentInParent<CanvasLoad>().answerList.Add(this.transform.GetSiblingIndex(), answer);

        }catch{
            test = false;
            this.GetComponent<LineRenderer>().SetPosition(1, LineStartLocation() );

        }

    }


    Vector3 LineStartLocation(){

        if ( this.transform.parent.CompareTag("QuestionList"))
        {
            var DragObjectPosX = this.transform.position.x + this.transform.GetComponent<RectTransform>().rect.width / 2 - 10;
            var DragObjectPosY = this.transform.position.y;

            return Camera.main.ScreenToWorldPoint(new Vector3(DragObjectPosX, DragObjectPosY, 10));

        }
        else if (this.transform.parent.CompareTag("AnswerList"))
        {

            var DragObjectPosX = this.transform.position.x - this.transform.GetComponent<RectTransform>().rect.width / 2 + 10;
            var DragObjectPosY = this.transform.position.y ;

            return Camera.main.ScreenToWorldPoint(new Vector3(DragObjectPosX, DragObjectPosY, 10));
        }
        return new Vector3(0,0,0);
    }

    Vector3 LineEndLocation(RaycastHit target){

        if ( target.transform.parent.CompareTag("QuestionList"))
        {
            var DragObjectPosX = target.transform.position.x + target.transform.GetComponent<RectTransform>().rect.width / 2 - 10;
            var DragObjectPosY = target.transform.position.y;

            return Camera.main.ScreenToWorldPoint(new Vector3(DragObjectPosX, DragObjectPosY, 10));

        }
        else if (target.transform.parent.CompareTag("AnswerList"))
        {

            var DragObjectPosX = target.transform.position.x - target.transform.GetComponent<RectTransform>().rect.width / 2 + 10;
            var DragObjectPosY = target.transform.position.y ;
            return Camera.main.ScreenToWorldPoint(new Vector3(DragObjectPosX, DragObjectPosY, 10));
        }
        return new Vector3(0,0,0);
    }



    // Update is called once per frame
    void Update () {



        //        print(Camera.main.ViewportPointToRay(Input.mousePosition));
        //        print(Camera.main.ViewportPointToRay(this.transform.position));
        //        if (this.transform.position.Equals(Input.mousePosition)
        //             && Input.GetMouseButtonDown(0))
        //        {
        //            print("hello");
        //        }
    }
}
