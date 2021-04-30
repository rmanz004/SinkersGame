using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Vector2 lastClickedPosition;
    Vector2 mousePos;
    bool moving;
    public Rigidbody2D rb;
    Vector2 movement;
    public Camera cam;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }
    }

    private void FixedUpdate()
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
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * 90f;
        rb.rotation = angle;
    }
}
