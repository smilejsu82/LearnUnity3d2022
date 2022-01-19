using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector2.left * this.speed);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            this.transform.Translate(Vector2.right * this.speed);
        }
    }
}
