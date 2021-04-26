using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public HealthAndAmmo HA;

    // Update is called once per frame
    void Update() //Btw, I recommend not checking for this every frame but firing only when an input is decected.
    {
        if(Input.GetButtonDown("Fire1")){
            if(HA.decAmmo(1) == 0) 
            Shoot();
        }
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
