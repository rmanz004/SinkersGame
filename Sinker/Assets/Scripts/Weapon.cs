using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullerPrefab;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        Quaternion rotation = (Input.mousePosition.x - 550 < rb.position.x) ? Quaternion.AngleAxis(transform.eulerAngles.z + 180, transform.forward): firePoint.rotation ;
        int positionAdjust = (Input.mousePosition.x - 550 < rb.position.x) ? -10 : 0;
        Vector3 posAdj = new Vector3(positionAdjust,0,0);
        Instantiate(bullerPrefab, firePoint.position + posAdj, rotation);
        //Instantiate(bullerPrefab, firePoint.position, firePoint.rotation);
    }
}
