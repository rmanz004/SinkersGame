using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    bool loaded = false;
    int ogPlayersAlive = 0;
    List<string> levels = new List<string> { "1Map", "2Map", "3Map", "EndGame" };
    private void Start()
    {
        ogPlayersAlive = ((int)PhotonNetwork.room.CustomProperties["playersAlive"]);
    }

    private void Update()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if ((int)PhotonNetwork.room.CustomProperties["playersAlive"] <= 1)
            {
                print("Round over: Kills");
                loadLevel();
            }
            if ((bool)PhotonNetwork.room.CustomProperties["timesUp"])
            {
                print("Round over: Timer");
                loadLevel();
            }
        }
    }
    private void loadLevel()
    {
        PhotonNetwork.room.CustomProperties["timesUp"] = false;
        PhotonNetwork.room.CustomProperties["playersAlive"] = ogPlayersAlive;
        int levelIndx = (int)PhotonNetwork.room.CustomProperties["levelIndx"];
        if(levelIndx >= 4) return;
        PhotonNetwork.LoadLevel(levels[levelIndx]);
        levelIndx++;
        PhotonNetwork.room.CustomProperties["levelIndx"] = levelIndx;
        print("Level Indx: " + levelIndx);
    }
}