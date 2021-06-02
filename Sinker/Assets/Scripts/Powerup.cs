using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public HUDScript HUD;
    public HealthAndAmmo increase;
    public WASDMovement speedMod;
    public WASDMovement speedMod2;

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
        //speedMod =  player.GetComponent<WASDMovement>();
        increase = player.GetComponent<HealthAndAmmo>();
        HUD = player.GetComponent<HUDScript>();
        //speedMod2 = player.GetComponent<WASDMovement>();

        //speedMod.moveSpeed *= 1.3f;
        //speedMod2.moveSpeed *= 1.3f;
        increase.incHealth(1);
        increase.incAmmo(3);
    

        Destroy(gameObject);        
    }

    




}
