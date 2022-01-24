using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2d;
    private Animator animator;
    public float jumpForce = 680f;
    public float maxWalkSpeed = 2.0f;
    public float walkSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2d = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    public Text velocityText;

    // Update is called once per frame
    void Update()
    {
        this.velocityText.text = this.rigid2d.velocity.ToString();

        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2d.velocity.y == 0) {
            Debug.LogFormat ("jump : {0}", this.jumpForce);
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2d.AddForce(Vector2.up * this.jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2d.velocity.x);

        if (speedx < this.maxWalkSpeed) {
            this.rigid2d.AddForce(this.transform.right * key * this.walkSpeed);
        }

        if (key != 0) {
            this.transform.localScale = new Vector3(key, 1, 1);
        }

        //바닥에 있으면 
        if (this.rigid2d.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else 
        {
            this.animator.speed = 1.0f;
        }
        

        if (this.transform.position.y <= -5.37f) {
            SceneManager.LoadScene("GameScene");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("끝");
        SceneManager.LoadScene("ClearScene");
    }

}
