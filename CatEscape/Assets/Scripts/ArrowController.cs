using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private PlayerController player;
    public float radius = 1.0f;
    private GameDirector gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindObjectOfType<PlayerController>();
        this.gameDirector = GameObject.FindObjectOfType<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, -0.1f, 0);
        
        if (this.transform.position.y <= -4.02f)
        {
            if (!this.gameDirector.isGameOver) {
                this.gameDirector.IncreaseScore(10);
            }
            Destroy(this.gameObject);
        }

        Vector2 p1 = this.transform.position;   //화살표의 중점 
        Vector2 p2 = this.player.transform.position;    //플레이어의 중점 
        Vector2 dir = p2 - p1;
        float d = dir.magnitude;

        Debug.DrawLine(p1, p2, Color.red);
        
        //float d = Vector2.Distance(p1, p2);
        if (d < this.radius + player.radius)
        {
            GameObject gameDirectorGo = GameObject.Find("GameDirector");
            GameDirector gameDirector = gameDirectorGo.GetComponent<GameDirector>();
            gameDirector.DecreaseHp();

            //충동 했다 
            Debug.Log("충돌했다");
            Destroy(this.gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, this.radius);
    }
}
