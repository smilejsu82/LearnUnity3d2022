using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed = 1.0f;
    public float radius = 0.5f;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        //Init보다 나중에 호출됨 
    }

    public void Init(float speed, Vector3 initPos)
    {
        //Start보다 먼저 호출됨 
        this.speed = speed;
        this.transform.position = initPos;
        this.player = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Vector2.down;     //(0, -1)

        //방향 * 속도 * 시간 
        var movement = dir * this.speed * Time.deltaTime;

        this.transform.Translate(movement);

        if (this.transform.position.y <= -4f) {
            Destroy(this.gameObject);   //제거 
        }

        var radiusSum = this.player.radius + this.radius;
        var distance = Vector2.Distance(this.player.transform.position, this.transform.position);

        if (distance < radiusSum) {
            Destroy(this.gameObject);   //제거 
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
