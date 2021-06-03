using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNetwork : MonoBehaviour
{
    void Start()
    {
        print(PhotonNetwork.connected);
        if (!PhotonNetwork.connected)
        {
            print("Connecting to server...");
            PhotonNetwork.ConnectUsingSettings("0.0.0");
        }
    }

    private void OnConnectedToMaster()
    {
        print("Connected to master");
        PhotonNetwork.automaticallySyncScene = false;
        PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    private void OnJoinedLobby()
    {
        print("Connected to lobby");
        ExitGames.Client.Photon.Hashtable PlayerCustomProps = new ExitGames.Client.Photon.Hashtable();
        PhotonNetwork.player.CustomProperties.Add("Score", 0);
        MainCanvasManager.Instance.UsernameCanvas.transform.SetAsLastSibling();
    }
}
