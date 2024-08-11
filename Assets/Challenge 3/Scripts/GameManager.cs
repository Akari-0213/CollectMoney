using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    private PlayerControllerX playerControllerScript;
    GameObject GameOverUI;
    GameObject TimeUI;
    GameObject ScoreUI;
    private bool Clear = false;

    public float countdown;
    
    // Start is called before the first frame update
    void Start()
    {
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
       this.GameOverUI = GameObject.Find("GameOver");
       this.TimeUI = GameObject.Find("Time");
       this.ScoreUI = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControllerScript.gameOver && !Clear){
           this.GameOverUI.GetComponent<TextMeshProUGUI>().text="Collect Money!";
           UpdateTimeUI();
           this.ScoreUI.GetComponent<TextMeshProUGUI>().text = "Score:" + playerControllerScript.moneyScore;
        }else if(playerControllerScript.gameOver && !Clear){
            this.GameOverUI.GetComponent<TextMeshProUGUI>().text="GameOver";
        }
    }

    void UpdateTimeUI(){
       countdown -= Time.deltaTime;
       this.TimeUI.GetComponent<TextMeshProUGUI>().text="Time:"+ countdown.ToString("F1");
       if(countdown<=0){
        playerControllerScript.gameOver = true;
        this.GameOverUI.GetComponent<TextMeshProUGUI>().text="Clear!";
        this.TimeUI.GetComponent<TextMeshProUGUI>().text="Time:00:00";
        Clear = true;
       }


    }
}
