using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(this.bamsongiPrefab) as GameObject;
            //bamsongi.GetComponent<BamsongiController>().Shoot(new Vector3(0, 200, 2000));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //��ũ�� ��ǥ�� ������ǥ�� �������� Ray�� ��� 
            //Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 1.0f);
            Vector3 worldDir = ray.direction;
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000);

        }
    }
}
