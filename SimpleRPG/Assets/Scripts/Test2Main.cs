using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* USSAGE
 * 
 * https://github.com/mopsicus/unity-bezier-curves
 * 
 * using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour {

	[SerializeField]
	private BezierLines lines;
	private int _curveCount;
	private Vector3[] _curvePoints;

	void Awake () {
		_curveCount = -1;
		_curvePoints = new Vector3[4];
	}

	public void RemoveCurves () {
		lines.RemoveCurves ();
		_curveCount = -1;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
     		Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
    		position.z = transform.position.z;
     		_curveCount++;
     		_curvePoints[_curveCount] = position;
     		if (_curveCount == 3) {
				_curveCount = -1;
     			lines.AddCurve (_curvePoints, Color.red, Color.blue);
     		}
     	}
	}

}
 */
public class Test2Main : MonoBehaviour
{
    public Transform t1;
    public Transform t2;
    public Transform t3;
    public Transform t4;
    [Range(0, 1)]
    public float scale = 0.5f;



    [SerializeField]
    private BezierLines lines;
    private int _curveCount;
    private Vector3[] _curvePoints;
    void Start()
    {


        //var lhs = Vector3.right;
        //var rhs = Vector3.up;
        //var c = Vector3.Cross(lhs, rhs);
        //DrawArrow.ForDebug(Vector3.zero, c, 10000f, Color.red, ArrowType.Solid);
        var dir = (t2.position - t1.position).normalized;
        var dis = Vector3.Distance(t2.position, t1.position);
        //DrawArrow.ForDebug(t1.position, dir * (dis * 0.5f), 10000f, Color.cyan, ArrowType.Solid);
        var tpos = this.t1.position + dir * (dis * 0.5f);
        this.t3.position = tpos;

        var lhs = dir.normalized;
        var rhs = Vector3.up;
        var c = Vector3.Cross(lhs, rhs);
        //DrawArrow.ForDebug(tpos, c, 10000f, Color.red, ArrowType.Solid);

        this.t4.position = this.t3.position + (c.normalized * this.scale);



        //make bezier
        _curvePoints = new Vector3[]{ this.t1.position, this.t2.position, this.t4.position };
        lines.AddCurve(_curvePoints, Color.red, Color.blue);

    }

    //이벤트 함수 
    private void OnDrawGizmos()
    {
        //for (float t = 0; t <= 1; t += 0.05f)
        //{
        //    this.gizmosPosition = Mathf.Pow(1 - t, 3) * this.points[0].position +
        //        3 * Mathf.Pow(1 - t, 2) * t * this.points[1].position +
        //        3 * (1 - t) * Mathf.Pow(t, 2) * this.points[2].position +
        //        Mathf.Pow(t, 3) * points[3].position;

        //    Gizmos.DrawSphere(this.gizmosPosition, 0.05f);
        //}
    }


    // Update is called once per frame
    void Update()
    {
        
        //Debug.DrawLine(Vector3.zero, this.t1.position, Color.red);
        //Debug.DrawLine(Vector3.zero, this.t2.position, Color.red);
        //Debug.DrawLine(this.t1.position, this.t1.position+this.t1.up * 3f, Color.green);

        
    }
}
