using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public float distance = 0.5f;
    public GameObject model;
    private Rigidbody rigid;
    public float upForce = 200f;
    void Awake()
    {
        this.rigid = this.GetComponent<Rigidbody>();
    }

    public void Init(Vector3 initPos) {
        startTime = Time.time;
        this.transform.position = initPos;
        this.rigid.AddForce(Vector3.up * upForce);

        StartCoroutine(this.WaitForDrop(() => {
            Destroy(this.rigid);
            Debug.Log("drop complete!");
        }));
    }
    float startTime;
    public float duration = 5f;
    public float rotSpeed = 2.5f;
    bool isComplete = false;
    IEnumerator WaitForDrop(System.Action callback) {
        
        while (true) {
            if (isComplete) break;
            yield return null;

            if (this.rigid.velocity.y < 0)
            {
                Ray ray = new Ray(this.transform.position, -this.transform.up * this.distance);
                Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, this.distance))
                {
                    if (hit.collider.tag.Equals("Ground"))
                    {
                        Debug.Log("!");
                        Quaternion q = new Quaternion();
                        q.SetFromToRotation(this.transform.forward, Vector3.up);

                        while (true) {    
                            float t = (Time.time - startTime) / duration;
                            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, q, this.rotSpeed * t );
                            yield return null;

                            var lhs = this.transform.forward;
                            var rhs = Vector3.forward;
                            DrawArrow.ForDebug(this.transform.position, lhs, 0.1f, Color.red, ArrowType.Solid);

                            DrawArrow.ForDebug(Vector3.zero, rhs, 0.1f, Color.blue, ArrowType.Solid);

                            //Debug.LogFormat("{0}, {1}", Vector3.Dot(lhs, rhs), Vector3.Dot(lhs, rhs) == 0);
                            Debug.Log(this.rigid.velocity);

                            if (Vector3.Dot(lhs, rhs) <= 0.1f)
                            {
                                this.isComplete = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
        callback();

    }
}
