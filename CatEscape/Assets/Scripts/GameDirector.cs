using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject hpGauge;
    public float playTime = 10;
    private float delta;
    public Text txtTime;
    public bool isGameOver;
    public Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
        this.txtScore.text = string.Format("{0}¡°", this.totalScore);
    }

    void Update()
    {
        if (this.isGameOver) return;

        this.delta += Time.deltaTime;
        
        if (this.delta > 1) {

            this.delta = 0;

            this.playTime -= 1;

            Debug.Log("->" + this.playTime);

            this.txtTime.text = string.Format("{0}√  ", (int)this.playTime);
            if (this.playTime <= 0) {
                if (this.isGameOver == false) {
                    this.GameOver();
                }
            }
        }
    }

    private int totalScore;

    public void IncreaseScore(int score) {
        this.totalScore += score;
        this.txtScore.text = string.Format("{0}¡°", this.totalScore);
    }

    public GameObject gameoverGo;
    public void GameOver() {
        this.gameoverGo.SetActive(true);
        this.isGameOver = true;
        Debug.Log("GAMEOVER");
    }

    public void DecreaseHp() {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
