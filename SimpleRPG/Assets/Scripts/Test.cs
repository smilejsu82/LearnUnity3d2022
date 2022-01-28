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
        //ȸ���� ���� �� ǥ��(���� ����)���� ��ȯ�մϴ�
        //��ȯ ȸ������ ���� - �� ȸ���� �����մϴ�.
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
