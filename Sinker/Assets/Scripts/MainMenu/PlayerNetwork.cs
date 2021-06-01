using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerNetwork : MonoBehaviour
{
    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
    private PhotonView PhotonView;
    private int playersInGame = 0;
    private int level = 3;
    private void Awake()
    {
        Instance = this;

        PhotonView = GetComponent<PhotonView>();

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        print("On scene");
        if (scene.name == "1Map")
        {
            level = 3;
            if (PhotonNetwork.isMasterClient)
            {
                MasterLoadedGame();
            }
            else
            {
                NonMasterLoadedGame();
            }
        }
        if (scene.name == "2Map")
        {
            level = 2;
            playersInGame = 0;
            print("On scene New Map");
            PhotonNetwork.room.CustomProperties["playersAlive"] = 4;
            PhotonNetwork.room.CustomProperties["timesUp"] = false;
            if (PhotonNetwork.isMasterClient)
            {
                MasterLoadedGame();
            }
            else
            {
                NonMasterLoadedGame();
            }
        }
    }

    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
    }

    private void NonMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(level);
    }

    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        playersInGame++;
        print(playersInGame);
        if (playersInGame == PhotonNetwork.playerList.Length)
        {
            print("All players active");
            PhotonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
            PhotonView.RPC("RPC_CreateTimer", PhotonTargets.All);
        }
    }

    [PunRPC]
    private void RPC_CreatePlayer()
    {
        if (PhotonNetwork.player.ID == 1)
        {
            PhotonNetwork.Instantiate(System.IO.Path.Combine("Prefab", "Ship"), new Vector2(100, 400), Quaternion.identity, 0);
        } else if (PhotonNetwork.player.ID == 2)
        {
            PhotonNetwork.Instantiate(System.IO.Path.Combine("Prefab", "Ship"), new Vector2(800, 400), Quaternion.identity, 0);
        } else if (PhotonNetwork.player.ID == 3)
        {
            PhotonNetwork.Instantiate(System.IO.Path.Combine("Prefab", "Ship"), new Vector2(100, 100), Quaternion.identity, 0);
        } else if (PhotonNetwork.player.ID == 4)
        {
            PhotonNetwork.Instantiate(System.IO.Path.Combine("Prefab", "Ship"), new Vector2(860, 100), Quaternion.identity, 0);
        }
        print("Player was created");
    }

    [PunRPC]
    private void RPC_CreateTimer(){
        PhotonNetwork.Instantiate(System.IO.Path.Combine("Prefab", "TimerUI"), new Vector2(400, 400), Quaternion.identity, 0);
    }
}
