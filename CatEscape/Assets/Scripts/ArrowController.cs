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

        Vector2 p1 = this.transform.position;   //ȭ��ǥ�� ���� 
        Vector2 p2 = this.player.transform.position;    //�÷��̾��� ���� 
        Vector2 dir = p2 - p1;
        float d = dir.magnitude;

        Debug.DrawLine(p1, p2, Color.red);
        
        //float d = Vector2.Distance(p1, p2);
        if (d < this.radius + player.radius)
        {

            this.player.hp -= 1;

            this.gameDirector.UpdateHpGauge(this.player.hp, this.player.maxHp);


            //gameDirector.DecreaseHp();

            //�浿 �ߴ� 
            Debug.Log("�浹�ߴ�");
            Destroy(this.gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, this.radius);
    }
}
