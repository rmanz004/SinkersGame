using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    bool loaded = false;
    public void SpawnPlayer()
    {        
        loaded = true;
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(100,400), Quaternion.identity, 0);
    }
    
    private void OnGUI()
    {
        Rect rec = new Rect(0, 0, 300, 100);
        GUI.Box(rec, Input.mousePosition.x + "/" + Input.mousePosition.y + " ?:" + loaded.ToString()+ "\n" + PlayerPrefab.name);
    }
}
