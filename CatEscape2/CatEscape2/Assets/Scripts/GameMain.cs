using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
    public static bool isGameOver = false;

    public PlayerController player;
    public UIGame uiGame;
    public UIGameOver uiGameOver;
    public ArrowGenerator arrowGenerator;

    void Start()
    {
        //�ʱ�ȭ 
        this.uiGameOver.btnRestart.onClick.AddListener(() => {
            //������� �ε��� 
            GameMain.isGameOver = false;
            SceneManager.LoadScene("GameScene");
        });

        this.player.OnHit = (fillAmount) => {
            this.uiGame.UpdateHpGauge(fillAmount);
        };

        this.player.OnDie = () => {
            if (!GameMain.isGameOver) {
                GameMain.isGameOver = true;
                Debug.Log("player is dead");

                this.uiGame.GameOver();
            }
        };
    }

}
