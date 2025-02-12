using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float playerSpeed = 2.5f;
    float jumpForce = 14f;
    Vector2 direct = new Vector3(1, 0, 0);
    public OnGround onGround;
    public bool isJump = false;
    public bool isAttak = false;
    float attakSpeed = 1f;
    bool kdAttakSpeed = false;
    Animator animator;
    public TMP_Text reloud;
    float reloudTime;
    const float constTime = 0.02f;
    public PlayerDmg playerDmg;


    private void Awake()
    {
        spawnPlayer = beginSpawn;
        choseSpwner.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playBut.SetActive(true);
    }

    bool isTrade = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            if (!isTrade)
            {
                transform.position += new Vector3(direct.x, direct.y) * playerSpeed * Time.deltaTime;
            }
            animator.SetBool("isJump", isJump);
            if (Input.GetKeyDown(KeyCode.W) && onGround.onGround)
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.Space) && !kdAttakSpeed)
            {
                StartCoroutine(Attak1());
            }
            if (playerDmg.playerHp <= 0)
            {
                SpawnIfLose();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayGame();
            }
        }
        


    }

    void Jump()
    {
        
        isJump = true;
        onGround.onGround = false;
        
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    IEnumerator Attak1()
    {
        kdAttakSpeed = true;
        isAttak = true;
        animator.SetBool("isAttak", isAttak);
        reloud.text = "Attak";
        yield return new WaitForSeconds(0.5f);
        reloudTime = attakSpeed;
        isAttak = false;
        animator.SetBool("isAttak", isAttak);
        StartCoroutine(ReloudText());
        reloud.color = Color.red;
        yield return new WaitForSeconds(attakSpeed);
        reloud.color = Color.green;
        reloud.text = "Ready";
        kdAttakSpeed = false;
    }

    IEnumerator ReloudText()
    {
        while (reloudTime>constTime) 
        {
            reloudTime -= constTime;
            reloud.text = (Mathf.Round(reloudTime*100) /100f).ToString();
            yield return new WaitForSeconds(constTime);
        }
    }
    bool visitShop = false;
    public GameObject shopPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DownFall")
        {
            SpawnIfLose();
        }
        if (collision.gameObject.tag == "Trader" && !visitShop)
        {
            shopPanel.SetActive(true);
            isTrade = true;
            visitShop = true;
        }

    }

    Vector3 spawnPlayer;
    Vector3 beginSpawn = new Vector3(-2, -2.6f, 0);
    Vector3 trader1Spawn = new Vector3(312f, -1, 0);

    void SpawnIfLose()
    {
        
        playerDmg.playerHp = playerDmg.playerHpMax;
        playerDmg.healthAnimator.SetInteger("hp", playerDmg.playerHpMax);
        transform.position = spawnPlayer;
        playBut.SetActive(true);
        choseSpwner.SetActive(true);
        isPlay = false;
        visitShop = false;
    }
    public GameObject choseSpwner;
    public void ChoseSpawnBegin()
    {
        spawnPlayer = beginSpawn;
        transform.position = beginSpawn;
    }
    public void ChoseSpawnTrader1()
    {
        spawnPlayer = trader1Spawn;
        transform.position = trader1Spawn;
    }

    public GameObject playBut;
    bool isPlay = false;
    public void PlayGame() {
        
        isPlay = true;
        choseSpwner.SetActive(false);
        playBut.SetActive(false);
    }

    public void ExitShop()
    {
        shopPanel.SetActive(false);
        isTrade = false;
    }
    bool shopTime = false;
    







}
