using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    
    float span = 1.0f;
    float delta = 0;    //�ð��� ���� 

    void Start()
    {
        
    }

    void Update()
    {
        this.delta += Time.deltaTime;   //�������Ӹ��� ��� �ð��� ����
        
        if (this.delta >= this.span) {  //1.0���� ũ�� 
            this.delta = 0;

            GameObject go = Instantiate<GameObject>(this.arrowPrefab);  //�������� �ν��Ͻ�ȭ 

            int px = Random.Range(-6, 7);   //-6 ~ (7-1)
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
