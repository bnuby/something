using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Specialized;
using UnityEngine.AI;
using System;

public class linkModule : MonoBehaviour, IDragHandler ,IEndDragHandler {

//    Dictionary<string,string> answer = new []{};
    // Use this for initialization
    void Start () {

        this.GetComponentInChildren<Image>().sprite = new Sprite();
        this.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("test");
//        answer.Add("question","hi");
//        print(answer);

    }

    public void OnDrag(PointerEventData eventData)
    {
        //        var size = this.GetComponentInParent<GameObject>()
        Vector3 Pos = LineStartLocation();
        //        if (this.GetComponentInParent<tag>().CompareTag("QuestionList"))
        RaycastHit hit = new RaycastHit();
        Vector3 Pos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Pos2.z = 10;
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
            this.GetComponent<LineRenderer>().SetPosition(1, LineEndLocation(hit) );
            print(hit.transform.GetComponent<Transform>().position.y);
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

        Ray Pos = Camera.main.ScreenPointToRay(Input.mousePosition);
        try{
            Physics.Raycast(Pos, out hit);
            test = hit.transform.tag == "linkModule";
        }catch{
            test = false;
        }
        if (!test)
        {
            this.GetComponent<LineRenderer>().SetPosition(1, LineStartLocation() );
        }

    }


    Vector3 LineStartLocation(){

        if ( this.transform.parent.CompareTag("QuestionList"))
        {
            var DragObjectPosX = this.transform.position.x + this.transform.GetComponent<RectTransform>().rect.width / 2 - 10;
            var DragObjectPosY = this.transform.position.y;
            var DragObjectPosZ = this.transform.position.z ;

            return Camera.main.ScreenToWorldPoint(new Vector3(DragObjectPosX, DragObjectPosY, 10));

        }
        else if (this.transform.parent.CompareTag("AnswerList"))
        {

            var DragObjectPosX = this.transform.position.x - this.transform.GetComponent<RectTransform>().rect.width / 2 + 10;
            var DragObjectPosY = this.transform.position.y ;
            var DragObjectPosZ = this.transform.position.z ;

            return Camera.main.ScreenToWorldPoint(new Vector3(DragObjectPosX, DragObjectPosY, 10));
        }
        return new Vector3(0,0,0);
    }

    Vector3 LineEndLocation(RaycastHit target){

        if ( target.transform.parent.CompareTag("QuestionList"))
        {
            var DragObjectPosX = target.transform.position.x + target.transform.GetComponent<RectTransform>().rect.width / 2 - 10;
            var DragObjectPosY = target.transform.position.y;
            var DragObjectPosZ = target.transform.position.z ;

            return Camera.main.ScreenToWorldPoint(new Vector3(DragObjectPosX, DragObjectPosY, 10));

        }
        else if (target.transform.parent.CompareTag("AnswerList"))
        {

            var DragObjectPosX = target.transform.position.x - target.transform.GetComponent<RectTransform>().rect.width / 2 + 10;
            var DragObjectPosY = target.transform.position.y ;
            var DragObjectPosZ = target.transform.position.z ;
            print("here");
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
