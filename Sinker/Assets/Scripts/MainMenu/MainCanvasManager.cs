using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour
{
    public static MainCanvasManager Instance;
    [SerializeField] private LobbyCanvas _lobbyCanvas;
    public LobbyCanvas LobbyCanvas { get { return _lobbyCanvas; } }

    [SerializeField] private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas { get { return _currentRoomCanvas; } }

    [SerializeField] private UsernameCanvas _usernameCanvas;
    public UsernameCanvas UsernameCanvas { get { return _usernameCanvas; } }
    
    /*
    [SerializeField] private LoadingScreenCanvas _loadingScreenCanvas;

    public LoadingScreenCanvas LoadingScreenCanvas { get { return _loadingScreenCanvas; } }
    */


    private void Awake()
    {
        Instance = this;
    }
}
