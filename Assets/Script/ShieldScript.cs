using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {
    public int hp = 4;

    public Transform particle;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {

            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
           
	}
    
}
