using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2d;
    public float jumpForce = 680f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.rigid2d.AddForce(Vector2.up * this.jumpForce);
        }
    }
}
