using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public enum eDir { 
        LEFT = 1, RIGHT = -1
    }

    public eDir dir;
    public float atten = 0.96f;
    public float initRotSpeed = 10;
    float rotSpeed = 0; //회전속도 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {  //왼쪽 마우스 클릭 하면 
            rotSpeed = this.initRotSpeed * (int)dir;
        }

        //룰렛을 회전한다 (매프레임마다)
        this.transform.Rotate(0, 0, this.rotSpeed);

        //룰렛을 감속 
        this.rotSpeed *= this.atten;
    }
}
