using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public HUDScript HUD;
    public HealthAndAmmo increase;
    public WASDMovement speedMod;
    public PlayerMovement speedMod2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Powerup collected");
            GetPowerUp(collision);
        }
    }

    void GetPowerUp(Collider2D player)
    {
        speedMod =  player.GetComponent<WASDMovement>();
        increase = player.GetComponent<HealthAndAmmo>();
        HUD = player.GetComponent<HUDScript>();
        speedMod2 = player.GetComponent<PlayerMovement>();

        speedMod.moveSpeed *= 1.3f;
        speedMod2.speed *= 1.3f;
        increase.ammo += 1;
        increase.health += 1;

        Destroy(gameObject);

        if (increase.health < 3)
        {
            HUD.Hearts(increase.health);
        }
        else if (increase.health > 3)
        {
            increase.health -= 1;
        }

        if (increase.ammo < 3)
        {
            HUD.Ammo(increase.ammo);
        }
        else if (increase.ammo > 3)
        {
            increase.ammo -= 1;
        }


    }

    




}
