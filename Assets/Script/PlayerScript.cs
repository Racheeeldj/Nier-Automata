using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    public float playerFireCoolDown;
    public int hp;
    public int speed;
    private Transform trans;
    private float coolDown;
    private AudioSource fire;
    public Material mat;
    void Start() {
        trans = transform;
        coolDown = 0;
    }

    void Update() {  
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey("up"))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
        if (coolDown > 0)
            coolDown--;
        
        float shoot = Input.GetAxis("Jump");
        if (shoot > 0) {
            if (coolDown <= 0) {
                if (ManagerScript.Instance.isActive()){
                    GameObject bullet = ManagerScript.Instance.getObject();
                    if (bullet != null) {
                        Transform bulletTrans = bullet.transform;
                        bulletTrans.position = trans.position + new Vector3(0, 1, 0);
                        bulletTrans.rotation = Quaternion.AngleAxis(270, Vector3.up);
                        bullet.SetActive(true);
                    }//end if
                }else{
                    Instantiate(ManagerScript.Instance.getPrefab(), trans.position + new Vector3(0, 1, 0),
                        Quaternion.AngleAxis(270, Vector3.up));
                    fire.Play();
                }
                coolDown = playerFireCoolDown;
            }//end if
        }//end if
        
        
        if (hp <= 0)
        {

            Destroy(gameObject);
            SceneManager.LoadScene("Lose_Game");
        }
    }

    IEnumerator space()
    {
        yield return new WaitForSeconds(5);

    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "BossBullet")
        {
            hp--;
            other.gameObject.SetActive(false);
            space();
            other.gameObject.SetActive(true);
            if(hp == 3)
            {
                Renderer rend = GetComponent<Renderer>();
                rend.material = mat;
            }
            Debug.Log("HP: " + hp);
        }
        
    }
}
