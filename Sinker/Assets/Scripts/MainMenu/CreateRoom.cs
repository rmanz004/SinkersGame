using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreateRoom : MonoBehaviour
{
    [SerializeField] private Text _roomName;
    public Text RoomName { get { return _roomName; } }

    public void OnClick_CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
        {
            print("Create Room '" + RoomName.text + "' request was sent.");
        }
        else
        {
            print("Error creating Room '" + RoomName.text + "'.");
        }
    }

    private void OnCreatedRoom()
    {
        print("Room '" + RoomName.text + "' was created successfully.");
    }
}
