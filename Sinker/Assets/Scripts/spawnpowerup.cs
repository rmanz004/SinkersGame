using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpowerup : MonoBehaviour
{
    private Vector2 screenbounds;
    private float timeval = 0;

    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    	timeval = 7;
    }

    // Update is called once per frame
    void Update()
    {
        // if (transform.position.x < screenbounds.x) {
        // 	  Destroy(this.gameObject);
        // }
        if(timeval > 0) {
            timeval -= Time.deltaTime;
        } else {
            timeval = 0;
        }

        if (timeval == 0) {
            Debug.Log("deleting powerup clone");
            Destroy(this.gameObject);
        }
    }
}
