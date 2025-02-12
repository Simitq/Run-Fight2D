using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{
    public int playerHp = 3;
    public int playerHpMax = 3;
    public int attakDmg;
    public Animator healthAnimator;

    public TMP_Text coinCountText;
    int coinCount;
    int coinGiveCount = 1;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    private void Awake()
    {
        spawnTraderOpen.SetActive(false);
        attakDmg = 1;
        playerHpMax = 3;
        coinCount = 1000;
        priceItem1 = 30;
        priceItem2 = 30;
        priceItem3 = 200;
        priceItem4 = 30;
        coinCountText.text = coinCount.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyLVL1" || collision.gameObject.tag == "EnemyLVL2")
        {

            Debug.Log("Player");
            playerHp -= 1;
            Debug.Log(playerHp);
            healthAnimator.SetInteger("hp", playerHp);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinCount += coinGiveCount;
            coinCountText.text = coinCount.ToString();
        }

    }
    public TMP_Text priceItem1Text;
    public TMP_Text priceItem2Text;
    public TMP_Text priceItem3Text;
    public TMP_Text priceItem4Text;

    int priceItem1;
    int priceItem2;
    int priceItem3;
    int priceItem4;
    public void BuyItem1()
    {
        if (coinCount >= priceItem1 && priceItem1Text.text != "Куплено")
        {
            coinCount -= priceItem1;
            coinCountText.text = coinCount.ToString();
            health1.SetActive(true);
            playerHp += 1;
            playerHpMax += 1;
            healthAnimator.SetInteger("hp", playerHp);
            priceItem1Text.text = "Куплено";
        }
    }
    public void BuyItem2()
    {
        if (coinCount >= priceItem2 && priceItem2Text.text != "Куплено")
        {
            coinCount -= priceItem2;
            coinCountText.text = coinCount.ToString();
            attakDmg++;
            priceItem2Text.text = "Куплено";


        }
    }

    public GameObject spawnTraderOpen;
    public void BuyItem3()
    {
        if (coinCount >= priceItem3)
        {
            coinCount -= priceItem3;
            coinCountText.text = coinCount.ToString();
            spawnTraderOpen.SetActive(true);
            priceItem3Text.text = "Куплено";
        }
    }
    public void BuyItem4()
    {
        if (coinCount >= priceItem4)
        {
            coinCount -= priceItem4;
            coinCountText.text = coinCount.ToString();
            priceItem4 *= 2;
            priceItem4Text.text = priceItem4.ToString();
        }
    }
}
    

