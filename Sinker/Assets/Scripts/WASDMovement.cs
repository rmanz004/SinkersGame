using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : Photon.MonoBehaviour
{
    public float moveSpeed = .4f;
    public static float turnSpeed = .2f;
    public Rigidbody2D rb;
    public Transform PivotPoint;
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
            if (Input.GetMouseButtonDown(0))
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
    private void Rotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, .9f * Time.deltaTime); 
    }
    private void Propel()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        pos.x = Vector3.MoveTowards(pos, targetPosition, moveSpeed * Time.deltaTime).x;
        pos.y = Vector3.MoveTowards(pos, targetPosition, moveSpeed * Time.deltaTime).y;
        transform.position = Vector3.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    private void Move()
    {
        Rotate();
        Propel();
        if (transform.rotation.AlmostEquals(targetRotation, 20f))
        {
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

}
