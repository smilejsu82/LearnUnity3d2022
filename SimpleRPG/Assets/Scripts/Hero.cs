using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour
{
    public enum eAttackType { 
        None, Attack01, Attack02
    }
    
    public GameObject model;
    public float attackDelay = 0.5f;
    public float impactOffset = 0.5f;
    private float hp;
    public float maxHp;
    public float damage;
    public float attackRange;
    public Transform fxPivot;
    

    private Animator anim;
    private Coroutine routine;
    public UnityAction<eAttackType> OnAttackImpact;
    public UnityAction<eAttackType> OnAttackComplete;
    private Slime target;
    private UnityAction OnMoveComplete;

    void Start()
    {
        this.anim = this.model.GetComponent<Animator>();
        this.hp = this.maxHp;
        this.OnMoveComplete = () => {
            this.Attack(this.target);
        };
    }

    public void Attack(Slime target) {
        this.target = target;
        if (this.routine != null) StopCoroutine(this.routine);
        this.routine = StartCoroutine(this.AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true) {
            //->
            if (HasTarget())
            {
                //check attackrange 
                if (this.CanAttack())
                {
                    yield return StartCoroutine(this.Attack01Routine());
                }
                else 
                {
                    //move 
                    this.routine = StartCoroutine(this.MoveToTarget());
                    yield break;
                }
                
            }
            else 
            {
                this.Idle();
                break;
            }

            if (this.HasTarget()) {
                //check attackrange 
                if (this.CanAttack())
                {
                    yield return StartCoroutine(this.Attack02Routine());
                }
                else
                {
                    //move 
                    this.routine = StartCoroutine(this.MoveToTarget());
                    yield break;
                }
            }
            else
            {
                this.Idle();
                break;
            }

        }
    }

    private IEnumerator MoveToTarget() {
        
        this.transform.LookAt(this.target.transform);

        //run play animation 
        this.anim.Play("RunForwardBattle", -1, 0);

        while (true) {

            this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
            
            if (CanAttack()) {

                //play idle animation (optional)

                this.OnMoveComplete();
                yield break;
            }

            yield return null;
        }
    }

    public bool CanAttack() {
        var distance = Vector3.Distance(this.target.transform.position, this.transform.position);
        return this.attackRange >= distance;
    }

    public void Idle() {
        this.anim.Play("Idle_Battle", -1, 0);
    }

    public void SetTarget(Slime target) {
        this.target = target;
    }

    private IEnumerator Attack02Routine() {
        this.anim.Play("Attack02", -1, 0);

        yield return null;
        var length = this.GetClipLength();

        var impactTime = 0.533f - impactOffset;
        length = this.GetClipLength();
        impactTime = 0.399f - impactOffset;
        yield return new WaitForSeconds(impactTime);

        //타겟에게 피해를 입힙니다 
        this.target.Hit(this.damage);

        //이벤트 발생  
        this.OnAttackImpact(eAttackType.Attack02);
        yield return new WaitForSeconds(length - impactTime);

        this.Idle();

        //attack delay 
        yield return new WaitForSeconds(this.attackDelay);

        this.OnAttackComplete(eAttackType.Attack02);
    }
    private IEnumerator Attack01Routine() {
        this.anim.Play("Attack01", -1, 0);

        yield return null;

        var length = this.GetClipLength();

        var impactTime = 0.533f - impactOffset;

        yield return new WaitForSeconds(impactTime);
        //타겟에게 피해를 입힙니다 
        this.target.Hit(this.damage);

        //이벤트 발생
        this.OnAttackImpact(eAttackType.Attack01);

        yield return new WaitForSeconds(length - impactTime);   //attack delay 

        this.Idle();

        this.OnAttackComplete(eAttackType.Attack01);
    }

    private bool HasTarget() {
        return this.target != null;
    }

    private float GetClipLength() {
        AnimatorClipInfo[] clipInfos = this.anim.GetCurrentAnimatorClipInfo(0);
        AnimationClip clip = clipInfos[0].clip;
        return clip.length;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float corners = 11; // How many corners the circle should have
        //float size = 10; // How wide the circle should be
        Vector3 origin = transform.position; // Where the circle will be drawn around
        Vector3 startRotation = transform.right * this.attackRange; // Where the first point of the circle starts
        Vector3 lastPosition = origin + startRotation;
        float angle = 0;
        while (angle <= 360)
        {
            angle += 360 / corners;
            Vector3 nextPosition = origin + (Quaternion.Euler(0, angle, 0) * startRotation);
            Gizmos.DrawLine(lastPosition, nextPosition);
            //Gizmos.DrawSphere(nextPosition, 1);

            lastPosition = nextPosition;
        }
    }
}
