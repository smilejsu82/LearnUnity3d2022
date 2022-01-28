using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public GameObject mon;
    public Button btn;
    public ParticleSystem fxExplotion;
    public UnityAction moveCompleteAction;
    private Animator monAnim;
    public Transform fxBoomTrans;
    // Start is called before the first frame update
    void Start()
    {
        this.monAnim = this.mon.GetComponent<Animator>();

        this.moveCompleteAction = () => {
            Destroy(this.mon);
            StartCoroutine(this.BoomScaleRoutine());
            this.fxExplotion.gameObject.SetActive(true);
            this.fxExplotion.Play();
        };

        btn.onClick.AddListener(() => {
            StartCoroutine(this.MoveRoutine());
        });
    }

    public Vector3 maxScale = new Vector3(5, 5, 5);
    public float duration = 0.3f;
    IEnumerator BoomScaleRoutine() {
        this.fxBoomTrans.gameObject.SetActive(true);
        var t = 0f;
        while (true) {
            t += Time.deltaTime / duration;
            var a = Vector3.Lerp(this.fxBoomTrans.transform.localScale,this.maxScale, Mathf.SmoothStep(0.0f, 1.0f, t));
            this.fxBoomTrans.transform.localScale = a;
            if (a == maxScale) {
                break;
            }
            yield return null;
        }
        this.fxBoomTrans.gameObject.SetActive(false);
    }

    IEnumerator MoveRoutine() {
        var tpos = Vector3.zero - this.mon.transform.position;
        this.mon.transform.LookAt(tpos);
        this.monAnim.speed *= 1.5f;
        this.monAnim.Play("walk");

        while (true) {
            this.mon.transform.Translate(Vector3.forward * 1.8f * Time.deltaTime);
            var dis = Vector3.Distance(Vector3.zero, this.mon.transform.position);
            if (dis <= 0.1f) {
                this.monAnim.Play("idle", -1, 0);
                break;
            }
            yield return null;   
        }
        this.moveCompleteAction();
    }
}
