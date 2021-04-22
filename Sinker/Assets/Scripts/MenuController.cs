using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject LobbyPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

     [SerializeField] private GameObject StartButton;

    private void Awake(){
        PhotonNetwork.ConnectUsingSettings(VersionName);        
    }

    private void Start(){
        UsernameMenu.SetActive(true);
    }

    private void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUserNameInput(){
        if(UsernameInput.text.Trim().Length >= 3){
            StartButton.SetActive(true);
        }
        else{
            StartButton.SetActive(false);
        }
    }

    public void SetUserName(){
        UsernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }


}
