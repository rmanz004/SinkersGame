using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour
{
    PhotonView PhotonView;
    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }
    public void OnClick_LeaveGame()
    {
        print("Bye");
        StartCoroutine(DisconnectAndLoad());
    }

    IEnumerator DisconnectAndLoad()
    {
        PhotonNetwork.LeaveRoom();
        while (PhotonNetwork.inRoom)
            yield return null;
        PhotonNetwork.LoadLevel("MainMenu");
    }
}
