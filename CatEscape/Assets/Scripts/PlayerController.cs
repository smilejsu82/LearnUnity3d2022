using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float radius = 1.5f;
    private GameDirector gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        this.gameDirector = GameObject.FindObjectOfType<GameDirector>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameDirector.isGameOver) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            this.MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.MoveRight();
        }
    }

    private void MoveLeft() {
        this.transform.Translate(-3, 0, 0);
        if (this.transform.position.x <= -7.82f)
        {
            var pos = this.transform.position;
            pos.x = -7.82f;
            this.transform.position = pos;
        }
    }

    private void MoveRight() {
        this.transform.Translate(3, 0, 0);
        if (this.transform.position.x >= 8.01f)
        {
            var pos = this.transform.position;
            pos.x = 8.01f;
            this.transform.position = pos;
        }
    }

    public void LButtonDown() {
        this.MoveLeft();
    }

    public void RButtonDown() {
        this.MoveRight();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, this.radius);
    }
}
