using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePointRight;
    public Transform firePointLeft;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public HealthAndAmmo HA;

    // Update is called once per frame
    void Update() //Btw, I recommend not checking for this every frame but firing only when an input is decected.
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (HA.decAmmo(1) == 0)
                Shoot();
        }
    }

    void Shoot()
    {
        // Quaternion rotation = (Input.mousePosition.x - 550 < rb.position.x) ? Quaternion.AngleAxis(transform.eulerAngles.z + 180, transform.forward): firePoint.rotation ;
        // int positionAdjust = (Input.mousePosition.x - 550 < rb.position.x) ? -10 : 0;
        // Vector3 posAdj = new Vector3(positionAdjust,0,0);
        // Instantiate(bullerPrefab, firePoint.position + posAdj, rotation);
        Transform fp = firePointLeft;
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x || transform.position.y < Camera.main.ScreenToWorldPoint(Input.mousePosition).y)
        {
            fp = firePointLeft;
        }
        else
        {
            fp = firePointRight;
        }
        Instantiate(bulletPrefab, fp.position, fp.rotation);
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    private void OnGUI()
    {
        Rect rec = new Rect(0, 0, 300, 100);
        GUI.Box(rec, transform.position.x + "/" + Camera.main.ScreenToWorldPoint(Input.mousePosition).x + "\n" + transform.position.y + "/" +Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }
}
