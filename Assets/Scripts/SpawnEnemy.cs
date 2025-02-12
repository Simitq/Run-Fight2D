using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy1;
    
    public GameObject playerTrans;
    bool isSpawn = false;
    Vector3 spawn;

    private void Awake()
    {
        playerTrans = GameObject.FindGameObjectWithTag("PlayerIdle");
    }
    private void Start()
    {
        
        spawn = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        Instantiate(enemy1, spawn, Quaternion.identity);
    }
    private void Update()
    {
        if ((playerTrans.transform.position == new Vector3(-2, -2.6f, 0) || (playerTrans.transform.position == new Vector3(4.3f, -3, 0))) && isSpawn)
        {
            Instantiate(enemy1,spawn,Quaternion.identity);
            isSpawn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            isSpawn = true;
        }
    }





}
