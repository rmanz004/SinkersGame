using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;

    public void SpawnPlayer(){
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x, this.transform.position.y),Quaternion.identity,0);
    }
}
