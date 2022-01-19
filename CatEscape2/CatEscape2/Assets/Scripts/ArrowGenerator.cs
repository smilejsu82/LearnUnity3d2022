using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    private float delta;
    public GameObject arrowPrefab;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (!GameMain.isGameOver)
        {
            this.delta += Time.deltaTime;
            if (this.delta > 1.0f)
            {
                this.delta = 0;
                //ȭ��ǥ ���� 
                var arrowGo = Instantiate<GameObject>(this.arrowPrefab);
                var arrowController = arrowGo.GetComponent<ArrowController>();
                var randSpeed = Random.Range(3, 6);
                var randPosX = Random.Range(-8f, 9f);
                arrowController.Init(randSpeed, new Vector3(randPosX, 4, 0));
            }
        }
    }

}
