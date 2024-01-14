using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // public  player;
    private int score;
    public Text txtScore;
    public GameObject minotauro;
    public GameObject spawnEnemys1;
    public GameObject ganaste;
    public GameObject paila;
    public GameObject boton;

    public PlayerController player;

    public GameObject bloodL;
    public GameObject bloodH;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        txtScore.text = "Score: " + score;
        if (score >= 50)
        {
            minotauro.SetActive(true);
            audioSource.Pause();
            spawnEnemys1.SetActive(false);
        }
        if (score >= 113)
        {
            audioSource.Play();
            ganaste.SetActive(true);
            player.gameObject.SetActive(false);
        }

        BloodActivate();

        if (player.healthNow <= 0)
        {
            paila.SetActive(true);
            audioSource.Pause();
            spawnEnemys1.SetActive(false);
        }

    }
    private void BloodActivate()
    {
        if (player.healthNow >= (player.maxHealth / 2) + 1)
        {
            bloodL.SetActive(false);
            bloodH.SetActive(false);
        }
        if (player.healthNow <= player.maxHealth / 2 && player.healthNow >= player.maxHealth / 4)
        {
            bloodL.SetActive(true);
            bloodH.SetActive(false);
        }
        else
        {
            bloodL.SetActive(false);
            if (player.healthNow <= player.maxHealth / 4)
            {
                bloodH.SetActive(true);
            }
        }
    }
    public void Blood()
    {
        bloodL.SetActive(false);
        bloodH.SetActive(false);
    }
    public int PScore(int num)
    {
        score += num;
        return score;
    }
    public int CurrentScore()
    {
        return score;
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}