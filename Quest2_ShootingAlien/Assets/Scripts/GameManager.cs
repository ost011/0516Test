using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerGameObject;
    public Text hpText;
    public Text scoreText;
    int score;
    public bool isGameOver;
    //public GameObject gameoverTxt;
    void Start()
    {
        score = 0;
        isGameOver = false; 
    }
    void Update()
    {
        if(!isGameOver)
        {
            hpText.text = "HP :" + (int)playerGameObject.GetComponent<PlayerController>().hp;
            scoreText.text = "Score :" + (int)score;
        }
    }
    public void GetScored(int value)
    {
        score += value;
    }
    public void EndGame()
    {
        isGameOver = true;
        //gameOverText.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //public void BossDead()
    //{
    //    gameoverTxt.SetActive(true);
    //}
}
