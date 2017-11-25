using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    private Transform trans;
    private GameObject body;
    private float time;
    private List<string> list;

    void Start() {
        trans = transform;
        body = gameObject;
        time = 0;
        list = new List<string>();
        for (int i = 0; i < 1000; i++)
            list.Add("VALUE: "+i);
        while (list.Count > 0)
            list.RemoveAt(0);
        
    }

    void OnEnable(){
        time = 0;
    }

    void Update() {
        trans.Translate(0, 1, 0);
        time += Time.deltaTime;
        if (time > 3) {
            if (ManagerScript.Instance.isActive()) {
                body.SetActive(false);
            } else {
                Destroy(body);
            }//end else
        }//end if
    }
    
}
