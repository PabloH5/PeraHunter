using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    // public  player;
    private int Score;
    public Text txtScore;
    public GameObject txtSc;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "" + Score;
        // txtSc.Score.animator.SetBool("isPoint", true);
    }
    public int pScore(int num)
    {
        Score = Score + num;
        return Score;
    }
}
