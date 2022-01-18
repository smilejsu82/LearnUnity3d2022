using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 startPos;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            var endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;
            this.speed = swipeLength / 500.0f;

            this.GetComponent<AudioSource>().Play();
        }

        this.transform.Translate(this.speed, 0, 0); //x������ �̵��Ѵ� 
        this.speed *= 0.96f;    //�����Ѵ� 
    }
}
