using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreateUsername : MonoBehaviour
{
    [SerializeField] private Text _username;
    public Text Username { get { return _username; } }


    public void OnClick_CreateUsername()
    {
        PhotonNetwork.playerName = Username.text;
        Debug.Log("Player's username is: " + PhotonNetwork.playerName);
        MainCanvasManager.Instance.LobbyCanvas.transform.SetAsLastSibling();
    }

    
}
