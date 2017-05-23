using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    private Canvas Target;
    private Vector3 positionCamera;


	// Use this for initialization
	void Start () {
        

	}

    void FixedUpdate(){
        try {
            Target = Canvas.FindObjectOfType<Canvas>();
            StartCoroutine("CameraCoroutine");
        } catch {
            //
        }

    }
	
	// Update is called once per frame
	void Update () {
       

	}

    void CameraCoroutine(){
        if (Target.transform.position != this.transform.position)
        {
            this.transform.position = Target.transform.position;
            this.transform.position -= new Vector3(0, 0, 10);
            this.transform.GetComponent<Camera>().orthographicSize = Target.transform.position.y;
        }
    }
}
