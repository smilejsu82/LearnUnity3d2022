using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public Image hpGauge;
    public GameObject gameOverGo;
    void Start()
    {
        this.gameOverGo.SetActive(false);
    }

    public void UpdateHpGauge(float fillAmount)    //0 ~ 1 
    {
        hpGauge.fillAmount = fillAmount;
    }

    public void GameOver() {
        this.gameOverGo.SetActive(true);
    }
}
