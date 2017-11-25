using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowE : MonoBehaviour {
    public Transform mtarget;
    float mspeed = 7.0f;
    const float EPSILON = 0.1f;
    Vector3 mLookDirection;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mLookDirection = (mtarget.position - transform.position).normalized;

        if ((transform.position - mtarget.position).magnitude > EPSILON)
            transform.Translate(mLookDirection * mspeed * Time.deltaTime);
    }
}
