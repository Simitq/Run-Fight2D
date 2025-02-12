using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(MoveRight());
    }

    private void Update()
    {
        if (move)
        {
            transform.position += new Vector3(1, 0) * 1.5f * Time.deltaTime;
            
        }
        if (!move)
        {
            transform.position += new Vector3(-1, 0) * 1.5f * Time.deltaTime;
            
        }
    }
    
    bool move = true;

    IEnumerator MoveRight()
    {
        while (true)
        {
            if (move)
            {
                
                yield return new WaitForSeconds(1.5f);
                move = false;
                spriteRenderer.flipX = true;
            }
            if (!move)
            {
               
                yield return new WaitForSeconds(1.5f);
                move = true;
                spriteRenderer.flipX = false;
            }
        }

    }

    



}
