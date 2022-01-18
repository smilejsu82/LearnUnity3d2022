using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject car;
    private GameObject flag;
    private GameObject distance;
    Text txtDistance;
    void Start()
    {
        this.car = GameObject.Find("car");  //게임오브젝트 찾아오기 
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");
        this.txtDistance = this.distance.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        
        if (length >= 0)
        {
            txtDistance.text = string.Format("목표지점까지 {0}m", length.ToString("F2"));
        }
        else 
        {
            txtDistance.text = "게임 오버";
        }
        
    }
}
