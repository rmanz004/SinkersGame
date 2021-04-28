using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;

    //Player variables
    public GameObject PlayerCamera;
    public Text PlayerNameText;

    //Movement variables
    public float MoveSpeed = 5f;
    Vector2 movement;
    Vector2 mousePos;
    Vector2 lastClickedPosition;
    public Camera cam;
    bool moving;

    //Weapon variables
    [SerializeField] private Transform FirePoint;
    public GameObject bulletPrefab;
    public Rigidbody2D rb;

    private void Awake(){
        if(photonView.isMine){
            PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.playerName;
        }
        else{
            PlayerNameText.text = photonView.owner.name;
            PlayerNameText.color = Color.cyan;
        }
    }

    private void Update(){
        if(photonView.isMine)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                lastClickedPosition = cam.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
                //CheckInput();
            }
            if(Input.GetButtonDown("Fire1")){
               Shoot();
            }
        }
    }
    private void FixedUpdate()
    {
        if (moving && (Vector2)transform.position != lastClickedPosition)
        {
            float step = MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPosition, step);
        }
        else
        {
            moving = false;
        }
    }

    private void CheckInput(){
        if (moving && (Vector2)transform.position != lastClickedPosition)
        {
            float step = MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPosition, step);
        }
        else
        {
            moving = false;
        }
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.deltaTime);
    }
    void Shoot()
    {        
        Quaternion rotation = (Input.mousePosition.x - 550 < rb.position.x) ? Quaternion.AngleAxis(transform.eulerAngles.z + 180, transform.forward): FirePoint.rotation ;
        int positionAdjust = (Input.mousePosition.x - 550 < rb.position.x) ? -10 : 0;
        Vector3 posAdj = new Vector3(positionAdjust,0,0);
        Instantiate(bulletPrefab, FirePoint.position + posAdj, rotation);
    }

    private void OnGUI(){
        Rect rec = new Rect(0,0,300,100);
        int positionAdjust = (Input.mousePosition.x - 550 < rb.position.x) ? +10 : 0;

Vector3 posAdj = new Vector3(positionAdjust,0,0);
         GUI.Box(rec,Input.mousePosition.x - 550 + "<" + rb.position.x + "\n" + positionAdjust + "\n"+posAdj + "-"+ FirePoint.position+ "\n" +(posAdj +  FirePoint.position));
    }
}
