using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorBezier : MonoBehaviour
{
    public Transform[] points;

    private Vector2 gizmosPosition;

    public List<Vector3> GetPath() {
        List<Vector3> paths = new List<Vector3>();
        foreach (var point in this.points) {
            paths.Add(point.transform.position);
        }
        return paths;
    }

    //이벤트 함수 
    private void OnDrawGizmos()
    {
        var t = 0.5f;
        var xx = (1 - t) * (1 - t) * this.points[0].position.x + 2 * (1 - t) * t * this.points[1].position.x + t * t * this.points[2].position.x;
        var zz = (1 - t) * (1 - t) * this.points[0].position.z + 2 * (1 - t) * t * this.points[1].position.z + t * t * this.points[2].position.z;
        this.gizmosPosition = new Vector3(xx, 0, zz);

        Gizmos.DrawSphere(this.gizmosPosition, 0.05f);
        //for (float t = 0; t <= 1; t += 0.05f)
        //{
        //    //this.gizmosPosition = Mathf.Pow(1 - t, 3) * this.points[0].position +
        //    //    3 * Mathf.Pow(1 - t, 2) * t * this.points[1].position +
        //    //    3 * (1 - t) * Mathf.Pow(t, 2) * this.points[2].position +
        //    //    Mathf.Pow(t, 3) * points[3].position;

        //    var xx = (1 - t) * (1 - t) * this.points[0].position.x + 2 * (1 - t) * t * this.points[1].position.x + t * t * this.points[2].position.x;
        //    var zz = (1 - t) * (1 - t) * this.points[0].position.z + 2 * (1 - t) * t * this.points[1].position.z + t * t * this.points[2].position.z;
        //    this.gizmosPosition = new Vector3(xx, 0, zz);

        //    Gizmos.DrawSphere(this.gizmosPosition, 0.05f);
        //}
    }
}