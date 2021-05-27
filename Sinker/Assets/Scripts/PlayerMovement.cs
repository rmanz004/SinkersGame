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
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
