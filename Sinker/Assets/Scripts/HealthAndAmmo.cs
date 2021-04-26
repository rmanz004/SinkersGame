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
    int health;
    int ammo;

    public HUDScript HUD;

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
        ammo = initAmmo;
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
        else if (num > health)
        {
            health = 0;
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
        else if(num > ammo)
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
