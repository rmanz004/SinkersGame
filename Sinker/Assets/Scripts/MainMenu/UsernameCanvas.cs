using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernameCanvas : MonoBehaviour
{

    public void OnClick()
    {
        print("Player's username is: " + PhotonNetwork.playerName);
        Debug.Log("Player's username is: " + PhotonNetwork.playerName);
    } 
}
