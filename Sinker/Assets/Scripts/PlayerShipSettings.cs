using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShipSettings : Photon.MonoBehaviour
{
    private PhotonView photonView;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    void Start()
    {
        string PlayerUserName = photonView.owner.NickName;
        this.transform.Find("Text (TMP)").GetComponent<TextMeshPro>().text = PlayerUserName;
        print("Name set");
    }
}
