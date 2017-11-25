using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour {
    public GameObject bulletPrefab;
    public int poolSize;
    public bool active;
    public bool dynamicGrowth;


    private List<GameObject> bulletPool;
    
    private static ManagerScript _instance;

    public static ManagerScript Instance {
        get {
            if (_instance == null)
                _instance = (ManagerScript)FindObjectOfType(typeof(ManagerScript));
            return _instance;
        }
    }

    void Start() {
        if (isActive()) {
            bulletPool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++) {
                GameObject obj = (GameObject)Instantiate(bulletPrefab);
                obj.SetActive(false);
                bulletPool.Add(obj);
            }//end for
        }//end if
    }

    void Update() {
    }

    public bool isActive() {
        return active;
    }

    public GameObject getPrefab() {
        return bulletPrefab;
    }

    public GameObject getObject() {
        for (int i = 0; i < bulletPool.Count; i++) {
            if (!bulletPool[i].activeInHierarchy) {
                return bulletPool[i];
            }
        }
        if (dynamicGrowth) {
            GameObject obj = (GameObject)Instantiate(bulletPrefab);
            obj.SetActive(false);
            bulletPool.Add(obj);
            poolSize++;
            return obj;
        }//end if
        return null;
    }
    
}
