using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowN: MonoBehaviour { 
    public Transform mtarget;
    public float mspeed = 1.0f;
    const float EPSILON = 0.1f;
    Vector3 mLookDirection;
    public Transform particle;
    public int hp = 10;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
            mLookDirection = (mtarget.position - transform.position).normalized;

            if ((transform.position - mtarget.position).magnitude > EPSILON)
            {
                transform.Translate(mLookDirection * mspeed * Time.deltaTime);
            } 

               
	}


    private void OnTriggerEnter(Collider other)
    {
        if (hp > 0)
        {
            if (other.gameObject.tag == "Bullet")
            {
                hp--;
            }
            other.gameObject.SetActive(false);
        }
        else
        {
            Instantiate(particle, transform.position, transform.rotation);
            other.gameObject.SetActive(false);

            
            Destroy(gameObject);
        }
       
           
    }
}
