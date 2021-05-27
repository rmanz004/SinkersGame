using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 700f;
    public Rigidbody2D rb;
    public Weapon cannon;
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print(col.gameObject.ToString());
        if (col.gameObject.tag == "Player")
        {
            HealthAndAmmo temp;
            temp = col.gameObject.GetComponent<HealthAndAmmo>();
            temp.decHealth(1);
            cannon.score += 10;
        }
        Destroy(gameObject);
    }

}
