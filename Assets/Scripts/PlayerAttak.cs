using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttak : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject coinPrefab;
    public PlayerDmg playerDmg;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyLVL1" && playerController.isAttak)
        {
            Instantiate(coinPrefab, new Vector3
                (
                collision.gameObject.transform.position.x,
                collision.gameObject.transform.position.y,
                collision.gameObject.transform.position.z
                ), Quaternion.identity);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "EnemyLVL2" && playerController.isAttak && playerDmg.attakDmg >= 2)
        {
            Instantiate(coinPrefab, new Vector3
                (
                collision.gameObject.transform.position.x,
                collision.gameObject.transform.position.y,
                collision.gameObject.transform.position.z
                ), Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
