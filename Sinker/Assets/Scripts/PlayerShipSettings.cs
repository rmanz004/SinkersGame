using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShipSettings : MonoBehaviour
{
    private PhotonView photonView;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    void Start()
    {
        //if (photonView.isMine)
        {
            TextMeshPro tmp = GetComponent<TextMeshPro>();
            tmp.SetText(PhotonNetwork.playerName);
        }
    }


}
