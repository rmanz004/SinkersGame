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
    PhotonView photonView;
    bool right = false;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update() //Btw, I recommend not checking for this every frame but firing only when an input is decected.
    {
        if (photonView.isMine)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (HA.decAmmo(1) == 0)
                    Shoot();
            }
        }
    }

    void Shoot()
    {
        photonView.RPC("RPC_ShootBullet", PhotonTargets.All);
    }
    [PunRPC]
    private void RPC_ShootBullet()
    {
        Transform fp = firePointLeft;
        float dist1 = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), firePointLeft.position);
        float dist2 = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), firePointRight.position);
        if (dist1 > dist2)
        {
            fp = firePointRight;
        }
        else
        {
            fp = firePointLeft;
        }
        Instantiate(bulletPrefab, fp.position, fp.rotation);
    }
    private void OnGUI()
    {
        Rect rec = new Rect(0, 0, 300, 100);
        GUI.Box(rec, transform.position.x + "<" + Camera.main.ScreenToWorldPoint(Input.mousePosition).x + "\n" + transform.position.y + "<" + Camera.main.ScreenToWorldPoint(Input.mousePosition).y + "\n" + transform.position.z + "<" + Camera.main.ScreenToWorldPoint(Input.mousePosition).z + "\nRight: " + right);
    }

    private float PointToPlaneDistance(Vector3 pointPosition, Vector3 planePosition, Vector3 planeNormal)
    {
        float sb, sn, sd;

        sn = -Vector3.Dot(planeNormal, (pointPosition - planePosition));
        sd = Vector3.Dot(planeNormal, planeNormal);
        sb = sn / sd;

        Vector3 result = pointPosition + sb * planeNormal;
        return Vector3.Distance(pointPosition, result);
    }
}
