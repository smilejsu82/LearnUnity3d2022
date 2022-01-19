using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public Transform leftBoundaryPoint;
    public Transform rightBoundaryPoint;
    public float radius = 1f;
    public System.Action<float> OnHit;
    public System.Action OnDie;
    public float maxHp;
    [HideInInspector] 
    public float hp;

    public void Init(float maxHp, Transform leftBoundary, Transform rightBoundary, Vector3 initPos) {
        this.maxHp = maxHp;
        this.hp = this.maxHp;
        this.leftBoundaryPoint = leftBoundary;
        this.rightBoundaryPoint = rightBoundary;
        this.transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMain.isGameOver) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector2.left * this.speed);
            CheckBoundary();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            this.transform.Translate(Vector2.right * this.speed);
            CheckBoundary();
        }
    }

    private void CheckBoundary() {
        var pos = this.transform.position;
        pos.x = Mathf.Clamp(this.transform.position.x, this.leftBoundaryPoint.position.x, this.rightBoundaryPoint.position.x);
        this.transform.position = pos;
    }

    public void Hit(int damage) 
    {
        //체력 감소 
        this.hp -= damage;
        if (hp <= 0)
            this.hp = 0;

        this.OnHit(this.GetPercentageByHp());

        if (hp <= 0)
            this.OnDie();
    }

    private float GetPercentageByHp()
    {
        return this.hp / this.maxHp;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
