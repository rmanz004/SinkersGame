using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : Photon.MonoBehaviour
{
    public float moveSpeed = .4f;
    public Rigidbody2D rb;
    Vector2 movement;
    PhotonView photonView;

    private Vector3 targetPosition;
    private bool isMoving = false;

    Quaternion targetRotation;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    private void Update()
    {
        if (photonView.isMine)
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
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, .9f * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.rotation.AlmostEquals(targetRotation, 20f))
        {
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

}
