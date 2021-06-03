using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class PlayerNetwork : MonoBehaviour
{
    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
    private PhotonView PhotonView;
    private int playersInGame = 0;
    private int level = 3;

    int spawnIndex = 0;
    private List<Vector2> spawnPoints = new List<Vector2> { new Vector2(50, 400), new Vector2(900, 20), new Vector2(900, 400), new Vector2(50, 20), new Vector2(450, 20), new Vector2(450, 400), new Vector2(50, 200), new Vector2(900, 200) };
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
                MasterLoadedGame(level);
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
                MasterLoadedGame(level);
            }
            else
            {
                NonMasterLoadedGame();
            }
        }
    }

    private void MasterLoadedGame(int level)
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others, level);
    }

    private void NonMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameOthers(int lvl)
    {
        PhotonNetwork.LoadLevel(lvl);
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
        //PhotonNetwork.player.ID == 1
        int randomValue = Random.Range(0, 8);
        PhotonNetwork.Instantiate(System.IO.Path.Combine("Prefab", "Ship"), spawnPoints[randomValue], Quaternion.identity, 0);
        print("Player was created");
    }

    [PunRPC]
    private void RPC_CreateTimer()
    {
        PhotonNetwork.Instantiate(System.IO.Path.Combine("Prefab", "TimerUI"), new Vector2(50, 600), Quaternion.identity, 0);
    }
}
