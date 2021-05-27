using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndAmmo : MonoBehaviour
{
    public int initHealth = 3;
    public int initAmmo = 3;
    public int maxHealth = 3;
    public int maxAmmo = 3;
    public int health;
    public int ammo;

    public int score;

    [SerializeField]
    public HUDScript HUD;
    private PhotonView photonView;
    
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
        ammo = initAmmo;
        HUD.Hearts(health);
        HUD.Ammo(ammo);

        if((HUD != null) && (photonView.isMine))
        {
            HUDScript _uiGo = Instantiate(HUD);
            _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
            HUD = _uiGo;
        }
        else
        {
            Debug.Log("Health and Ammo error");
        }
    }
    /*
    void CalledOnLevelWasLoaded()
    {
        GameObject _uiGo = Instantiate(this.HUD);
        _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReciever);
        return;
    }
    */
    [PunRPC]
    private void RPC_DestroyDeadPlayer()
    {
        Destroy(gameObject);
    }

    public void incHealth(int num)
    {
        if (num < 0)
        {
            return;
        }
        else if (num > (maxHealth - health))
        {
            health = maxHealth;
        }
        else
        {
            health += num;
        }
        HUD.Hearts(health);
    }

    public void decHealth(int num)
    {
        if (num < 0)
        {
            return;
        }
        else if (num >= health)
        {
            health = 0;
            HUD.Hearts(health);
            photonView.RPC("RPC_DestroyDeadPlayer", PhotonTargets.All);
        }
        else
        {
            health -= num;
        }
        HUD.Hearts(health);
    }

    public void incAmmo(int num)
    {
        if (num < 0)
        {
            return;
        }
        else if (num > (maxAmmo - ammo))
        {
            ammo = maxAmmo;
        }
        else
        {
            ammo += num;
        }
        HUD.Ammo(ammo);
    }

    public int decAmmo(int num)
    {
        if (num < 0)
        {
            return 0;
        }
        else if (num > ammo)
        {
            return -1;
        }
        else
        {
            ammo -= num;
            HUD.Ammo(ammo);
            return 0;
        }
    }
}