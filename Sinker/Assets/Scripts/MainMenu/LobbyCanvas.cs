using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCanvas : MonoBehaviour
{
    [SerializeField] private RoomLayoutGroup _roomLayoutGroup;
    public RoomLayoutGroup RoomLayoutGroup
    {
        get { return _roomLayoutGroup; }
    }
    public void OnClickJoinRoom(string roomName)
    {
        print("Joining room " + roomName + "...");
        if (PhotonNetwork.JoinRoom(roomName))
        {
            print("Room joined");
        }
        else
        {
            print("Join room failed");
        }
    }
}
