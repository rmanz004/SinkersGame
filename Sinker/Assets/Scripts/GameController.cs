using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    bool loaded = false;
    int ogPlayersAlive = 0;

    string namie = "BigTest";

    private void Start()
    {
        ogPlayersAlive = ((int)PhotonNetwork.room.CustomProperties["playersAlive"]);
    }

    private void FixedUpdate()
    {
        if ((int)PhotonNetwork.room.CustomProperties["playersAlive"] <= 1)
        {
            print("Round over");
            PhotonNetwork.room.CustomProperties["playersAlive"] = ogPlayersAlive;
            PhotonNetwork.LoadLevel(2);
        }
    }
}