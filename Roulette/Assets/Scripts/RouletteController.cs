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
    float rotSpeed = 0; //ȸ���ӵ� 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {  //���� ���콺 Ŭ�� �ϸ� 
            rotSpeed = this.initRotSpeed * (int)dir;
        }

        //�귿�� ȸ���Ѵ� (�������Ӹ���)
        this.transform.Rotate(0, 0, this.rotSpeed);

        //�귿�� ���� 
        this.rotSpeed *= this.atten;
    }
}
