using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Photon.MonoBehaviour
{
    public float speed = 5f;
    Vector2 lastClickedPosition;
    Vector2 mousePos;
    bool moving;
    public Rigidbody2D rb;
    Vector2 movement;
    PhotonView PhotonView;

    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (photonView.isMine)
        {
            if (moving && (Vector2)transform.position != lastClickedPosition)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPosition, step);
            }
            else
            {
                moving = false;
            }

            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
    }
}
