using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    Vector2 lastClickedPosition;
    bool moving;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if (moving && (Vector2)transform.position != lastClickedPosition)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPosition, step);
        }
        else
        {
            moving = false;
        }
    }
}
