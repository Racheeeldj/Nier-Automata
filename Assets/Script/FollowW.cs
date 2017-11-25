using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowW : MonoBehaviour {
    public int hp = 10;
    public Transform mtarget;
    float mspeed = 3.0f;
    const float EPSILON = 0.1f;
    Vector3 mLookDirection;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(hp > 0)
        {
            mLookDirection = (mtarget.position - transform.position).normalized;

            if ((transform.position - mtarget.position).magnitude > EPSILON)
                transform.Translate(mLookDirection * mspeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            hp--;
        }
    }
}
