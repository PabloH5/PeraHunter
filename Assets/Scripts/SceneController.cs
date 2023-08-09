using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using PlayerController.cs;

public class SceneController : MonoBehaviour
{
    // public  player;
    private int score;
    public Text txtScore;
    public GameObject minotauro;
    public GameObject spawnEnemys1;


    public PlayerController player;

    public GameObject bloodL;
    public GameObject bloodM;
    public GameObject bloodH;
    void Update()
    {
        txtScore.text = "" + score;

        if (score >= 50)
        {
            minotauro.SetActive(true);
            spawnEnemys1.SetActive(false);
        }

        if (player.healthNow <= player.maxHealth - 5 &&
                player.healthNow >= player.maxHealth / 2 &&
                    player.healthNow >= player.maxHealth / 4)
        {
            bloodL.SetActive(true);
            Invoke(nameof(Blood), 3.5f);
        }
        else
        {
            if (player.healthNow >= player.maxHealth - 5 &&
                    player.healthNow <= player.maxHealth / 2 &&
                        player.healthNow >= player.maxHealth / 4)
            {
                bloodM.SetActive(true);
                Invoke(nameof(Blood), 5.5f);
            }
            else
            {
                if (player.healthNow >= player.maxHealth - 5 &&
                        player.healthNow >= player.maxHealth / 2 &&
                            player.healthNow <= player.maxHealth / 4)
                {
                    bloodH.SetActive(true);
                }
            }
        }
    }
    public void Blood()
    {
        bloodL.SetActive(false);
        bloodM.SetActive(false);
        bloodH.SetActive(false);
    }
    public int pScore(int num)
    {
        score = score + num;
        return score;
    }
    public int currentScore()
    {
        return score;
    }
}
