using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploypowerup : MonoBehaviour
{
	public GameObject powerupPrefab;
	public float respawntime = 2.0f;
    private Vector2 screenbounds;

    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    	StartCoroutine(spawnwave());
    }

    private void spawningpowerup() {
    	GameObject a = Instantiate(powerupPrefab) as GameObject;
    	a.transform.position = new Vector2(Random.Range(-screenbounds.x, screenbounds.x), Random.Range(-screenbounds.y, screenbounds.y));
    }

    IEnumerator spawnwave() {
    	while (true) {
    		yield return new WaitForSeconds (respawntime);
    		spawningpowerup();
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
