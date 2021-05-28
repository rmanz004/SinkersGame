using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    bool loaded = false;
    int ogPlayersAlive = 0;
    int levelIndx = 0;
    List<string> levels = new List<string>{ "1Map", "2Map", "3Map" };
    private void Start()
    {
        ogPlayersAlive = ((int)PhotonNetwork.room.CustomProperties["playersAlive"]);
    }

    private void FixedUpdate()
    {
        if ((int)PhotonNetwork.room.CustomProperties["playersAlive"] <= 1)
        {
            print("Round over: Kills");
            PhotonNetwork.room.CustomProperties["playersAlive"] = ogPlayersAlive;
            PhotonNetwork.LoadLevel(levels[levelIndx]);
            levelIndx++;
        }
        if ((bool)PhotonNetwork.room.CustomProperties["timesUp"])
        {
            print("Round over: Timer");
            PhotonNetwork.room.CustomProperties["timesUp"] = false;
            PhotonNetwork.room.CustomProperties["playersAlive"] = ogPlayersAlive;
            PhotonNetwork.LoadLevel(levels[levelIndx]);
            levelIndx++;
        }
    }
}