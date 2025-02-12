using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    Vector3 playerTrans;

    private void Awake()
    {
        transform.position = player.position;

    }
    private void Update()

    {
        playerTrans = new Vector3(player.position.x, player.position.y + 0.75f, player.position.z - 10);
        transform.position = Vector3.Lerp(transform.position, playerTrans, 5f * Time.deltaTime);
    }

}
