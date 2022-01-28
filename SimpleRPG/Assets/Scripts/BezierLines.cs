using UnityEngine;
using System.Collections.Generic;

public class BezierLines : MonoBehaviour
{

	[SerializeField]
	private int segmentsCount = 100;
	private List<GameObject> _curves;

	void Awake()
	{
		_curves = new List<GameObject>();
	}

	public void AddCurve(Vector3[] points, Color? startColor = null, Color? endColor = null, float startWidth = 0.2f, float endWidth = 0.02f)
	{
		Color beginColor = startColor ?? Color.red;
		Color finishColor = endColor ?? Color.red;
		GameObject line = new GameObject("Line-" + _curves.Count);
		line.transform.position = Vector3.zero;
		line.transform.SetParent(transform);
		line.transform.localPosition = Vector3.zero;
		line.transform.localScale = Vector3.one;
		//line.AddComponent<RectTransform>();
		line.AddComponent<LineRenderer>();
		LineRenderer render = line.GetComponent<LineRenderer>();
		render.useWorldSpace = false;
		//render.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		render.SetColors(beginColor, finishColor);
		render.SetWidth(startWidth, endWidth);
		render.SetVertexCount(segmentsCount);
		for (int i = 0; i < segmentsCount; i++)
		{
			float t = (float)i / (float)(segmentsCount - 1);
			//Vector3 point = CalculateBezierPoint(t, points[0], points[1], points[2], points[3]);
			Vector3 point = CalculateBezierPoint2(t, points[0], points[1], points[2]);
			render.SetPosition(i, point);
		}
		_curves.Add(line);
	}

	public void RemoveCurves()
	{
		_curves.Clear();
		int childs = transform.childCount;
		for (int i = childs - 1; i >= 0; i--)
			Destroy(transform.GetChild(i).gameObject);
	}

	/*
	 * 2차 베지어 곡선 공식 
	 * Mathf.Pow(1 - t, 3) * this.points[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * this.points[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * this.points[2].position +
                Mathf.Pow(t, 3) * points[3].position;
	 */

	Vector3 CalculateBezierPoint2(float t, Vector3 p0, Vector3 p1, Vector3 p2)
	{
		//return Mathf.Pow(1 - t, 3) * p0 +
		//		3 * Mathf.Pow(1 - t, 2) * t * p1 +
		//		3 * (1 - t) * Mathf.Pow(t, 2) * p2;
		//t = 0.5; // given example value
		var xx = (1 - t) * (1 - t) * p0.x + 2 * (1 - t) * t * p1.x + t * t * p2.x;
		var zz = (1 - t) * (1 - t) * p0.z + 2 * (1 - t) * t * p1.z + t * t * p2.z;
		return new Vector3(xx, 0, zz);
	}


	Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		float u = 1 - t;
		float tt = t * t;
		float uu = u * u;
		float uuu = uu * u;
		float ttt = tt * t;
		Vector3 p = uuu * p0;
		p += 3 * uu * t * p1;
		p += 3 * u * tt * p2;
		p += ttt * p3;
		return p;
	}

}