using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{
    private float speed;
    private Vector2 startPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) {
            var endPos = Input.mousePosition;
            var len = endPos.y - startPos.y;
            this.speed = len / 500;
        }

        this.transform.Rotate(0, 0, 10);
        this.transform.Translate(0, speed, 0, Space.World);
    }
}
