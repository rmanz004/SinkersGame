using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : Photon.MonoBehaviour
{
    public float moveSpeed = .4f;
    public Rigidbody2D rb;
    Vector2 movement;
    PhotonView PhotonView;

    private Vector3 targetPosition;
    private bool isMoving = false;

    Quaternion targetRotation;

    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        else if (isMoving)
        {
            Move();
        }
    }

    private void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        isMoving = true;
    }
    private void Move()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, .9f * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        //transform.Translate(transform.forward*moveSpeed*Time.deltaTime, Space.World);
        if (transform.rotation.AlmostEquals(targetRotation, 20f))
        {
            //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    // void Update()
    // {
    //     movement.x = Input.GetAxisRaw("Horizontal");
    //     movement.y = Input.GetAxisRaw("Vertical");
    //     CheckInput();
    // }

    // private void CheckInput()
    // {
    //     if (PhotonView.isMine)
    //     {
    //         rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    //     }
    // }
}
