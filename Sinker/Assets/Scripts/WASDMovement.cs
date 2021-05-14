using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : Photon.MonoBehaviour
{
    public float moveSpeed = 10;
    public Rigidbody2D rb;
    Vector2 movement;
    PhotonView PhotonView;

    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        CheckInput();
    }

    private void CheckInput()
    {
        if (PhotonView.isMine)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        }
    }
}
