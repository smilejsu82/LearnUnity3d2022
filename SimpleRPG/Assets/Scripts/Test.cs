using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject spear;
    public GameObject player;

    // Start is called before the first frame update
    Vector3 dir;
    void Start()
    {
        //https://docs.unity3d.com/ScriptReference/Quaternion.ToAngleAxis.html
        //회전을 각도 축 표현(각도 단위)으로 변환합니다
        //변환 회전에서 각도 - 축 회전을 추출합니다.
        var s = this.spear.transform.position;
        DrawArrow.ForDebug(s, Vector3.right, 10f, Color.red, ArrowType.Solid);


        float angle = 0.0f;
        Vector3 axis = Vector3.zero;
        this.spear.transform.rotation.ToAngleAxis(out angle, out axis);

        Debug.LogFormat("{0}\n{1}\n{2}", angle, (int)angle, axis);
        Debug.LogFormat("{0}\n{1}", angle * Mathf.Deg2Rad, (int)angle * Mathf.Deg2Rad);

        var dot = Vector3.Dot(this.spear.transform.forward, Vector3.right);
        Debug.LogFormat("<color=yellow>{0}</color>", dot);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
