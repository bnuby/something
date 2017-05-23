using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addButton : MonoBehaviour {
    public Transform TargetParent;
    public GameObject GridObject;
    public Button yourButton;
	// Use this for initialization
	void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(OnPress);
	}

    void OnPress(){
        Button btn = yourButton.GetComponent<Button>();
        var a = Instantiate(GridObject);
        a.transform.SetParent(TargetParent);

        var getPos = TargetParent.transform.position;

        btn.transform.position -= new Vector3(0, 55,0) ;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
