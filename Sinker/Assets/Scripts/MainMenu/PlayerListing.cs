using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviour
{
    [SerializeField] private Text _playerName;
    public Text PlayerName
    {
        get { return _playerName; }
    }

    public PhotonPlayer PhotonPlayer { get; private set; }

    public void ApplyPhotonPlayer(PhotonPlayer photonPlayer)
    {
        PhotonPlayer = photonPlayer;
        PlayerName.text = photonPlayer.NickName;
    }
}
