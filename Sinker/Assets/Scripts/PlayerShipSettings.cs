using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShipSettings : Photon.MonoBehaviour
{
    private void Start()
    {
        this.transform.Find("Text (TMP)").GetComponent<TextMeshPro>().text = photonView.owner.NickName;
        print("Name set");
    }
}
