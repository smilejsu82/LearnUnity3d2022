using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float speed = 1.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * this.speed * Time.deltaTime);
        if (this.transform.position.y < -1.0f) {
            Destroy(this.gameObject);
        }
    }

}
