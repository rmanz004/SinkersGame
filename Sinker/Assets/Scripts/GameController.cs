using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    bool loaded = false;
    int ogPlayersAlive = 0;
    int levelIndx = 1;
    List<string> levels = new List<string> { "1Map", "2Map", "3Map" };
    private void Start()
    {
        ogPlayersAlive = ((int)PhotonNetwork.room.CustomProperties["playersAlive"]);
    }

    private void FixedUpdate()
    {
        if ((int)PhotonNetwork.room.CustomProperties["playersAlive"] <= 0)
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
    private void loadLevel()
    {
        PhotonNetwork.room.CustomProperties["timesUp"] = false;
        PhotonNetwork.room.CustomProperties["playersAlive"] = ogPlayersAlive;
        PhotonNetwork.room.CustomProperties["spawnLocationIndx"] = 0;
        PhotonNetwork.LoadLevel(levels[levelIndx]);
        levelIndx++;
    }
}