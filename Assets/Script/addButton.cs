using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addButton : MonoBehaviour {
    public Transform TargetCanvas;
    public Image Object;
    public Button yourButton;
	// Use this for initialization
	void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(OnPress);
	}

    void OnPress(){
        Button btn = yourButton.GetComponent<Button>();
        var a = Instantiate(Object);
        a.transform.SetParent(TargetCanvas);

        var getPos = TargetCanvas.transform.position;

        btn.transform.position -= new Vector3(0, 100,0) ;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
