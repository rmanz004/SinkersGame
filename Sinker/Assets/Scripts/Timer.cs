using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class TimeCounter : MonoBehaviour
{
	public TMP_Text timetext;
	public float timeval = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeval = 5;
    }

    // Update is called once per frame
    void Update()
    {
    	if(timeval > 0) {
        	timeval -= Time.deltaTime;
        } else {
        	timeval = 0;
        }

        DisplayTime(timeval);

        if (timeval == 0) {
        	Debug.Log("time is zero");
        	SceneManager.LoadScene("MainMenu");
        }
    }

    void DisplayTime(float displaytime) {
    	if(displaytime < 0) {
    		displaytime = 0;
    	}

    	float min = Mathf.FloorToInt(displaytime/60);
    	float sec = Mathf.FloorToInt(displaytime%60);
    	float millisec = displaytime % 1 * 1000;

    	timetext.text = string.Format("{0:00}:{1:00}:{2:000}", min, sec, millisec);
    }
}
