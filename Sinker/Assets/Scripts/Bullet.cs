using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 700f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            HealthAndAmmo temp;
            temp = col.gameObject.GetComponent<HealthAndAmmo>();
            temp.decHealth(1);
        }
        Destroy(gameObject);
    }

}
