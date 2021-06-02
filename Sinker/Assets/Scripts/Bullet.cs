using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bullet : MonoBehaviour
{
    public float speed = 700f;
    public Rigidbody2D rb;
    public Weapon cannon;
    PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            HealthAndAmmo temp;
            temp = col.gameObject.GetComponent<HealthAndAmmo>();
            temp.decHealth(1);
            //Update score
            cannon.score += 10;
            string newHeader = cannon.transform.Find("Text (TMP)").GetComponent<TextMeshPro>().text.Split(':')[0] + ": " + cannon.score.ToString();
            cannon.transform.Find("Text (TMP)").GetComponent<TextMeshPro>().text = newHeader;
        }
        if (col.gameObject.tag == "Player")
            Destroy(gameObject);
    }

}
