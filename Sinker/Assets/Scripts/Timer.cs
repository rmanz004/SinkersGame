using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public TMP_Text timetext;
    public float timeval = 0;
    private PhotonView PhotonView;
    private bool spawned = false;
    void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        timeval = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeval > 0)
        {
            timeval -= Time.deltaTime;
        }
        else
        {
            timeval = 0;
        }

        DisplayTime(timeval);

        if (timeval == 0)
        {
            print("Times up!");
            bool timesUp = true;
            PhotonNetwork.room.CustomProperties["timesUp"] = timesUp;
        }

        if (PhotonNetwork.isMasterClient)
            spawnPowerup();
    }

    private void spawnPowerup()
    {
        if ((int)timeval % 5 == 0 && !spawned)
        {
            spawned = true;
            float x = Random.Range(50f, 900f);
            float y = Random.Range(20, 400);
            PhotonView.RPC("RPC_SpawnPowerup", PhotonTargets.All, x, y);
        }
        else if ((int)timeval % 5 != 0)
        {
            spawned = false;
        }
    }


    void DisplayTime(float displaytime)
    {
        if (displaytime < 0)
        {
            displaytime = 0;
        }

        float min = Mathf.FloorToInt(displaytime / 60);
        float sec = Mathf.FloorToInt(displaytime % 60);
        float millisec = displaytime % 1 * 1000;

        timetext.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    [PunRPC]
    private void RPC_SpawnPowerup(float x, float y)
    {
        PhotonNetwork.Instantiate(System.IO.Path.Combine("Prefab", "Powerup"), new Vector2(x, y), Quaternion.identity, 0);
        print("Spawn powerup");
    }
}
