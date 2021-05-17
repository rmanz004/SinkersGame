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
    }
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