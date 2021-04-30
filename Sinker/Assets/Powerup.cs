using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
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
        PlayerMovement speedMod =  player.GetComponent<PlayerMovement>();

        speedMod.speed *= 1.3f;

        Destroy(gameObject);
    }
}
