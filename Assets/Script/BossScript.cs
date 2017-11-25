using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour {
    public float bossFireCoolDown;
    public int hp = 20;
    private Transform trans;
    private float coolDown;

    void Start() {
        trans = transform;
        coolDown = 0;
    }

    void Update() {
        int shoot = 1;
        if (shoot > 0)
        {
            if (coolDown <= 0)
            {
                if (ManagerScript.Instance.isActive())
                {
                    GameObject bullet = ManagerScript.Instance.getObject();
                    if (bullet != null)
                    {
                        Transform bulletTrans = bullet.transform;
                        bulletTrans.position = trans.position + new Vector3(0, 1, 0);
                        bulletTrans.rotation = Quaternion.AngleAxis(270, Vector3.up);
                        bullet.SetActive(true);
                    }//end if
                }
                else
                {
                    Instantiate(ManagerScript.Instance.getPrefab(), trans.position + new Vector3(0, 1, 0),
                        Quaternion.AngleAxis(270, Vector3.up));
                    
                }
                coolDown = bossFireCoolDown;
            }//end if
        }//end if
    }

    private void OnTriggerEnter(Collider other)
    {
        if(hp > 0)
        {
            if (other.gameObject.tag == "Bullet")
            {
                hp--;
            }
            other.gameObject.SetActive(false);
        }
        else if(hp <= 0)
        {
            Debug.Log("HP: " + hp);
            other.gameObject.SetActive(false);
            Destroy(gameObject);
           // SceneManager.LoadScene("Win_Game");
        }
        
    }
}
