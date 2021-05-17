using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShipSettings : MonoBehaviour
{

    void Start()
    {
        TextMeshPro tmp = GetComponent<TextMeshPro>();
        tmp.SetText(PhotonNetwork.playerName);        
    }

    
}
