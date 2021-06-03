using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public Transform firePointRight;
    public Transform firePointLeft;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public HealthAndAmmo HA;
    PhotonView photonView;
    int hasAmmo = 1;

    public int score = 0;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        //score = (int)PhotonNetwork.player.CustomProperties["Score"];
    }
    // Update is called once per frame
    void Update() //Btw, I recommend not checking for this every frame but firing only when an input is decected.
    {
        if (photonView.isMine)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                HealthAndAmmo temp;
                temp = this.gameObject.GetComponent<HealthAndAmmo>();
                hasAmmo = temp.decAmmo(1);
                if (hasAmmo == 0)
                    Shoot();
            }
        }
    }

    void Shoot()
    {
        float dist1 = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), firePointLeft.position);
        float dist2 = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), firePointRight.position);
        photonView.RPC("RPC_ShootBullet", PhotonTargets.All, dist1, dist2);
    }
    [PunRPC]
    private void RPC_ShootBullet(float d1, float d2)
    {
        Transform fp = firePointLeft;
        if (d1 > d2)
        {
            fp = firePointRight;
        }
        else
        {
            fp = firePointLeft;
        }
        GameObject instance = Instantiate(bulletPrefab, fp.position, fp.rotation);
        Bullet bullet = instance.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.cannon = this;
        }
    }
    [PunRPC]
    private void RPC_UpdateScore(int score)
    {
        print("UpdateScore");
        string newHeader = this.transform.Find("Text (TMP)").GetComponent<TextMeshPro>().text.Split(':')[0] + ": " + score.ToString();
        this.transform.Find("Text (TMP)").GetComponent<TextMeshPro>().text = newHeader;
    }
    // private void OnGUI()
    // {
    //     if (photonView.isMine)
    //     {
    //         Rect rec = new Rect(0, 0, 300, 100);
    //         GUI.Box(rec, score.ToString());
    //     }
    // }
}
