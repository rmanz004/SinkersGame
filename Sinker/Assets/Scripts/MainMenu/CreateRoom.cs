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
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();
        roomOptions.CustomRoomProperties.Add("playersAlive", 0);
        roomOptions.CustomRoomProperties.Add("timesUp", false);
        roomOptions.CustomRoomProperties.Add("levelIndx", 1);        
        roomOptions.CustomRoomProperties.Add("scoreList", new int[] { 0, 0, 0, 0, 0, 0, 0 });
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
